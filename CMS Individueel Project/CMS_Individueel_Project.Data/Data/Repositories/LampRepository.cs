using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CMS_Individueel_Project.Data.Data.Repositories.Interfaces;
using CMS_Individueel_Project.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace CMS_Individueel_Project.Data.Data.Repositories
{
    public class LampRepository : GenericRepository<Lamp>, ILampRepository
    {
        public LampRepository(DbContext context) : base(context) { }

        public async Task<IEnumerable<Lamp>> GetAllLampsByModelAsync(string searchString)
        {
            return await table.Include("Producent").Where(s => s.Model.Contains(searchString == null? "" : searchString)).ToListAsync();
        }

        public async Task<IEnumerable<Lamp>> GetProducentLampen(int producentId)
        {
            return await table.Include("Producent").Where(s => s.ProducentId == producentId).ToListAsync();
        }
    }
}
