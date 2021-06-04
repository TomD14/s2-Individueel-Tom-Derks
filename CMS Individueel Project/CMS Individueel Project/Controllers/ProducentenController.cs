using CMS_Individueel_Project.Data;
using CMS_Individueel_Project.Data.Data.Repositories;
using CMS_Individueel_Project.Data.Data.Repositories.Interfaces;
using CMS_Individueel_Project.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading.Tasks;

namespace CMS_Individueel_Project.Controllers
{
    public class ProducentenController : Controller
    {
        ProducentRepository producentRepository;

        public ProducentenController(CMSContext context)
        {
            producentRepository = new ProducentRepository(context);
        }
        public async Task<IActionResult> Index()
        {
            var kopers = await producentRepository.GetAllAsync();

            return View(kopers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Naam,Rekeningnummer,Gemeente,Straat,Huisnummer,PostCode")] Producent producent)
        {

            if (ModelState.IsValid)
            {
                producentRepository.Add(producent);

                await producentRepository.SaveAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(producent);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koper = await producentRepository.GetByIdAsync(id);
            if (koper == null)
            {
                return NotFound();
            }
            return View(koper);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Rekeningnummer,Gemeente,Straat,Huisnummer,PostCode")] Producent producent)
        {
            if (id != producent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    producentRepository.Update(producent);
                    await producentRepository.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KoperExists(producent.Id))
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
            return View(producent);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koper = await producentRepository.GetByIdAsync(id);

            if (koper == null)
            {
                return NotFound();
            }
            return View(koper);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var producent = await producentRepository.GetByIdAsync(id);

            producentRepository.Remove(producent);
            await producentRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool KoperExists(int id)
        {
            return producentRepository.GetByIdAsync(id) != null;

        }
    }
}
