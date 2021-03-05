using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Content_Management_System.Models;

namespace Content_Management_System.Controllers
{
    public class LampenController : Controller
    {
        public IActionResult Index()
        {
            LampenContext context = HttpContext.RequestServices.GetService(typeof(Content_Management_System.Models.LampenContext)) as LampenContext;

            return View(context.GetAllLampen());
        }
    }
}
