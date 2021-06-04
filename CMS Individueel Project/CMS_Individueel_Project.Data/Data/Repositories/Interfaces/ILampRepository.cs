using CMS_Individueel_Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Individueel_Project.Data.Data.Repositories.Interfaces
{
    public interface ILampRepository
    {
        Task<IEnumerable<Lamp>> GetAllLampsByModelAsync(string searchString);
        Task<IEnumerable<Lamp>> GetProducentLampen(int producentId);
    }
}
