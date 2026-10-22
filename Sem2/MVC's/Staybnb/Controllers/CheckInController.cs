using ApplicationUser = Staybnb.Models.ApplicationUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Staybnb.Data;
using Staybnb.Models;

namespace Staybnb.Controllers
{
    [Authorize]
    public class CheckInController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IWebHostEnvironment _env;

        public CheckInController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            IWebHostEnvironment env)
        {
            _context = context;
            _userManager = userManager;
            _env = env;
        }

        [Authorize(Roles = AppRoles.Guest)]
        public async Task<IActionResult> Start(int bookingId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            var booking = await _context.Bookings
                .Include(b => b.GuestCheckIn)!.ThenInclude(c => c!.Documents)
                .Include(b => b.Property)
                .FirstOrDefaultAsync(b => b.Id == bookingId && b.GuestId == user.Id);

            if (booking == null)
            {
                return NotFound();
            }

            if (booking.Status != "Approved" && booking.Status != "CheckedIn")
            {
                TempData["Error"] = "Check-in is only available for approved bookings.";
                return RedirectToAction("MyBookings", "Bookings");
            }

            if (booking.GuestCheckIn == null)
            {
                var checkIn = new GuestCheckIn
                {
                    BookingId = booking.Id,
                    Status = "Pending",
                    CreatedAt = DateTime.UtcNow
                };
                _context.GuestCheckIns.Add(checkIn);
                await _context.SaveChangesAsync();
                booking.GuestCheckIn = checkIn;
            }

            return View(booking.GuestCheckIn);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = AppRoles.Guest)]
        public async Task<IActionResult> UploadDocument(int guestCheckInId, string documentType, IFormFile file)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            var checkIn = await _context.GuestCheckIns
                .Include(c => c.Booking)
                .FirstOrDefaultAsync(c => c.Id == guestCheckInId && c.Booking!.GuestId == user.Id);

            if (checkIn == null)
            {
                return NotFound();
            }

            if (file == null || file.Length == 0)
            {
                TempData["Error"] = "Please choose a file.";
                return RedirectToAction(nameof(Start), new { bookingId = checkIn.BookingId });
            }

            var folder = Path.Combine(_env.WebRootPath, "uploads", "documents");
            Directory.CreateDirectory(folder);

            var name = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var path = Path.Combine(folder, name);

            using (var stream = System.IO.File.Create(path))
            {
                await file.CopyToAsync(stream);
            }

            _context.GuestDocuments.Add(new GuestDocument
            {
                GuestCheckInId = checkIn.Id,
                DocumentType = documentType,
                FilePath = "/uploads/documents/" + name,
                Status = "Pending"
            });

            checkIn.Status = "DocumentsSubmitted";

            var hostId = await _context.HostProperties
                .Where(p => p.Id == checkIn.Booking!.PropertyId)
                .Select(p => p.HostId)
                .FirstAsync();

            _context.Notifications.Add(new Notification
            {
                UserId = hostId,
                Title = "Guest document uploaded",
                Message = "A guest uploaded a " + documentType + " for booking #" + checkIn.BookingId + ".",
                Type = "CheckIn",
                CreatedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
            TempData["Success"] = "Document uploaded.";
            return RedirectToAction(nameof(Start), new { bookingId = checkIn.BookingId });
        }

        [Authorize(Roles = AppRoles.Host)]
        public async Task<IActionResult> HostQueue()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            var items = await _context.GuestCheckIns
                .Include(c => c.Booking)!.ThenInclude(b => b!.Property)
                .Include(c => c.Booking)!.ThenInclude(b => b!.Guest)
                .Include(c => c.Documents)
                .Where(c => c.Booking!.Property!.HostId == user.Id)
                .OrderByDescending(c => c.CreatedAt)
                .ToListAsync();

            return View(items);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = AppRoles.Host)]
        public async Task<IActionResult> VerifyDocument(int documentId, bool approve)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Challenge();
            }

            var doc = await _context.GuestDocuments
                .Include(d => d.GuestCheckIn)!.ThenInclude(c => c!.Booking)!.ThenInclude(b => b!.Property)
                .FirstOrDefaultAsync(d => d.Id == documentId);

            if (doc == null || doc.GuestCheckIn?.Booking?.Property?.HostId != user.Id)
            {
                return NotFound();
            }

            doc.Status = approve ? "Verified" : "Rejected";

            if (approve)
            {
                doc.GuestCheckIn!.Status = "Verified";
                doc.GuestCheckIn.Booking!.Status = "CheckedIn";
            }

            _context.Notifications.Add(new Notification
            {
                UserId = doc.GuestCheckIn!.Booking!.GuestId,
                Title = approve ? "Document verified" : "Document rejected",
                Message = approve
                    ? "Your check-in document was verified. Status: CheckedIn."
                    : "Your check-in document was rejected. Please re-upload.",
                Type = "CheckIn",
                CreatedAt = DateTime.UtcNow
            });

            _context.ActivityLogs.Add(new ActivityLog
            {
                UserId = user.Id,
                Action = "Document " + documentId + (approve ? " verified" : " rejected"),
                ActivityType = "CheckIn",
                CreatedAt = DateTime.UtcNow
            });

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(HostQueue));
        }
    }
}
