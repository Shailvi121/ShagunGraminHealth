using Microsoft.AspNetCore.Mvc;

namespace ShagunGraminHealth.Controllers
{
    public class UserLoginController : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

    }
}
