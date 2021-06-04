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
    public class KopersController : Controller
    {
        KoperRepository koperRepository;
        public KopersController(CMSContext context)
        {
            koperRepository = new KoperRepository(context);
        }
        public async Task<IActionResult> Index()
        {
            var kopers = await koperRepository.GetAllAsync();

            return View(kopers);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Naam,Rekeningnummer,AdresId,Gemeente,Straat,Huisnummer,PostCode")]Koper koper)
        {
            
            if (ModelState.IsValid)
            {
                koperRepository.Add(koper);
                
                await koperRepository.SaveAsync();

                return RedirectToAction(nameof(Index));
            }
            return View(koper);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koper = await koperRepository.GetByIdAsync(id);
            if (koper == null)
            {
                return NotFound();
            }
            return View(koper);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Naam,Rekeningnummer,AdresId,Gemeente,Straat,Huisnummer,PostCode")] Koper koper)
        {
            if (id != koper.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    koperRepository.Update(koper);
                    await koperRepository.SaveAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KoperExists(koper.Id))
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
            return View(koper);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var koper = await koperRepository.GetByIdAsync(id);

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
            var koper = await koperRepository.GetByIdAsync(id);
            
            koperRepository.Remove(koper);
            await koperRepository.SaveAsync();
            return RedirectToAction(nameof(Index));
        }
        private bool KoperExists(int id)
        {
            return koperRepository.GetByIdAsync(id) != null;

        }
    }
}
