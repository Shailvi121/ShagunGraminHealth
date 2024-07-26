using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Razorpay.Api;
using ShagunGraminHealth.Interface;
using ShagunGraminHealth.Models;
using ShagunGraminHealth.Services;
using ShagunGraminHealth.ViewModel;
using System;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Threading.Tasks;

namespace ShagunGraminHealth.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MemberController : Controller
    {
        private readonly IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {
            _memberService = memberService;

        }

        public async Task<IActionResult> AllPlans()
        {
            var data = await _memberService.GetAllMembershipPlansAsync();
            return View(data);
        }

        public async Task<IActionResult> UpdateProfile()
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
            {
                return Unauthorized();
            }

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
                return Redirect("/Admin/Dashboard");

            }
            return View(user);
        }
        public IActionResult ApplyMember(string planNumber, string PlanFee, string ApplicationId)
        {

            ViewBag.PaymentAmount = PlanFee;
            ViewBag.PlanNumber = planNumber;
            ViewBag.ApplicationId = ApplicationId;

            return View();
        }

        [HttpPost]

        public async Task<IActionResult> ApplyMember(MembershipFormViewModel model)
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            model.UserId = Convert.ToInt32(userIdClaim);
            await _memberService.ApplyMembershipFormAsync(model);
            return View("Payment", model);
        }
        public async Task<IActionResult> AppliedPlan()
        {
            var data = await _memberService.GetAppliedPlansAsync();
            return View(data);
        }


        public async Task<IActionResult> Payment(PaymentViewModel model)
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            model.UserId = Convert.ToInt32(userIdClaim);
            await _memberService.ProcessPaymentAsync(model);
            return RedirectToAction("AppliedPlan");

        }

        public async Task<IActionResult> UserDetails()
        {
            var userDetails = await _memberService.GetDetailsAsync();
            return View(userDetails);
        }
        public async Task<IActionResult> ViewPayments(string Application_Id)
        {
            var Member = await _memberService.GetMemberApplicationIdAsync(Application_Id);
            return View(Member);
        }

       


    }
}