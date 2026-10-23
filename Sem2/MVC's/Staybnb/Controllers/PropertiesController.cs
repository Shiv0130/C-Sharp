using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Staybnb.Data;

namespace Staybnb.Controllers
{
    public class PropertiesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PropertiesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET /Properties?city=Durban&propertyType=Cabin
        public async Task<IActionResult> Index(string? city, string? propertyType)
        {
            city = city?.Trim();
            propertyType = propertyType?.Trim();

            // Load active listings first, then filter in memory (reliable for this assignment size)
            var list = await _context.HostProperties
                .Include(p => p.Images)
                .Include(p => p.Host)
                .Where(p => p.IsActive)
                .OrderByDescending(p => p.Id)
                .ToListAsync();

            if (!string.IsNullOrWhiteSpace(city))
            {
                list = list
                    .Where(p => !string.IsNullOrEmpty(p.City) &&
                                p.City.Contains(city, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            if (!string.IsNullOrWhiteSpace(propertyType))
            {
                list = list
                    .Where(p => !string.IsNullOrEmpty(p.PropertyType) &&
                                p.PropertyType.Equals(propertyType, StringComparison.OrdinalIgnoreCase))
                    .ToList();
            }

            ViewBag.City = city;
            ViewBag.PropertyType = propertyType;
            ViewBag.ResultCount = list.Count;

            return View(list);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var property = await _context.HostProperties
                .Include(p => p.Images)
                .Include(p => p.Host)
                .Include(p => p.Amenities)
                .FirstOrDefaultAsync(p => p.Id == id && p.IsActive);

            if (property == null)
            {
                return NotFound();
            }

            return View(property);
        }
    }
}