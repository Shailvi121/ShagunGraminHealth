using Microsoft.AspNetCore.Mvc;
using ShagunGraminHealth.Interface;
using ShagunGraminHealth.Services;

namespace ShagunGraminHealth.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService=memberService;
        }
        public async Task<IActionResult> Index()
        {
           var data = await _memberService.GetAllMembershipPlansAsync();

            return View(data);
        }
    }
}
