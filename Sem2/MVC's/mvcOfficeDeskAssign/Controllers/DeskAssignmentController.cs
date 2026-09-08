
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcOfficeDeskAssign.Models;
using mvcOfficeDeskAssign.Data;

public class DeskAssignmentController : Controller
{
    private readonly ApplicationDbContext _context;

    public DeskAssignmentController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: DESKASSIGNMENTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.DeskAssignments.ToListAsync());
    }

    // GET: DESKASSIGNMENTS/Details/5
    public async Task<IActionResult> Details(int? deskassignid)
    {
        if (deskassignid == null)
        {
            return NotFound();
        }

        var deskassignment = await _context.DeskAssignments
            .FirstOrDefaultAsync(m => m.DeskAssignId == deskassignid);
        if (deskassignment == null)
        {
            return NotFound();
        }

        return View(deskassignment);
    }

    // GET: DESKASSIGNMENTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: DESKASSIGNMENTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("DeskAssignId,DeskNumber,AssignDate,EmpId,Employee")] DeskAssignment deskassignment)
    {
        if (ModelState.IsValid)
        {
            _context.Add(deskassignment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(deskassignment);
    }

    // GET: DESKASSIGNMENTS/Edit/5
    public async Task<IActionResult> Edit(int? deskassignid)
    {
        if (deskassignid == null)
        {
            return NotFound();
        }

        var deskassignment = await _context.DeskAssignments.FindAsync(deskassignid);
        if (deskassignment == null)
        {
            return NotFound();
        }
        return View(deskassignment);
    }

    // POST: DESKASSIGNMENTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? deskassignid, [Bind("DeskAssignId,DeskNumber,AssignDate,EmpId,Employee")] DeskAssignment deskassignment)
    {
        if (deskassignid != deskassignment.DeskAssignId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(deskassignment);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeskAssignmentExists(deskassignment.DeskAssignId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(deskassignment);
    }

    // GET: DESKASSIGNMENTS/Delete/5
    public async Task<IActionResult> Delete(int? deskassignid)
    {
        if (deskassignid == null)
        {
            return NotFound();
        }

        var deskassignment = await _context.DeskAssignments
            .FirstOrDefaultAsync(m => m.DeskAssignId == deskassignid);
        if (deskassignment == null)
        {
            return NotFound();
        }

        return View(deskassignment);
    }

    // POST: DESKASSIGNMENTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? deskassignid)
    {
        var deskassignment = await _context.DeskAssignments.FindAsync(deskassignid);
        if (deskassignment != null)
        {
            _context.DeskAssignments.Remove(deskassignment);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool DeskAssignmentExists(int? deskassignid)
    {
        return _context.DeskAssignments.Any(e => e.DeskAssignId == deskassignid);
    }
}
