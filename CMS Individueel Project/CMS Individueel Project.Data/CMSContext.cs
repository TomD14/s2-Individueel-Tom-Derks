using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CMS_Individueel_Project.Models;

namespace CMS_Individueel_Project.Data
{
    public class CMSContext : DbContext
    {
        public CMSContext(DbContextOptions<CMSContext> options)
                : base(options)
        {
        }

        public DbSet<Lamp> Lamp { get; set; }
        public DbSet<Verkoop> Verkoop { get; set; }
    }
}
