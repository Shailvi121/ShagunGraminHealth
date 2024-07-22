using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ShagunGraminHealth.Areas.Candidate.Controllers
{
    [Area("Candidate")]
    //[Authorize(Roles = "Candidate")]

    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
