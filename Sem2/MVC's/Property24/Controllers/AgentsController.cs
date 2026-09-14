using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Property24.Data;
using Property24.Models;

namespace Property24.Controllers
{
    
    public class AgentsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public AgentsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //GET: Agents   
        public async Task<IActionResult> Index()
        {
            var agents = await _context.Agents
                .Include(a => a.Properties)
                .ToListAsync();
            return View(agents);
        }

        //GET: Agents/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST: Agents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Create([Bind("FullName", "Email", "PhoneNumber")] Agent agent) 
        {
            if (ModelState.IsValid) 
            {
                _context.Add(agent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(agent);
        }

        //GET: Agents/Edit/5
        public async Task<IActionResult> Edit(int? id) 
        {
            if (id == null) return NotFound();
            var agent = await _context.Agents.FindAsync(id);
            if (agent == null) return NotFound();
            return View(agent);
        }

        //POST: Agents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(int id, [Bind("Id", "FullName", "Email", "PhoneNumber")] Agent agent) 
        {
            if (id != agent.Id) return NotFound();
            if (ModelState.IsValid) 
            {
                try 
                {
                    _context.Update(agent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException) 
                {
                    if (!AgentExists(agent.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(agent);
        }

        //GET: Agents/Delete/5
        public async Task<IActionResult> Delete(int? id) 
        {
            if (id == null) return NotFound();
            var agent = await _context.Agents
                .Include(a => a.Properties)
                .FirstOrDefaultAsync(a => a.Id == id);
            if (agent == null) return NotFound();
            return View(agent);
        }

        //POST: Agents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> DeleteConfirmed(int id) 
        {
            var agent = await _context.Agents
                .Include(a => a.Properties)
                .FirstOrDefaultAsync(a => a.Id == id); 
          
            if (agent == null) return NotFound();

            //Guard: prevent deleting an agent who still has listings
            if (agent.Properties != null && agent.Properties.Any()) 
            {
                ModelState.AddModelError(string.Empty,
                    $"Cannot delete '{agent.FullName}' because they have {agent.Properties.Count} active listing{(agent.Properties.Count == 1 ? "" : "s")}."+ 
                    "Reassign or delete those listings first");
                return View("Delete",agent);
            }
            _context.Agents.Remove(agent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        
        private bool AgentExists(int id) 
        {
            return _context.Agents.Any(e => e.Id == id);
        }

    }
}
