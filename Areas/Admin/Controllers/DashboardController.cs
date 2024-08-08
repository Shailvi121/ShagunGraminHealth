

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShagunGraminHealth.Interface;

namespace ShagunGraminHealth.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Member")]

    public class DashboardController : Controller
    {
        private readonly IMemberService _memberService;
        public DashboardController(IMemberService memberService)
        {
            _memberService = memberService;

        }
        [ResponseCache(NoStore = true, Location = ResponseCacheLocation.None)]
        public async Task<IActionResult> Index()
        {
            var data = await _memberService.GetAllMembershipPlansAsync();
            return View(data);
           
        }

    }
}
