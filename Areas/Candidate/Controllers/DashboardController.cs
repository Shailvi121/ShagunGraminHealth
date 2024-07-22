using Microsoft.AspNetCore.Mvc;

namespace ShagunGraminHealth.Areas.Candidate.Controllers
{
    [Area("Candidate")]

    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
