using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceDesk.Data;
using ServiceDesk.Models;

namespace ServiceDesk.Controllers
{
    public class SupportTicketsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SupportTicketsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: SupportTickets
        public async Task<IActionResult> Index()
        {
            var tickets = await _context.SupportTickets
                .Include(t => t.Employee)
                .Include(t => t.ItTechnician)
                .OrderBy(t => t.IsResolved) // unresolved (false) first
                .ThenByDescending(t => t.CreatedAt)
                .ToListAsync();
            return View(tickets);
        }

        // GET: SupportTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var ticket = await _context.SupportTickets
                .Include(t => t.Employee)
                .Include(t => t.ItTechnician)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (ticket == null) return NotFound();
            return View(ticket);
        }

        // GET: SupportTickets/Create
        public async Task<IActionResult> Create()
        {
            await PopulateTicketDropdownsAsync();
            return View();
        }

        // POST: SupportTickets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Title,Description,Priority,IsResolved,EmployeeId,ItTechnicianId")]
            SupportTicket ticket)
        {
            if (!CanAssignCriticalTicket(ticket.Priority, ticket.ItTechnicianId))
            {
                ModelState.AddModelError("ItTechnicianId",
                    "Critical tickets require a Tier 2 or SysAdmin technician.");
            }

            if (ModelState.IsValid)
            {
                ticket.CreatedAt = DateTime.Now; // stamp before save
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            await PopulateTicketDropdownsAsync(ticket.EmployeeId, ticket.ItTechnicianId);
            return View(ticket);
        }

        // GET: SupportTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var ticket = await _context.SupportTickets.FindAsync(id);
            if (ticket == null) return NotFound();

            await PopulateTicketDropdownsAsync(ticket.EmployeeId, ticket.ItTechnicianId);
            return View(ticket);
        }

        // POST: SupportTickets/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id,
            [Bind("Id,Title,Description,Priority,CreatedAt,IsResolved,EmployeeId,ItTechnicianId")]
            SupportTicket ticket)
        {
            if (id != ticket.Id) return NotFound();

            if (!CanAssignCriticalTicket(ticket.Priority, ticket.ItTechnicianId))
            {
                ModelState.AddModelError("ItTechnicianId",
                    "Critical tickets require a Tier 2 or SysAdmin technician.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupportTicketExists(ticket.Id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }

            await PopulateTicketDropdownsAsync(ticket.EmployeeId, ticket.ItTechnicianId);
            return View(ticket);
        }

        // GET: SupportTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var ticket = await _context.SupportTickets
                .Include(t => t.Employee)
                .Include(t => t.ItTechnician)
                .FirstOrDefaultAsync(t => t.Id == id);

            if (ticket == null) return NotFound();
            return View(ticket);
        }

        // POST: SupportTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.SupportTickets.FindAsync(id);
            if (ticket != null)
            {
                _context.SupportTickets.Remove(ticket);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool SupportTicketExists(int id)
        {
            return _context.SupportTickets.Any(t => t.Id == id);
        }

        private async Task PopulateTicketDropdownsAsync(
            int? selectedEmployeeId = null, int? selectedTechnicianId = null)
        {
            var employees = await _context.Employees.ToListAsync();
            var technicians = await _context.ItTechnicians.ToListAsync();

            ViewData["EmployeeId"] = new SelectList(
                employees, "Id", "FullName", selectedEmployeeId);
            ViewData["ItTechnicianId"] = new SelectList(
                technicians, "Id", "TechnicianName", selectedTechnicianId);
        }

        // Critical → Tier 2 or SysAdmin only
        private bool CanAssignCriticalTicket(string priority, int technicianId)
        {
            if (priority != "Critical") return true;

            var tech = _context.ItTechnicians.Find(technicianId);
            if (tech == null) return false;

            return tech.TierLevel == "Tier 2" || tech.TierLevel == "SysAdmin";
        }
    }
}