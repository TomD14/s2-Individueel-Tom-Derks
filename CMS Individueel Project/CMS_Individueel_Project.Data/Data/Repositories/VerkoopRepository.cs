using CMS_Individueel_Project.Data.Data.Repositories.Interfaces;
using CMS_Individueel_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Individueel_Project.Data.Data.Repositories
{
    public class VerkoopRepository : GenericRepository<Verkoop>, IVerkoopRepository
    {
        public VerkoopRepository(DbContext context) : base(context) { }

        public async Task<IEnumerable<Verkoop>> GetAllVerkopenByModelAsync(string searchString)
        {

            return await table.Include("Lamp").Include("Koper").AsSingleQuery().Where(s => s.Lamp.Model.Contains(searchString == null? "" : searchString)).ToListAsync();
        }

        public async Task<IEnumerable<Verkoop>> GetKoperAankopen(int koperId)
        {
            return await table.Include("Lamp").Where(s => s.KoperId == koperId).ToListAsync();
        }
    }
}
