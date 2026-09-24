using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Property24.Data;
using Property24.Models;

namespace Property24.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Categories

        public async Task<IActionResult> Index()
        {
            var categories = await _context.Categories
                .Include(c => c.Properties)
                .ToListAsync();
            return View(categories);
        }



        //// GET: Categories/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null) return NotFound();

        //    var category = await _context.Categories
        //        .Include(c => c.Properties)
        //            .ThenInclude(p => p.Agent)
        //        .FirstOrDefaultAsync(m => m.Id == id);

        //    if (category == null) return NotFound();

        //    return View(category);
        //}

        public IActionResult Details(int? id)
        {
            if(id== null) return NotFound();

            var category = _context.Categories.Include(c => c.Properties).ThenInclude(p=>p.Agent).FirstOrDefault(c => c.Id == id);

            return View(category);
        }

        // GET: Categories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name")] Category category)
        {
            if (ModelState.IsValid)
            {
                _context.Add(category);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();

            return View(category);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Category category)
        {
            if (id != category.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(category);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryExists(category.Id)) return NotFound();
                    else throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var category = await _context.Categories
                .Include(c => c.Properties)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (category == null) return NotFound();

            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var category = await _context.Categories
                .Include(c => c.Properties)
                .FirstOrDefaultAsync(c => c.Id == id);

            if (category == null) return NotFound();

            // Guard: prevent deleting a category that still has properties
            if (category.Properties != null && category.Properties.Any())
            {
                ModelState.AddModelError(string.Empty,
                    $"Cannot delete '{category.Name}' because it has {category.Properties.Count} propert{(category.Properties.Count == 1 ? "y" : "ies")} assigned. " +
                    "Reassign or delete those properties first.");
                return View("Delete", category);
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryExists(int id)
        {
            return _context.Categories.Any(e => e.Id == id);
        }
    }
}
