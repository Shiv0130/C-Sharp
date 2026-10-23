using ApplicationUser = Staybnb.Models.ApplicationUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Staybnb.Data;
using Staybnb.Models;

namespace Staybnb.Controllers
{
    [Authorize(Roles = AppRoles.Host)]
    public class HostDashboardController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public HostDashboardController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            var properties = await _context.HostProperties
                .Where(p => p.HostId == user.Id)
                .ToListAsync();

            var propertyIds = properties.Select(p => p.Id).ToList();

            ViewBag.PropertyCount = properties.Count;
            ViewBag.ActiveCount = properties.Count(p => p.IsActive);
            ViewBag.PendingBookings = await _context.Bookings
                .CountAsync(b => propertyIds.Contains(b.PropertyId) && b.Status == "Pending");
            ViewBag.TotalBookings = await _context.Bookings
                .CountAsync(b => propertyIds.Contains(b.PropertyId));
            ViewBag.TotalEarnings = await _context.Bookings
                .Where(b => propertyIds.Contains(b.PropertyId) && (b.Status == "Approved" || b.Status == "CheckedIn"))
                .SumAsync(b => (decimal?)b.TotalPrice) ?? 0m;
            ViewBag.HostName = string.IsNullOrWhiteSpace(user.FirstName) ? user.Email : user.FirstName + " " + user.LastName;

            return View(properties);
        }

        public async Task<IActionResult> MyProperties()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            var list = await _context.HostProperties
                .Include(p => p.Images)
                .Where(p => p.HostId == user.Id)
                .ToListAsync();

            return View(list);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleActive(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            var property = await _context.HostProperties
                .FirstOrDefaultAsync(p => p.Id == id && p.HostId == user.Id);

            if (property == null)
            {
                return NotFound();
            }

            property.IsActive = !property.IsActive;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(MyProperties));
        }

        public async Task<IActionResult> BookingRequests()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            var bookings = await _context.Bookings
                .Include(b => b.Property)
                .Include(b => b.Guest)
                .Where(b => b.Property!.HostId == user.Id)
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();

            return View(bookings);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ApproveBooking(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            var booking = await _context.Bookings
                .Include(b => b.Property)
                .FirstOrDefaultAsync(b => b.Id == id && b.Property!.HostId == user.Id);

            if (booking == null)
            {
                return NotFound();
            }

            booking.Status = "Approved";

            _context.Notifications.Add(new Notification
            {
                UserId = booking.GuestId,
                Title = "Booking approved",
                Message = "Your booking was approved by the host.",
                Type = "Booking",
                CreatedAt = DateTime.UtcNow
            });

            _context.ActivityLogs.Add(new ActivityLog
            {
                UserId = user.Id,
                Action = "Booking " + id + " approved",
                ActivityType = "Booking",
                CreatedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(BookingRequests));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RejectBooking(int id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            var booking = await _context.Bookings
                .Include(b => b.Property)
                .FirstOrDefaultAsync(b => b.Id == id && b.Property!.HostId == user.Id);

            if (booking == null)
            {
                return NotFound();
            }

            booking.Status = "Rejected";

            _context.Notifications.Add(new Notification
            {
                UserId = booking.GuestId,
                Title = "Booking rejected",
                Message = "Your booking was declined by the host.",
                Type = "Booking",
                CreatedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(BookingRequests));
        }
    }
}
