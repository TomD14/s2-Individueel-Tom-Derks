using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContentManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ContentManagementSystem.Models
{
    public class EditModel : PageModel
    {
        private ContentManagementSystemDbContext _db;

        public EditModel(ContentManagementSystemDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Lamp Lamp { get; set; }
        public async Task OnGet(int id)
        {
            Lamp = await _db.Lamp.FindAsync(id);
        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                var LampFromDb = await _db.Lamp.FindAsync(Lamp.Id);
                LampFromDb.Model = Lamp.Model;
                LampFromDb.Watt = Lamp.Watt;
                LampFromDb.Kleur = Lamp.Kleur;
                LampFromDb.Aantal = Lamp.Aantal;


                await _db.SaveChangesAsync();
                return RedirectToPage("Ind");

            }
            return RedirectToPage();
        }
    }
}

