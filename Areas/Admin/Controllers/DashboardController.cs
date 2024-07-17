

using Microsoft.AspNetCore.Mvc;

namespace ShagunGraminHealth.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            var username = TempData["Username"] as string;
            var Email = TempData["Email"] as string;


            if (!string.IsNullOrEmpty(username))
            {
                ViewBag.Username = username;
                ViewBag.Email = Email;
            }

            return View();
        }

    }
}
