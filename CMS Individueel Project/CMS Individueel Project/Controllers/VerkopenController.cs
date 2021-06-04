using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_Individueel_Project.Data;
using CMS_Individueel_Project.Data.Data.Repositories;
using CMS_Individueel_Project.Data.Data.Repositories.Interfaces;
using CMS_Individueel_Project.Data.Models;
using CMS_Individueel_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CMS_Individueel_Project.Controllers
{
    public class VerkopenController : Controller
    {
        VerkoopRepository verkoopRepository;
        LampRepository lampRepository;
        KoperRepository koperRepository;
        public VerkopenController(CMSContext context)
        {
            verkoopRepository = new VerkoopRepository(context);
            lampRepository = new LampRepository(context);
            koperRepository = new KoperRepository(context);
        }

        // GET: Lamps
        public async Task<IActionResult> Index(string searchString)
        {
            var verkopen = await verkoopRepository.GetAllVerkopenByModelAsync(searchString);

            return View(verkopen);
        }

        // GET: Lamps/Create
        public async Task<IActionResult> Create()
        {
            var lamps = await lampRepository.GetAllAsync();
            var kopers = await koperRepository.GetAllAsync();
            ViewData["lamps"] = lamps;
            ViewData["kopers"] = kopers;
            return View();
        }

        // POST: Lamps/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LampId,Aantal,KoperId")] Verkoop verkoop)
        {
            if (ModelState.IsValid)
            {
                var lamp = await lampRepository.GetByIdAsync(verkoop.LampId);
                var koper = await koperRepository.GetByIdAsync(verkoop.KoperId);

                if (lamp == null || koper == null)
                {
                    return NotFound();
                }

                lamp.Aantal -= verkoop.Aantal;
                lampRepository.Update(lamp);

                verkoopRepository.Add(verkoop);
                await verkoopRepository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(verkoop);
        }

        // GET: Lamps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var verkoop = await verkoopRepository.GetByIdAsync(id);
            if (verkoop == null)
            {
                return NotFound();
            }

            return View(verkoop);
        }

        // POST: Lamps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            
            var verkoop = await verkoopRepository.GetByIdAsync(id);
            var lamp = await lampRepository.GetByIdAsync(verkoop.LampId);

            lamp.Aantal += verkoop.Aantal;
            lampRepository.Update(lamp);

            verkoopRepository.Remove(verkoop);
            await verkoopRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> KoperVerkopen(int id)
        {
            string KoperNaam = koperRepository.GetById(id).Naam;

            ViewData["KoperNaam"] = KoperNaam;

            var Verkopen = await verkoopRepository.GetKoperAankopen(id);

            return View(Verkopen);
        }

        private bool LampExists(int id)
        {
            return verkoopRepository.GetByIdAsync(id) != null; ;
        }
    }
}
