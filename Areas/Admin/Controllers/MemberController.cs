﻿using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ShagunGraminHealth.Interface;
using ShagunGraminHealth.Models;
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

        public async Task<IActionResult> Index()
        {
            var data = await _memberService.GetAllMembershipPlansAsync();
            return View(data);
        }

        public async Task<IActionResult> UpdateProfile()
        {
            int userId = 1;
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
        public async Task<IActionResult> ApplyMember(MembershipForm model, IFormFile fileToUpload)
        {
            if (ModelState.IsValid)
            {
                if (fileToUpload != null && fileToUpload.Length > 0)
                {
                    string uploadsFolder = "wwwroot/WebFormImages";
                    string uniqueFileName = Guid.NewGuid().ToString() + "_" + fileToUpload.FileName;
                    string filePath = Path.Combine(uploadsFolder, uniqueFileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await fileToUpload.CopyToAsync(fileStream);
                    }

                    //model.age_photo = "~/WebFormImages/" + uniqueFileName;
                    //model.age_proof = "~/WebFormImages/" + uniqueFileName;
                }

                await _memberService.SaveMembershipFormAsync(model);
                ViewBag.Message = "Membership application submitted successfully.";
                return RedirectToAction("Index", "Dashboard");
            }
            return View(model);
        }
    }
}
    





