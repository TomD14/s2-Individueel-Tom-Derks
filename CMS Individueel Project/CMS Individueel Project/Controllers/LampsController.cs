using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_Individueel_Project.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CMS_Individueel_Project.Models;
using CMS_Individueel_Project.Data.Models;
using CMS_Individueel_Project.Data.Data.Repositories;

namespace CMS_Individueel_Project.Controllers
{
    public class LampsController : Controller
    {
        LampRepository lampRepository;
        ProducentRepository producentRepository;

        public LampsController(CMSContext context)
        {
            lampRepository = new LampRepository(context);
            producentRepository = new ProducentRepository(context);
        }

        // GET: Lamps
        public async Task<IActionResult> Index(string searchString)
        {
            var lampen = await lampRepository.GetAllLampsByModelAsync(searchString);

            return View(lampen);
        }

        // GET: Lamps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lamp = await lampRepository.GetByIdAsync(id);

            if (lamp == null)
            {
                return NotFound();
            }

            return View(lamp);
        }

        // GET: Lamps/Create
        public async Task<IActionResult> Create()
        {
            var producent = await producentRepository.GetAllAsync();
            ViewData["Producent"] = producent;
            return View();
        }

        // POST: Lamps/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,ProducentId,Watt,Kleur,Prijs,Aantal")] Lamp lamp)
        {
            if (ModelState.IsValid)
            {
                lampRepository.Add(lamp);
                await lampRepository.SaveAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(lamp);
        }

        // GET: Lamps/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lamp = await lampRepository.GetByIdAsync(id);
            if (lamp == null)
            {
                return NotFound();
            }
            return View(lamp);
        }

        // POST: Lamps/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Model,Watt,Kleur,Prijs,Aantal")] Lamp lamp)
        {
            if (id != lamp.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                   lampRepository.Update(lamp);
                    await lampRepository.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LampExists(lamp.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(lamp);
        }

        // GET: Lamps/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lamp = await lampRepository.GetByIdAsync(id);

            if (lamp == null)
            {
                return NotFound();
            }
            return View(lamp);
        }

        // POST: Lamps/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var lamp = await lampRepository.GetByIdAsync(id);
            lampRepository.Remove(lamp);
            await lampRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> ProducentenLampen(int id)
        {
            string ProducentNaam = producentRepository.GetById(id).Naam;

            ViewData["ProducentNaam"] = ProducentNaam;

            var Lampen = await lampRepository.GetProducentLampen(id);

            return View(Lampen);
        }

        private bool LampExists(int id)
        {
            return lampRepository.GetByIdAsync(id) != null;

        }
    }
}
