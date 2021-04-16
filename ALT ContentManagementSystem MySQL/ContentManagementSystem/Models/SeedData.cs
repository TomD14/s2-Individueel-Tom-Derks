using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ContentManagementSystem.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ContentManagementSystemDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ContentManagementSystemDbContext>>()))
            {
                // Look for any movies.
                if (context.Lamp.Any())
                {
                    return;   // DB has been seeded
                }

                context.Lamp.AddRange(
                    new Lamp
                    {
                        Model = "LampSeeded1",
                        Watt = 3,
                        Kleur = 50,
                        Aantal = 8
                    },

                    new Lamp
                    {
                        Model = "LampSeeded2",
                        Watt = 3,
                        Kleur = 3,
                        Aantal = 6
                    }

                );
                context.SaveChanges();
            }
        }
    }
}
