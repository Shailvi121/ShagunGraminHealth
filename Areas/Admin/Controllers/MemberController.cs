using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ShagunGraminHealth.Interface;
using ShagunGraminHealth.Models;
using ShagunGraminHealth.Services;
using ShagunGraminHealth.ViewModel;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace ShagunGraminHealth.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        private readonly IWebHostEnvironment _environment;

        public MemberController(IMemberService memberService, IWebHostEnvironment environment)
        {
            _memberService = memberService;
            _environment = environment;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _memberService.GetAllMembershipPlansAsync();
            return View(data);
        }

        public async Task<IActionResult> UpdateProfile()
        {
            var usserId = HttpContext.Session.GetInt32("UserId");
            int userId = usserId.Value;
            var user = await _memberService.GetUserByIdAsync(userId);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateProfile(User user)
        {
            if (ModelState.IsValid)
            {
                await _memberService.UpdateUserProfileAsync(user);
                ViewBag.Message = "Profile updated successfully.";
            }
            return View(user);
        }
        public ActionResult ApplyMember(string PlanNumber)
        {
            ViewBag.PlanNumber = PlanNumber;
            return View();
        }
        [HttpPost]

        public async Task<IActionResult> ApplyMember(MembershipFormViewModel model)
        {
            await _memberService.ApplyMembershipFormAsync(model);
            return Ok();
        }
    }
}