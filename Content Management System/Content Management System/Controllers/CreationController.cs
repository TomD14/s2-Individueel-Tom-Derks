using Content_Management_System.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Content_Management_System.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

namespace Content_Management_System.Controllers
{
    public class CreationController : Controller
    {
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
				return View("Registration");
			}
			else
			{
				return View("Registration");
			}
		}
	}
}
