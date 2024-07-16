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
        public ActionResult ApplyMember()
        {
            //ViewBag.PlanNumber = PlanNumber;
            return View();
        }

        //[HttpPost]
        //public async Task<IActionResult> ApplyMember()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        model.Form_Date = DateTime.Now;

        //        // Save files
        //        if (model.Photo != null)
        //        {
        //            var photoPath = Path.Combine("wwwroot/uploads", model.Photo.FileName);
        //            using (var stream = new FileStream(photoPath, FileMode.Create))
        //            {
        //                await model.Photo.CopyToAsync(stream);
        //            }
        //            model.PhotoPath = photoPath;
        //        }

        //        if (model.Signature != null)
        //        {
        //            var signaturePath = Path.Combine("wwwroot/uploads", model.Signature.FileName);
        //            using (var stream = new FileStream(signaturePath, FileMode.Create))
        //            {
        //                await model.Signature.CopyToAsync(stream);
        //            }
        //            model.SignaturePath = signaturePath;
        //        }


        //        return RedirectToAction("Index");
        //    }

        //    return View(model);
        //}
    }
}
