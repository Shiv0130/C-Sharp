using ApplicationUser = Staybnb.Models.ApplicationUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Staybnb.Data;
using Staybnb.Models;

namespace Staybnb.Controllers
{
    [Authorize(Roles = AppRoles.Guest)]
    public class HostApplicationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _env;

        public HostApplicationsController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            string title,
            string description,
            decimal pricePerNight,
            string address,
            string city,
            string propertyType,
            List<IFormFile> images)
        {
            if (images == null || images.Count == 0 || images.All(i => i.Length == 0))
            {
                ModelState.AddModelError(string.Empty, "At least one property image is required.");
            }

            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(address))
            {
                ModelState.AddModelError(string.Empty, "Title and address are required.");
            }

            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            var property = new HostProperty
            {
                Title = title,
                Description = description,
                PricePerNight = pricePerNight,
                Address = address,
                City = city,
                PropertyType = propertyType,
                IsActive = false,
                HostId = user.Id
            };

            _context.HostProperties.Add(property);
            await _context.SaveChangesAsync();

            var uploadsRoot = Path.Combine(_env.WebRootPath, "uploads", "properties");
            Directory.CreateDirectory(uploadsRoot);

            foreach (var file in images.Where(f => f.Length > 0))
            {
                var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
                var path = Path.Combine(uploadsRoot, fileName);

                using (var stream = System.IO.File.Create(path))
                {
                    await file.CopyToAsync(stream);
                }

                _context.PropertyImages.Add(new PropertyImage
                {
                    PropertyId = property.Id,
                    ImageUrl = "/uploads/properties/" + fileName
                });
            }

            var application = new HostApplication
            {
                ApplicantUserId = user.Id,
                PropertyId = property.Id,
                Status = "Pending",
                AppliedAt = DateTime.UtcNow
            };

            _context.HostApplications.Add(application);

            _context.ActivityLogs.Add(new ActivityLog
            {
                UserId = user.Id,
                Action = "Host application submitted",
                ActivityType = "HostApplication",
                CreatedAt = DateTime.UtcNow
            });

            _context.Notifications.Add(new Notification
            {
                UserId = user.Id,
                Title = "Application received",
                Message = "Your host application is pending admin review.",
                Type = "HostApplication",
                CreatedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
            TempData["Success"] = "Application submitted. Wait for admin approval.";
            return RedirectToAction(nameof(Status));
        }

        public async Task<IActionResult> Status()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            var apps = await _context.HostApplications
                .Include(a => a.Property)
                .Where(a => a.ApplicantUserId == user.Id)
                .OrderByDescending(a => a.AppliedAt)
                .ToListAsync();

            return View(apps);
        }
    }
}
