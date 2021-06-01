using CMS_Individueel_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS_Individueel_Project.Data.Data.Repositories.Interfaces
{
    public class AdresRepository : GenericRepository<Adres>, IAdresRepository
    {
        public AdresRepository(DbContext context) : base(context) { }

    }
}
