using CMS_Individueel_Project.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CMS_Individueel_Project.Data.Data.Repositories.Interfaces
{
    public class KoperRepository : GenericRepository<Koper>, IKoperRepository
    {
        public KoperRepository(DbContext context) : base(context) { }
    }
}
