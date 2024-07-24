using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using ShagunGraminHealth.Interface;
using ShagunGraminHealth.Models;
using System.Security.Claims;

namespace ShagunGraminHealth.Controllers
{
    public class UserLoginController : Controller
    {
        private readonly IUserService _userService;

        public UserLoginController(IUserService userService)
        {
            _userService = userService;
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

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
                };

                claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity));

                if (roles.Contains("Member"))
                {
                    return Redirect("/Admin/Dashboard");
                }
                else if (roles.Contains("Candidate"))
                {
                    return Redirect("/Candidate/Dashboard");
                }
                else
                {
                    return Redirect("/Organization/Index");
                }
            }

            ModelState.AddModelError(string.Empty, "User not found. Please check your credentials.");
            TempData["ErrorMessage"] = "User not found. Please check your credentials.";
            return RedirectToAction("Login", "UserLogin");
        }


        public IActionResult Register(string role)
        {
            ViewBag.Role = role;
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

            ModelState.AddModelError(string.Empty, "Email already exists.");
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "UserLogin");
        }
    }
}
