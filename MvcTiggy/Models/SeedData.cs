using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MvcTiggy.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcAdventureContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcAdventureContext>>()))
            {

                // If database already contains data, return
                if (context.Adventure.Any())
                {
                    return; // DB has been seeded already
                }

                context.Adventure.AddRange(

                    new Adventure
                    {
                        Name = "Latin America 2019",
                        Description = "A tour of the hottest countries in Latin America. We'll start off in Miami, then head over to Columbia, Mexico, Dominican Republic and finish up in Puerto Rico! An Adventure not to be missed.",
                        EstimatedCost = 2500,
                        PlannedDate = new DateTime(2019, 01, 23)
                    },

                    new Adventure
                    {
                        Name = "Ivah's Birthday Paris Trip",
                        Description = "Paris is a city with a proud and very ancient history. Originally founded in the third century BC, on an island in the middle of the Seine, it was the capital city of a tribe known as the Parisii, who gave it their name. What better way to celebrate Ivah's birthday than with a trip to this awesome city.",
                        EstimatedCost = 300,
                        PlannedDate = new DateTime(2018, 10, 23)
                    },

                    new Adventure
                    {
                        Name = "Test Adventure",
                        Description = "Not sure if it will be fun as there are no details..",
                        EstimatedCost = 1000.99M,
                        PlannedDate = new DateTime(2019, 11, 2)
                    }

                );

                context.SaveChanges();
            }

        }
    }
}
