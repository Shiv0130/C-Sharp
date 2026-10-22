using ApplicationUser = Staybnb.Models.ApplicationUser;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Staybnb.Data;
using Staybnb.Models;

namespace Staybnb.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Public discovery — active listings only
        public async Task<IActionResult> Index(string? city, string? propertyType)
        {
            var query = _context.HostProperties
                .Include(p => p.Images)
                .Include(p => p.Host)
                .Where(p => p.IsActive)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(city))
                query = query.Where(p => p.City.Contains(city));

            if (!string.IsNullOrWhiteSpace(propertyType))
                query = query.Where(p => p.PropertyType == propertyType);

            ViewBag.City = city;
            ViewBag.PropertyType = propertyType;
            return View(await query.OrderByDescending(p => p.Id).ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var property = await _context.HostProperties
                .Include(p => p.Images)
                .Include(p => p.Host)
                .Include(p => p.Amenities)
                .Include(p => p.Reviews)
                .FirstOrDefaultAsync(p => p.Id == id && p.IsActive);

            if (property == null) return NotFound();
            return View(property);
        }
    }
}
