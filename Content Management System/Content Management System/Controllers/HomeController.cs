using Content_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Content_Management_System.Models.Classes;

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
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Registration(FormCollection formCollection)
        {
            if (ModelState.IsValid)
            {
                Lamp lamp = new Lamp()
                {
                    Model = formCollection["Model"],
                    Watt = Convert.ToInt32(formCollection["Watt"]),
                    Kleur = Convert.ToInt32(formCollection["Kleur"]),
                    Aantal = Convert.ToInt32(formCollection["Aantal"])
                };

                RegisterLamp.CreateLampData(lamp);
                return View("/Home/Inventaris");
            }
            else
            {
                return View("/Home/Inventaris");
            }
        }
    }
}
