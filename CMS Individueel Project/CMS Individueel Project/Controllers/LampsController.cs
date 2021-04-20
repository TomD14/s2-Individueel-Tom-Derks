using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Business_Logic.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Business_Logic.Models;

namespace CMS_Individueel_Project.Controllers
{
    public class LampsController : Controller
    {
        private readonly CMSContext _context;

        public LampsController(CMSContext context)
        {
            _context = context;
        }

        // GET: Lamps
        public async Task<IActionResult> Index(string searchString)
        {
            var lampen = from m in _context.Lamp
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                lampen = lampen.Where(s => s.Model.Contains(searchString));
            }

            return View(await lampen.ToListAsync());
        }

        // GET: Lamps/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var lamp = await _context.Lamp
                .FirstOrDefaultAsync(m => m.Id == id);
            if (lamp == null)
            {
                return NotFound();
            }

            return View(lamp);
        }

        // GET: Lamps/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Lamps/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Model,Watt,Kleur,Prijs,Aantal")] Lamp lamp)
        {
            if (ModelState.IsValid)
            {
                _context.Add(lamp);
                await _context.SaveChangesAsync();
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

            var lamp = await _context.Lamp.FindAsync(id);
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
                    _context.Update(lamp);
                    await _context.SaveChangesAsync();
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

            var lamp = await _context.Lamp
                .FirstOrDefaultAsync(m => m.Id == id);
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
            var lamp = await _context.Lamp.FindAsync(id);
            _context.Lamp.Remove(lamp);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LampExists(int id)
        {
            return _context.Lamp.Any(e => e.Id == id);
        }
    }
}
