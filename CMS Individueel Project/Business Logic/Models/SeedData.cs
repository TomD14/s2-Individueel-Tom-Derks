using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Business_Logic.Data;

namespace Business_Logic.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new CMSContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<CMSContext>>()))
            {
                // Look for any movies.
                if (context.Lamp.Any())
                {
                    return;   // DB has been seeded
                }

                context.Lamp.AddRange(
                    new Lamp
                    {
                        Model = "Lamp seed 1",
                        Watt = 60,
                        Kleur = 3000,
                        Aantal = 7
                    },

                    new Lamp
                    {
                        Model = "Lamp seed 2",
                        Watt = 70,
                        Kleur = 3500,
                        Aantal = 12
                    },

                    new Lamp
                    {
                        Model = "Lamp seed 3",
                        Watt = 30,
                        Kleur = 5000,
                        Aantal = 56
                    },

                    new Lamp
                    {
                        Model = "Lamp seed 4",
                        Watt = 50,
                        Kleur = 4000,
                        Aantal = 9
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
