using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using mvcCRUD.Models;

namespace mvcCRUD.Controllers
{
    public class HomeController : Controller
    {
        // Injected via DI - available for logging within any action here.
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        // GET: / or /Home/Index
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Home/Privacy
        public IActionResult Privacy()
        {
            return View();
        }

        // Generic error page. ResponseCache attributes ensure error pages are
        // never cached by the browser or any intermediate proxy.
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
