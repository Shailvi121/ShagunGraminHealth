﻿using Microsoft.AspNetCore.Mvc;

namespace ShagunGraminHealth.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

    }
}
