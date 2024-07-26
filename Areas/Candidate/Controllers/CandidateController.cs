using Microsoft.AspNetCore.Mvc;
using ShagunGraminHealth.Interface;
using ShagunGraminHealth.Models;
using ShagunGraminHealth.ViewModel;

namespace ShagunGraminHealth.Areas.Candidate.Controllers
{
    [Area("Candidate")]

    public class CandidateController : Controller
    {
        private readonly IMemberService _memberService;
        public CandidateController(IMemberService memberService)
        {
            _memberService = memberService;

        }

        public async Task<IActionResult> ProfileUpdate()
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
        public async Task<IActionResult> ProfileUpdate(User user)
        {
            if (ModelState.IsValid)
            {
                await _memberService.UpdateUserProfileAsync(user);
                ViewBag.Message = "Profile updated successfully.";
                return Redirect("/Candidate/Dashboard");
            }
            return View(user);
        }
        public async Task<IActionResult> CandidateDetails()
        {
            var candidateDetails = await _memberService.GetDetailsAsync();
            return View(candidateDetails);
        }

        public IActionResult ApplyJob()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ApplyJob(JobApplicationViewModel model)
        {
            var userIdClaim = User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(userIdClaim) || !int.TryParse(userIdClaim, out int userId))
            {
                return Unauthorized();
            }

            //model.UserId = userId; // Ensure your view model has this property if needed

            await _memberService.ApplyJobAsync(model);

            return Redirect("/Candidate/Dashboard");
        }
    }
}
