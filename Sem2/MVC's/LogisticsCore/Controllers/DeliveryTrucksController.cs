using LogisticsCore.Data;
using LogisticsCore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LogisticsCore.Controllers
{
    public class DeliveryTrucksController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DeliveryTrucksController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: DeliveryTrucks
        public async Task<IActionResult> Index()
        {
            var trucks = await _context.DeliveryTrucks
                .Include(t => t.Depot)
                .Include(t => t.Driver)
                .ToListAsync();
            return View(trucks);
        }

        // GET: DeliveryTrucks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var truck = await _context.DeliveryTrucks
                .Include(t => t.Depot)
                .Include(t => t.Driver)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (truck == null) return NotFound();
            return View(truck);
        }

        // GET: DeliveryTrucks/Create
        public IActionResult Create()
        {
            PopulateDepotAndDriverDropDowns();
            return View();
        }

        // POST: DeliveryTrucks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("RegistrationNumber,Model,OdometerKm,MaxPayloadKg,DepotId,DriverId")]
            DeliveryTruck truck)
        {
            if (ModelState.IsValid)
            {
                _context.Add(truck);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateDepotAndDriverDropDowns(truck.DepotId, truck.DriverId);
            return View(truck);
        }

        // GET: DeliveryTrucks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var truck = await _context.DeliveryTrucks.FindAsync(id);
            if (truck == null) return NotFound();

            PopulateDepotAndDriverDropDowns(truck.DepotId, truck.DriverId);
            return View(truck);
        }

        // POST: DeliveryTrucks/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,RegistrationNumber,Model,OdometerKm,MaxPayloadKg,DepotId,DriverId")]
            DeliveryTruck truck)
        {
            if (id != truck.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(truck);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DeliveryTruckExists(truck.Id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            PopulateDepotAndDriverDropDowns(truck.DepotId, truck.DriverId);
            return View(truck);
        }

        // GET: DeliveryTrucks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var truck = await _context.DeliveryTrucks
                .Include(t => t.Depot)
                .Include(t => t.Driver)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (truck == null) return NotFound();
            return View(truck);
        }

        // POST: DeliveryTrucks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var truck = await _context.DeliveryTrucks.FindAsync(id);
            if (truck != null)
            {
                _context.DeliveryTrucks.Remove(truck);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool DeliveryTruckExists(int id)
        {
            return _context.DeliveryTrucks.Any(t => t.Id == id);
        }

        // Custom helper — used on Create/Edit GET + failed POST
        private void PopulateDepotAndDriverDropDowns(
            int? selectedDepotId = null, int? selectedDriverId = null)
        {
            ViewData["DepotId"] = new SelectList(
                _context.TruckDepots, "Id", "DepotName", selectedDepotId);
            ViewData["DriverId"] = new SelectList(
                _context.Drivers, "Id", "FullName", selectedDriverId);
        }
    }
}