using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TestAppMVC.Models;

namespace TestAppMVC.Data
{
    public class TestAppMVCContext : DbContext
    {
        public TestAppMVCContext (DbContextOptions<TestAppMVCContext> options)
            : base(options)
        {
        }

        public DbSet<TestAppMVC.Models.Movie> Movie { get; set; }
    }
}
