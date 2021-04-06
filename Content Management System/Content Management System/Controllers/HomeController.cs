using Content_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Content_Management_System.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Inventaris()
        {

            LampContext context = HttpContext.RequestServices.GetService(typeof(Content_Management_System.Models.LampContext)) as LampContext;
            return View(context.GetAllLampen());

            LampContext context = HttpContext.RequestServices.GetService(typeof(Content_Management_System.Models.LampContext)) as LampContext;
            return View(context.GetAllLampen());
            return View();

        }


        //[HttpPost]
        //public IActionResult Create([Bind] Lampen Lampen)
        //{
        //    try
        //    {
        //        if (ModelState.IsValid)
        //        {
        //            string resp = Convert.ToString(Lampen);
        //            TempData["msg"] = resp;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        TempData["msg"] = ex.Message;
        //    }
        //    return View();
        //}

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
