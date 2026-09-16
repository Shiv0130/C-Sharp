using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Property24.Data;

namespace Property24.Controllers
{
    public class AdminController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AdminController(ApplicationDbContext context) 
        {
            _context = context;
        }

        public async Task<IActionResult> GetCategories() 
        {
            var categories = await _context.Categories.Include(c=> c.Properties).ToListAsync();
            return View();
        }

        public async Task<IActionResult> GetAgents() 
        {
            var agents = await _context.Agents.Include(a=> a.Properties).ToListAsync();
            return View(agents);
        }

        public async Task<IActionResult> GetProperties() 
        {
            var properties = await _context.Properties
                .Include(p=> p.Agent)
                .Include(p=> p.Category)
                .ToListAsync();
            return View(properties);
        }

        public async Task<IActionResult> GetAgentDetails(int? id) 
        {
            if (id == null) return NotFound();
            var agent = await _context.Agents.Include(a => a.Properties).ThenInclude(p => p.Category).FirstOrDefaultAsync(a => a.Id == id);
            
            if (agent == null) return NotFound();
            return View(agent);
        }

        
        public async Task<IActionResult> GetPropertyDetails(int? id) 
        {
            if (id == null) return NotFound();
            var property = await _context.Properties.Include(p => p.Agent).Include(p => p.Category).FirstOrDefaultAsync(p => p.Id == id);
            
            if (property == null) return NotFound();
            return View(property);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
