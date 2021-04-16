using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContentManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;

namespace ContentManagementSystem.Models
{
    public class CreateModel : PageModel
    {
        private readonly ContentManagementSystemDbContext _db;

        public CreateModel(ContentManagementSystemDbContext db)
        {
            _db = db;
        }

        [BindProperty]
        public Lamp Lamp { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (ModelState.IsValid)
            {
                await _db.Lamp.AddAsync(Lamp);
                await _db.SaveChangesAsync();
                return RedirectToPage("Ind");

            }
            else
            {
                return Page();
            }
        }
    }
}
