using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Staybnb.Data;
using Staybnb.Models;

namespace Staybnb.Controllers
{
    [Authorize]
    public class BookingsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        // Simple fixed fees for the assignment formula
        private const decimal CleaningFee = 250m;
        private const decimal ServiceFee = 150m;

        public BookingsController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // Guest: my bookings
        [Authorize(Roles = AppRoles.Guest + "," + AppRoles.Host)]
        public async Task<IActionResult> MyBookings()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            var bookings = await _context.Bookings
                .Include(b => b.Property)!.ThenInclude(p => p!.Images)
                .Where(b => b.GuestId == user.Id)
                .OrderByDescending(b => b.CreatedAt)
                .ToListAsync();

            return View(bookings);
        }

        [Authorize(Roles = AppRoles.Guest)]
        public async Task<IActionResult> Create(int propertyId)
        {
            var property = await _context.HostProperties
                .Include(p => p.Images)
                .FirstOrDefaultAsync(p => p.Id == propertyId && p.IsActive);

            if (property == null) return NotFound();
            ViewBag.Property = property;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = AppRoles.Guest)]
        public async Task<IActionResult> Create(
            int propertyId,
            DateTime checkInDate,
            DateTime checkOutDate,
            int numberOfGuests)
        {
            var property = await _context.HostProperties.FindAsync(propertyId);
            if (property == null || !property.IsActive) return NotFound();

            if (checkOutDate <= checkInDate)
            {
                ModelState.AddModelError(string.Empty, "Check-out must be after check-in.");
            }

            var nights = (checkOutDate.Date - checkInDate.Date).Days;
            if (nights < 1)
            {
                ModelState.AddModelError(string.Empty, "Stay must be at least 1 night.");
            }

            if (!ModelState.IsValid)
            {
                ViewBag.Property = property;
                return View();
            }

            // TotalPrice = (PricePerNight x Nights) + CleaningFee + ServiceFee
            var total = (property.PricePerNight * nights) + CleaningFee + ServiceFee;

            var user = await _userManager.GetUserAsync(User);
            if (user == null) return Challenge();

            var booking = new Booking
            {
                PropertyId = propertyId,
                GuestId = user.Id,
                CheckInDate = checkInDate.Date,
                CheckOutDate = checkOutDate.Date,
                NumberOfGuests = numberOfGuests,
                TotalPrice = total,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            };

            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();

            _context.Payments.Add(new Payment
            {
                BookingId = booking.Id,
                Amount = total,
                Status = "Pending",
                CreatedAt = DateTime.UtcNow
            });

            _context.Notifications.Add(new Notification
            {
                UserId = property.HostId,
                Title = "New booking request",
                Message = $"A guest requested {property.Title} ({nights} nights).",
                Type = "Booking",
                CreatedAt = DateTime.UtcNow
            });

            _context.ActivityLogs.Add(new ActivityLog
            {
                UserId = user.Id,
                Action = $"Booking created for property {propertyId}",
                ActivityType = "Booking",
                CreatedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
            TempData["Success"] = $"Booking requested. Total: R {total:0.00}";
            return RedirectToAction(nameof(MyBookings));
        }
    }
}
