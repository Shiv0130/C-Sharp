using ApplicationUser = Staybnb.Models.ApplicationUser;
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
            try
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
            catch (Exception ex)
            {
                TempData["Error"] = "Could not load dashboard: " + ex.Message;
                return View(new List<ActivityLog>());
            }
        }

        public async Task<IActionResult> Applications()
        {
            try
            {
                var apps = await _context.HostApplications
                    .Include(a => a.Applicant)
                    .Include(a => a.Property)!.ThenInclude(p => p!.Images)
                    .OrderByDescending(a => a.AppliedAt)
                    .ToListAsync();

                return View(apps);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Could not load applications: " + ex.Message;
                return View(new List<HostApplication>());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Approve(int id)
        {
            try
            {
                var app = await _context.HostApplications
                    .Include(a => a.Property)
                    .FirstOrDefaultAsync(a => a.Id == id);

                if (app == null)
                {
                    return NotFound();
                }

                if (app.Status != "Pending")
                {
                    return RedirectToAction(nameof(Applications));
                }

                var user = await _userManager.FindByIdAsync(app.ApplicantUserId);
                if (user == null)
                {
                    return NotFound();
                }

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
                    Action = "Host application approved - role swapped Guest to Host",
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
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Approve failed: " + ex.Message;
            }

            return RedirectToAction(nameof(Applications));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Reject(int id)
        {
            try
            {
                var app = await _context.HostApplications.FindAsync(id);
                if (app == null)
                {
                    return NotFound();
                }

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
                TempData["Success"] = "Application rejected.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Reject failed: " + ex.Message;
            }

            return RedirectToAction(nameof(Applications));
        }

        public async Task<IActionResult> ActivityLogs()
        {
            try
            {
                var logs = await _context.ActivityLogs
                    .Include(a => a.User)
                    .OrderByDescending(a => a.CreatedAt)
                    .Take(100)
                    .ToListAsync();

                return View(logs);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Could not load logs: " + ex.Message;
                return View(new List<ActivityLog>());
            }
        }

        [Authorize(Roles = AppRoles.SuperAdmin)]
        public async Task<IActionResult> Users()
        {
            try
            {
                var users = await _userManager.Users.OrderBy(u => u.Email).ToListAsync();
                var rows = new List<AdminUserRow>();

                foreach (var u in users)
                {
                    rows.Add(new AdminUserRow
                    {
                        User = u,
                        Roles = await _userManager.GetRolesAsync(u)
                    });
                }

                return View(rows);
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Could not load users: " + ex.Message;
                return View(new List<AdminUserRow>());
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = AppRoles.SuperAdmin)]
        public async Task<IActionResult> PromoteToAdmin(string userId)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return NotFound();
                }

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
                TempData["Success"] = user.Email + " is now an Admin.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Promote failed: " + ex.Message;
            }

            return RedirectToAction(nameof(Users));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = AppRoles.SuperAdmin)]
        public async Task<IActionResult> ResetPassword(string userId, string newPassword)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(newPassword) || newPassword.Length < 6)
                {
                    TempData["Error"] = "Password must be at least 6 characters.";
                    return RedirectToAction(nameof(Users));
                }

                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return NotFound();
                }

                var token = await _userManager.GeneratePasswordResetTokenAsync(user);
                var result = await _userManager.ResetPasswordAsync(user, token, newPassword);

                if (!result.Succeeded)
                {
                    var errors = string.Join(" ", result.Errors.Select(e => e.Description));
                    TempData["Error"] = "Password reset failed: " + errors;
                    return RedirectToAction(nameof(Users));
                }

                _context.ActivityLogs.Add(new ActivityLog
                {
                    UserId = user.Id,
                    Action = "Password reset by SuperAdmin",
                    ActivityType = "Account",
                    CreatedAt = DateTime.UtcNow
                });

                await _context.SaveChangesAsync();
                TempData["Success"] = "Password updated for " + user.Email + ". They can login with the new password.";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Reset failed: " + ex.Message;
            }

            return RedirectToAction(nameof(Users));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = AppRoles.SuperAdmin)]
        public async Task<IActionResult> SetRole(string userId, string role)
        {
            try
            {
                var user = await _userManager.FindByIdAsync(userId);
                if (user == null)
                {
                    return NotFound();
                }

                if (role != AppRoles.Guest && role != AppRoles.Host && role != AppRoles.Admin)
                {
                    TempData["Error"] = "Invalid role.";
                    return RedirectToAction(nameof(Users));
                }

                // Clear Guest/Host/Admin then add the chosen one (keep SuperAdmin if present)
                foreach (var r in new[] { AppRoles.Guest, AppRoles.Host, AppRoles.Admin })
                {
                    if (await _userManager.IsInRoleAsync(user, r))
                    {
                        await _userManager.RemoveFromRoleAsync(user, r);
                    }
                }

                await _userManager.AddToRoleAsync(user, role);

                _context.ActivityLogs.Add(new ActivityLog
                {
                    UserId = user.Id,
                    Action = "Role set to " + role + " by SuperAdmin",
                    ActivityType = "RoleChange",
                    CreatedAt = DateTime.UtcNow
                });

                await _context.SaveChangesAsync();
                TempData["Success"] = user.Email + " is now " + role + ".";
            }
            catch (Exception ex)
            {
                TempData["Error"] = "Role change failed: " + ex.Message;
            }

            return RedirectToAction(nameof(Users));
        }
    }

    public class AdminUserRow
    {
        public ApplicationUser User { get; set; } = null!;
        public IList<string> Roles { get; set; } = new List<string>();
    }
}