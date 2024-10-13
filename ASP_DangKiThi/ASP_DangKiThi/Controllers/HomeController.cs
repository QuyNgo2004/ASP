﻿using ASP_DangKiThi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASP_DangKiThi.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(db_ASP_ProjectContext objDBContext) : base(objDBContext)
        {

        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
