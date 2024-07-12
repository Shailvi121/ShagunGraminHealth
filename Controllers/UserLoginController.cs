using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShagunGraminHealth.Interface;
using ShagunGraminHealth.Models;
using System;
using System.Reflection;

namespace ShagunGraminHealth.Controllers
{
    public class UserLoginController : Controller
    {
        private readonly IUserService _userService;
        public UserLoginController(IUserService userService)
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
            var user = _userService.SignIn(model);
            if (user != null)
            {
                TempData["SuccessMessage"] = "Login successful!";

                return Redirect("/Admin/Dashboard");

            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            }
            return RedirectToAction("Index", "Dashboard");
        }
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User model)
        {
            var existingUser = _userService.SignUp(model);
            if (existingUser != null)
            {
                TempData["SuccessMessage"] = "Registration successful! Please log in.";

                return RedirectToAction("Login");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Username already exists.");
            }

            return RedirectToAction("Login");
        }
    }
}
