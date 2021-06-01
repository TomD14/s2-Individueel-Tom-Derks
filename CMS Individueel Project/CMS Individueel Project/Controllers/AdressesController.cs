using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_Individueel_Project.Data.Data.Repositories;
using CMS_Individueel_Project.Data;
using CMS_Individueel_Project.Data.Data.Repositories.Interfaces;

namespace CMS_Individueel_Project.Controllers
{
    public class AdressesController : Controller
    {

        AdresRepository adresRepository;

        public AdressesController(CMSContext context)
        {
            adresRepository = new AdresRepository(context);
        }


        public async Task<IActionResult> Index()
        {
            var adresses = await adresRepository.GetAllAsync();

            return View(adresses);
        }
    }
}
