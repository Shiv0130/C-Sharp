
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc_BloggingPlatform.Models;
using mvc_BloggingPlatform.Data;

public class BlogPostController : Controller
{
    private readonly ApplicationDbContext _context;

    public BlogPostController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: BLOGPOSTS
    public async Task<IActionResult> Index()    
    {
        return View(await _context.BlogPosts.ToListAsync());
    }

    // GET: BLOGPOSTS/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var blogpost = await _context.BlogPosts
            .FirstOrDefaultAsync(m => m.Id == id);
        if (blogpost == null)
        {
            return NotFound();
        }

        return View(blogpost);
    }

    // GET: BLOGPOSTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: BLOGPOSTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Title,Content,PublishDate,AuthorId,Author")] BlogPost blogpost)
    {
        if (ModelState.IsValid)
        {
            _context.Add(blogpost);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(blogpost);
    }

    // GET: BLOGPOSTS/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var blogpost = await _context.BlogPosts.FindAsync(id);
        if (blogpost == null)
        {
            return NotFound();
        }
        return View(blogpost);
    }

    // POST: BLOGPOSTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int? id, [Bind("Id,Title,Content,PublishDate,AuthorId,Author")] BlogPost blogpost)
    {
        if (id != blogpost.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(blogpost);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BlogPostExists(blogpost.Id))
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
        return View(blogpost);
    }

    // GET: BLOGPOSTS/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var blogpost = await _context.BlogPosts
            .FirstOrDefaultAsync(m => m.Id == id);
        if (blogpost == null)
        {
            return NotFound();
        }

        return View(blogpost);
    }

    // POST: BLOGPOSTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int? id)
    {
        var blogpost = await _context.BlogPosts.FindAsync(id);
        if (blogpost != null)
        {
            _context.BlogPosts.Remove(blogpost);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool BlogPostExists(int? id)
    {
        return _context.BlogPosts.Any(e => e.Id == id);
    }
}
