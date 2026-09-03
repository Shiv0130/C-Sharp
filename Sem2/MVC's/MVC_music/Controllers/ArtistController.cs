
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MVC_music.Models;
using MVC_music.Data;

// FIX: every action below used to take its route parameter as "artistid".
// The default route is {controller}/{action}/{id?}, and asp-route-id in the
// views always sets the route value under the key "id" - so "artistid" never
// received a value and every Edit/Details/Delete link 404'd. Parameter
// renamed to "id" everywhere; internal comparisons to ArtistId are unchanged.
public class ArtistController : Controller
{
    private readonly ApplicationDbContext _context;

    public ArtistController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: ARTISTS
    public async Task<IActionResult> Index()
    {   //Old code
        //var artists = await _context.Artists.ToListAsync();
        var artists = await _context.Artists.Include(a => a.Songs).ToListAsync();
        return View(artists);
    }

    // GET: ARTISTS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var artist = await _context.Artists
            .FirstOrDefaultAsync(m => m.ArtistId == id);
        if (artist == null)
        {
            return NotFound();
        }

        return View(artist);
    }

    // GET: ARTISTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ARTISTS/Create
    // "Songs" removed from the bind list - it's a navigation collection, not a
    // form field, and was never something a text input could populate anyway.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("ArtistId,Name")] Artist artist)
    {
        if (ModelState.IsValid)
        {
            _context.Add(artist);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(artist);
    }

    // GET: ARTISTS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var artist = await _context.Artists.FindAsync(id);
        if (artist == null)
        {
            return NotFound();
        }
        return View(artist);
    }

    // POST: ARTISTS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("ArtistId,Name")] Artist artist)
    {
        if (id != artist.ArtistId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(artist);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArtistExists(artist.ArtistId))
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
        return View(artist);
    }

    // GET: ARTISTS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var artist = await _context.Artists
            .FirstOrDefaultAsync(m => m.ArtistId == id);
        if (artist == null)
        {
            return NotFound();
        }

        return View(artist);
    }

    // POST: ARTISTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var artist = await _context.Artists.FindAsync(id);
        if (artist != null)
        {
            _context.Artists.Remove(artist);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ArtistExists(int id)
    {
        return _context.Artists.Any(e => e.ArtistId == id);
    }
}
