using CMS_Individueel_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS_Individueel_Project.Data.Data.Repositories.Interfaces
{
    public class ProducentRepository : GenericRepository<Producent>, IProducentRepository
    {
        public ProducentRepository(DbContext context) : base(context) { }
    }
}
