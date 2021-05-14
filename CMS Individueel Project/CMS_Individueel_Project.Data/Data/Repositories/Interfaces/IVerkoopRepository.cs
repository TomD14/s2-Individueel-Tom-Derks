using CMS_Individueel_Project.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Individueel_Project.Data.Data.Repositories.Interfaces
{
    interface IVerkoopRepository
    {
        Task<IEnumerable<Verkoop>> GetAllVerkopenByModelAsync(string searchString);
    }
}
