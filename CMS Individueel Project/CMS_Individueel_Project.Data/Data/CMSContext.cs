using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CMS_Individueel_Project.Data.Models;

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
        public DbSet<Koper> Koper { get; set; }
        public DbSet<Producent> Producent { get; set; }
    }
}