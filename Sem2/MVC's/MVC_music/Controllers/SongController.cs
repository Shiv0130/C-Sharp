
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVC_music.Models;
using MVC_music.Data;

// FIX: same "id" route-parameter fix as ArtistController - see the comment
// there for the full explanation.
// Also: Create/Edit no longer bind "Genre"/"Artist" directly (those are
// object navigation properties - a text input can't populate them, which is
// why they showed up as broken/pointless fields). Instead GenreId/ArtistId
// are now proper dropdowns, populated below via ViewBag SelectLists, so you
// pick a real Genre/Artist by name instead of typing a raw ID number.
public class SongController : Controller
{
    private readonly ApplicationDbContext _context;

    public SongController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: SONGS
    public async Task<IActionResult> Index()
    {
        // Include Genre/Artist so the list can show their names, not just blank.
        var songs = await _context.Songs
            .Include(s => s.Genre)
            .Include(s => s.Artist)
            .ToListAsync();
        return View(songs);
    }

    // GET: SONGS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var song = await _context.Songs
            .Include(s => s.Genre)
            .Include(s => s.Artist)
            .FirstOrDefaultAsync(m => m.SongId == id);
        if (song == null)
        {
            return NotFound();
        }

        return View(song);
    }

    // GET: SONGS/Create
    public IActionResult Create()
    {
        PopulateDropdowns();
        return View();
    }

    // POST: SONGS/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("SongId,Title,GenreId,ArtistId")] Song song)
    {
        if (ModelState.IsValid)
        {
            _context.Add(song);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        PopulateDropdowns(song.GenreId, song.ArtistId);
        return View(song);
    }

    // GET: SONGS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var song = await _context.Songs.FindAsync(id);
        if (song == null)
        {
            return NotFound();
        }
        PopulateDropdowns(song.GenreId, song.ArtistId);
        return View(song);
    }

    // POST: SONGS/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("SongId,Title,GenreId,ArtistId")] Song song)
    {
        if (id != song.SongId)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(song);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SongExists(song.SongId))
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
        PopulateDropdowns(song.GenreId, song.ArtistId);
        return View(song);
    }

    // GET: SONGS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var song = await _context.Songs
            .Include(s => s.Genre)
            .Include(s => s.Artist)
            .FirstOrDefaultAsync(m => m.SongId == id);
        if (song == null)
        {
            return NotFound();
        }

        return View(song);
    }

    // POST: SONGS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var song = await _context.Songs.FindAsync(id);
        if (song != null)
        {
            _context.Songs.Remove(song);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool SongExists(int id)
    {
        return _context.Songs.Any(e => e.SongId == id);
    }

    // Builds the dropdown lists for the Genre/Artist pickers on Create and Edit.
    private void PopulateDropdowns(object? selectedGenreId = null, object? selectedArtistId = null)
    {
        ViewBag.GenreId = new SelectList(_context.Genres, "GenreId", "Name", selectedGenreId);
        ViewBag.ArtistId = new SelectList(_context.Artists, "ArtistId", "Name", selectedArtistId);
    }
}
