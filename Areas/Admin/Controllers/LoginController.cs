using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShagunGraminHealth.Models;

namespace ShagunGraminHealth.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {
        private readonly ShagunGraminHealthContext _context;

        public LoginController(ShagunGraminHealthContext context)
        {
            _context=context;
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(u => u.Name == model.Name);
                if (user != null)
                {
                    return RedirectToAction("Index", "Dashboard");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                }
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
            if (ModelState.IsValid)
            {
                var existingUser = _context.Users.FirstOrDefault(u => u.Name == model.Name);
                if (existingUser == null)
                {

                    var newUser = new User
                    {
                        Name = model.Name,
                        Email = model.Email,
                        Password = model.Password,
                        Mobile = model.Mobile,
                        ReferenceId = model.ReferenceId,
                        Passcode = model.Passcode,
                    };
                    _context.Users.Add(newUser);
                    _context.SaveChanges();

                    return RedirectToAction("Login");
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username already exists.");
                }
            }
            return RedirectToAction("Login");
        }
    }
}

    }
}
