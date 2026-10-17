using OceanViewHotel.Data;
using OceanViewHotel.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace OceanViewHotel.Controllers
{
    public class RoomBookingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RoomBookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var bookings = await _context.RoomBookings
                .Include(b => b.HotelRoom)
                .Include(b => b.Guest)
                .ToListAsync();
            return View(bookings);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var booking = await _context.RoomBookings
                .Include(b => b.HotelRoom)
                .Include(b => b.Guest)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (booking == null) return NotFound();
            return View(booking);
        }

        public IActionResult Create()
        {
            PopulateRoomAndGuestDropDowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("CheckInDate,CheckOutDate,NumberOfGuests,TotalCharge,HotelRoomId,GuestId")]
            RoomBooking booking)
        {
            if (await HasDateConflict(booking.HotelRoomId, booking.CheckInDate, booking.CheckOutDate))
            {
                ModelState.AddModelError(string.Empty,
                    "This room already has a booking that overlaps those dates.");
            }

            if (ModelState.IsValid)
            {
                _context.Add(booking);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateRoomAndGuestDropDowns(booking.HotelRoomId, booking.GuestId);
            return View(booking);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var booking = await _context.RoomBookings.FindAsync(id);
            if (booking == null) return NotFound();

            PopulateRoomAndGuestDropDowns(booking.HotelRoomId, booking.GuestId);
            return View(booking);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,CheckInDate,CheckOutDate,NumberOfGuests,TotalCharge,HotelRoomId,GuestId")]
            RoomBooking booking)
        {
            if (id != booking.Id) return NotFound();

            if (await HasDateConflict(booking.HotelRoomId, booking.CheckInDate,
                    booking.CheckOutDate, booking.Id))
            {
                ModelState.AddModelError(string.Empty,
                    "This room already has a booking that overlaps those dates.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(booking);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookingExists(booking.Id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateRoomAndGuestDropDowns(booking.HotelRoomId, booking.GuestId);
            return View(booking);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var booking = await _context.RoomBookings
                .Include(b => b.HotelRoom)
                .Include(b => b.Guest)
                .FirstOrDefaultAsync(b => b.Id == id);

            if (booking == null) return NotFound();
            return View(booking);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var booking = await _context.RoomBookings.FindAsync(id);
            if (booking != null)
            {
                _context.RoomBookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool BookingExists(int id)
        {
            return _context.RoomBookings.Any(b => b.Id == id);
        }

        private void PopulateRoomAndGuestDropDowns(
            int? selectedRoomId = null, int? selectedGuestId = null)
        {
            ViewData["HotelRoomId"] = new SelectList(
                _context.HotelRooms, "Id", "RoomNumber", selectedRoomId);
            ViewData["GuestId"] = new SelectList(
                _context.Guests, "Id", "FullName", selectedGuestId);
        }

        private async Task<bool> HasDateConflict(
            int roomId, DateTime checkIn, DateTime checkOut, int? currentBookingId = null)
        {
            return await _context.RoomBookings.AnyAsync(b =>
                b.HotelRoomId == roomId &&
                b.Id != currentBookingId &&
                checkIn < b.CheckOutDate &&
                checkOut > b.CheckInDate);
        }
    }
}