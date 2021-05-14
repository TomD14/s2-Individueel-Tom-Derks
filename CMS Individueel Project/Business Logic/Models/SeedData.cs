using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using CMS_Individueel_Project.Data;
using CMS_Individueel_Project.Data.Models;

namespace CMS_Individueel_Project.Models
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
                        Prijs = 5,
                        Aantal = 7
                    },

                    new Lamp
                    {
                        Model = "Lamp seed 2",
                        Watt = 70,
                        Kleur = 3500,
                        Prijs = 8,
                        Aantal = 12
                    },

                    new Lamp
                    {
                        Model = "Lamp seed 3",
                        Watt = 30,
                        Kleur = 5000,
                        Prijs = 6,
                        Aantal = 56
                    },

                    new Lamp
                    {
                        Model = "Lamp seed 4",
                        Watt = 50,
                        Kleur = 4000,
                        Prijs = 3,
                        Aantal = 9
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
