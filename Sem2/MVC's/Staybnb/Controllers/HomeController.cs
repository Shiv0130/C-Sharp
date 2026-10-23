using Microsoft.AspNetCore.Mvc;
using Staybnb.Models;

namespace Staybnb.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            // After login, send each role to the right place (matches assignment dashboards)
            if (User.Identity?.IsAuthenticated == true)
            {
                if (User.IsInRole(AppRoles.SuperAdmin) || User.IsInRole(AppRoles.Admin))
                {
                    return RedirectToAction("Index", "Admin");
                }

                if (User.IsInRole(AppRoles.Host))
                {
                    return RedirectToAction("Index", "HostDashboard");
                }
            }

            // Guests + anonymous → Explore gallery (Airbnb-style home)
            return RedirectToAction("Index", "Properties");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View();
        }
    }
}
