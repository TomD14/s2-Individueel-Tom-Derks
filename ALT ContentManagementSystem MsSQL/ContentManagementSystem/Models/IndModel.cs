using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContentManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace ContentManagementSystem.Models
{
    public class IndModel : PageModel
    {
        private readonly ContentManagementSystemDbContext _db;
        public IndModel(ContentManagementSystemDbContext db)
        {
            _db = db;
        }
        
        public IEnumerable<Lamp> getLampen { get; set; }

        public async Task OnGet()
        {
            getLampen = await _db.Lamp.ToListAsync();
        }

        public async Task<IActionResult> OnPostDelete(int id)
        {
            var lamp = await _db.Lamp.FindAsync(id);
            if (lamp == null)
            {
                return NotFound();

            }
            _db.Lamp.Remove(lamp);
            await _db.SaveChangesAsync();

            return RedirectToPage("Ind");
        }
    }
}
