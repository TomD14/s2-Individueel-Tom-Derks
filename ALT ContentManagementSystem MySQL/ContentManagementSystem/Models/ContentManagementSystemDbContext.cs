using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ContentManagementSystem.Models
{
    public class ContentManagementSystemDbContext:DbContext
    {
        public ContentManagementSystemDbContext(DbContextOptions<ContentManagementSystemDbContext> options) : base(options)
        {

        }
        public DbSet<Lamp> Lamp { get; set; }
    }
}
