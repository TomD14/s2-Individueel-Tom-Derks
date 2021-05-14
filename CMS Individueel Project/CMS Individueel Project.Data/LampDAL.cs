using CMS_Individueel_Project.Contract;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Individueel_Project.Data
{
    public class LampDAL : ILampDAL
    {
        private readonly CMSContext _context;

        public async Task AddLampAsync([Bind("Id,Model,Watt,Kleur,Prijs,Aantal")] LampDTO lamp)
        {
            _context.Add(lamp);
            await _context.SaveChangesAsync();
        }

        public void GetLamps(string searchString)
        {
            var lampen = from m in _context.Lamp
                         select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                lampen = lampen.Where(s => s.Model.Contains(searchString));
            }
        }
    }
}