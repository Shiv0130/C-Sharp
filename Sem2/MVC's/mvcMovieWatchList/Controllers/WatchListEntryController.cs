
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvcMovieWatchList.Models;
using mvcMovieWatchList.Data;

public class WatchListEntryController : Controller
{
    private readonly ApplicationDbContext _context;

    public WatchListEntryController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: WATCHLISTENTRYS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.WatchListEntries.ToListAsync());
    }

    // GET: WATCHLISTENTRYS/Details/5
    public async Task<IActionResult> Details(int? watchlistid)
    {
        if (watchlistid == null)
        {
            return NotFound();
        }

        var watchlistentry = await _context.WatchListEntries
            .FirstOrDefaultAsync(m => m.WatchListId == watchlistid);
        if (watchlistentry == null)
        {
            return NotFound();
        }

        return View(watchlistentry);
    }

    // GET: WATCHLISTENTRYS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: WATCHLISTENTRYS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("WatchListId,UserId,MovieId,Rating,WatchedDate,User,Movie")] WatchListEntry watchlistentry)
    {
        if (ModelState.IsValid)
        {
            _context.Add(watchlistentry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(watchlistentry);
    }

    // GET: WATCHLISTENTRYS/Edit/5
    public async Task<IActionResult> Edit(int? watchlistid)
    {
        if (watchlistid == null)
        {
            return NotFound();
        }

        var watchlistentry = await _context.WatchListEntries.FindAsync(watchlistid);
        if (watchlistentry == null)
        {
            return NotFound();
        }
        return View(watchlistentry);
    }

    // POST: WATCHLISTENTRYS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? watchlistid, [Bind("WatchListId,UserId,MovieId,Rating,WatchedDate,User,Movie")] WatchListEntry watchlistentry)
    {
        if (watchlistid != watchlistentry.WatchListId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(watchlistentry);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WatchListEntryExists(watchlistentry.WatchListId))
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
        return View(watchlistentry);
    }

    // GET: WATCHLISTENTRYS/Delete/5
    public async Task<IActionResult> Delete(int? watchlistid)
    {
        if (watchlistid == null)
        {
            return NotFound();
        }

        var watchlistentry = await _context.WatchListEntries
            .FirstOrDefaultAsync(m => m.WatchListId == watchlistid);
        if (watchlistentry == null)
        {
            return NotFound();
        }

        return View(watchlistentry);
    }

    // POST: WATCHLISTENTRYS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? watchlistid)
    {
        var watchlistentry = await _context.WatchListEntries.FindAsync(watchlistid);
        if (watchlistentry != null)
        {
            _context.WatchListEntries.Remove(watchlistentry);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool WatchListEntryExists(int? watchlistid)
    {
        return _context.WatchListEntries.Any(e => e.WatchListId == watchlistid);
    }
}
