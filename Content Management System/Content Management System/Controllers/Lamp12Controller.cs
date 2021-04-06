using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Content_Management_System.Models;

namespace Content_Management_System.Controllers
{
    public class Lamp12Controller : Controller
    {

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult LampToevoegen()
        {
            InventarisDBAccesLayer.AddLamp("INSERT INTO inventaris(`Model`,`Watt`,`Volt`,`Hertz`,`Kleur`,`Aantal`)VALUES( \'" + Request.Form["Model"] + "\', " + Request.Form["Watt"] + ", " + Request.Form["Volt"] + ", " + Request.Form["Hertz"] + ", " + Request.Form["Kleur"] + ", " + Request.Form["Aantal"] + ")");
            //return RedirectToAction("Inventaris", "Home");
            return Redirect("/Home/Inventaris");
        
        }
    }
}

