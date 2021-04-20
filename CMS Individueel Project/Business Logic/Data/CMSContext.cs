using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Business_Logic.Models;

namespace Business_Logic.Data
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
