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
    public class KoperRepository : GenericRepository<Koper>, IKoperRepository
    {
        public KoperRepository(DbContext context) : base(context) { }
    }
}
