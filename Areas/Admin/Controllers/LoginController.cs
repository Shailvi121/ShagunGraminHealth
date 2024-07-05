using Microsoft.AspNetCore.Mvc;

namespace ShagunGraminHealth.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }
    }
}
