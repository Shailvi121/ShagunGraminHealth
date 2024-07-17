using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShagunGraminHealth.Interface;
using ShagunGraminHealth.Models;
using System;
using System.Reflection;
using System.Security.Claims;

namespace ShagunGraminHealth.Controllers
{
    public class UserLoginController : Controller
    {
        private readonly IUserService _userService;
        public UserLoginController(IUserService userService
        )
        {
            this._userService = userService;
        }


        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            var user = await _userService.SignInAsync(model);

            if (user != null)
            {
                var roles = await _userService.GetRoles(user.Id);

                TempData["SuccessMessage"] = "Login successful!";
                HttpContext.Session.SetString("Username", user.Name);
                HttpContext.Session.SetString("Email", user.Email);
                HttpContext.Session.SetInt32("UserId", user.Id);
                return Redirect("/Admin/Dashboard");



            }
            else
            {
                ModelState.AddModelError(string.Empty, "User not found. Please check your credentials.");

            }

            TempData["ErrorMessage"] = "User not found. Please check your credentials.";
            return RedirectToAction("Login", "UserLogin");

        }
        public IActionResult Register()
        {
            return View();
        }

		[HttpPost]
		public async Task<IActionResult> Register(RegistrationModel model)
		{
			var existingUser = await _userService.SignUp(model);  
			if (existingUser != null)
			{
				TempData["SuccessMessage"] = "Registration successful! Please log in.";
				return RedirectToAction("Login");
			}
			else
			{
				ModelState.AddModelError(string.Empty, "Email already exists.");
			}

			return View(model); // Return to the registration view with the model
		}

	}
}
