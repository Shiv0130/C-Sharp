using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Staybnb.Data;
using Staybnb.Models;

namespace Staybnb.Controllers
{
    [Authorize(Roles = AppRoles.Admin + "," + AppRoles.SuperAdmin)]
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public AdminController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.PendingApps = await _context.HostApplications.CountAsync(a => a.Status == "Pending");
            ViewBag.ActiveProperties = await _context.HostProperties.CountAsync(p => p.IsActive);
            ViewBag.TotalUsers = await _userManager.Users.CountAsync();
            ViewBag.TotalBookings = await _context.Bookings.CountAsync();

            var recent = await _context.ActivityLogs
                .Include(a => a.User)
                .OrderByDescending(a => a.CreatedAt)
                .Take(10)
                .ToListAsync();

            return View(recent);
        }

        public async Task<IActionResult> Applications()
        {
            var apps = await _context.HostApplications
                .Include(a => a.Applicant)
                .Include(a => a.Property)!.ThenInclude(p => p!.Images)
                .OrderByDescending(a => a.AppliedAt)
                .ToListAsync();
            return View(apps);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            var app = await _context.HostApplications
                .Include(a => a.Property)
                .FirstOrDefaultAsync(a => a.Id == id);

            if (app == null) return NotFound();
            if (app.Status != "Pending") return RedirectToAction(nameof(Applications));

            var user = await _userManager.FindByIdAsync(app.ApplicantUserId);
            if (user == null) return NotFound();

            // Brief: add Host, remove Guest (user is either Guest or Host, not both)
            if (await _userManager.IsInRoleAsync(user, AppRoles.Guest))
            {
                await _userManager.RemoveFromRoleAsync(user, AppRoles.Guest);
            }
            if (!await _userManager.IsInRoleAsync(user, AppRoles.Host))
            {
                await _userManager.AddToRoleAsync(user, AppRoles.Host);
            }

            app.Status = "Approved";
            if (app.Property != null)
            {
                app.Property.IsActive = true;
            }

            _context.ActivityLogs.Add(new ActivityLog
            {
                UserId = user.Id,
                Action = "Host application approved — role swapped Guest → Host",
                ActivityType = "RoleChange",
                CreatedAt = DateTime.UtcNow
            });

            _context.Notifications.Add(new Notification
            {
                UserId = user.Id,
                Title = "Host application approved",
                Message = "You are now a Host. Your property is active.",
                Type = "HostApplication",
                CreatedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
            TempData["Success"] = "Application approved. User is now a Host.";
            return RedirectToAction(nameof(Applications));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id)
        {
            var app = await _context.HostApplications.FindAsync(id);
            if (app == null) return NotFound();

            app.Status = "Rejected";
            _context.Notifications.Add(new Notification
            {
                UserId = app.ApplicantUserId,
                Title = "Host application rejected",
                Message = "Your host application was not approved.",
                Type = "HostApplication",
                CreatedAt = DateTime.UtcNow
            });
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Applications));
        }

        public async Task<IActionResult> ActivityLogs()
        {
            var logs = await _context.ActivityLogs
                .Include(a => a.User)
                .OrderByDescending(a => a.CreatedAt)
                .Take(100)
                .ToListAsync();
            return View(logs);
        }

        // SuperAdmin only — promote Guest to Admin
        [Authorize(Roles = AppRoles.SuperAdmin)]
        public async Task<IActionResult> Users()
        {
            var users = await _userManager.Users.OrderBy(u => u.Email).ToListAsync();
            var model = new List<(ApplicationUser User, IList<string> Roles)>();
            foreach (var u in users)
            {
                model.Add((u, await _userManager.GetRolesAsync(u)));
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = AppRoles.SuperAdmin)]
        public async Task<IActionResult> PromoteToAdmin(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();

            if (!await _userManager.IsInRoleAsync(user, AppRoles.Admin))
            {
                await _userManager.AddToRoleAsync(user, AppRoles.Admin);
            }

            _context.ActivityLogs.Add(new ActivityLog
            {
                UserId = user.Id,
                Action = "Promoted to Admin by SuperAdmin",
                ActivityType = "RoleChange",
                CreatedAt = DateTime.UtcNow
            });
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Users));
        }
    }
}
