using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace MvcTiggy.Models
{
    public static class SeedData
    {

        static List<Member> members = new List<Member>();
        static List<Adventure> adventures = new List<Adventure>();

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MvcAdventureContext(
                serviceProvider.GetRequiredService<DbContextOptions<MvcAdventureContext>>()))
            {

                // If database already contains data, return
                if (context.Adventure.Any() || context.Members.Any())
                {
                    return; // DB has been seeded already
                }

                SeedMembers(context);
                SeedAdventures(context);

                context.AddRange(
                    new AdventureMember { Adventure = adventures[0], Member = members[0] },
                    new AdventureMember { Adventure = adventures[0], Member = members[1] },
                    new AdventureMember { Adventure = adventures[0], Member = members[2] },
                    new AdventureMember { Adventure = adventures[0], Member = members[3] },

                    new AdventureMember { Adventure = adventures[1], Member = members[0] },
                    new AdventureMember { Adventure = adventures[1], Member = members[3] },
                    new AdventureMember { Adventure = adventures[1], Member = members[2] },

                    new AdventureMember { Adventure = adventures[2], Member = members[0] },
                    new AdventureMember { Adventure = adventures[2], Member = members[3] }
                );

                context.SaveChanges();
            }

        }

        private static void SeedMembers(MvcAdventureContext context)
        {
            members.Add(
                new Member
                {
                    ID = 1,
                    FirstName = "Rayo",
                    LastName = "Ogunyinka",
                    About = "Everything beach-related!! Love good food and fun with friends and family",
                    Image = GetImageAsByteArray(@"Resources/rayo.jpg")

                });
            members.Add(new Member
            {
                ID = 2,
                FirstName = "Moyo",
                LastName = "Ogunyinka",
                About = $"Hi there, I'm Moyo, {Environment.NewLine}pharmacist by trade but love to relax and soak in different cultures. Looking forward to partying with you all!",
                Image = GetImageAsByteArray(@"Resources/user.jpg")

            });
            members.Add(new Member
            {
                ID = 3,
                FirstName = "TestMember",
                LastName = "Jones",
                About = $"Haven't been abroad in a few years so very excited to be on here! Best holiday was to Sicily with a bunch of uni mates.{Environment.NewLine}The food was amazing, the beaches incredible and there are one too many stories to share on my next holiday ;)",
                Image = GetImageAsByteArray(@"Resources/user.jpg")

            });
            members.Add(new Member
            {
                ID = 4,
                FirstName = "Gabrielle",
                LastName = "Union",
                About = $"Hi I'm Gabi,{Environment.NewLine}I've been holidaying with Rayo since way back when. We have the best time together, I am looking forward to sightseeing, partying and eating out! I just got married so will have a plus one - my husband Duane, he's fun too.{Environment.NewLine}We look forward to making new friends!",
                Image = GetImageAsByteArray(@"Resources/user.jpg")

            });

            //context.AddRange(members);
        }


        private static void SeedAdventures(MvcAdventureContext context)
        {
            adventures.Add(
                                new Adventure
                                {
                                    Name = "Latin America 2019",
                                    Description = "A tour of the hottest countries in Latin America. We'll start off in Miami, then head over to Columbia, Mexico, Dominican Republic and finish up in Puerto Rico! An Adventure not to be missed.",
                                    EstimatedCost = 2500,
                                    PlannedDate = new DateTime(2019, 01, 23),
                                    Duration = 3,
                                    DurationUnits = Interval.Weeks,
                                    //Members = new List<Member> {
                                    //members[0],
                                    //members[1],
                                    //members[2],
                                    //members[3]},
                                    Image = GetImageAsByteArray(@"Resources/southAmerica.jpg")
                                });

            adventures.Add(new Adventure
            {
                Name = "Ivah's Birthday Paris Trip",
                Description = "Paris is a city with a proud and very ancient history. Originally founded in the third century BC, on an island in the middle of the Seine, it was the capital city of a tribe known as the Parisii, who gave it their name. What better way to celebrate Ivah's birthday than with a trip to this awesome city.",
                EstimatedCost = 300,
                PlannedDate = new DateTime(2018, 10, 23),
                Duration = 4,
                DurationUnits = Interval.Days,
                //Members = new List<Member> {
                //members[0],
                //members[3],
                //members[2],},
                Image = GetImageAsByteArray(@"Resources/southAmerica.jpg")
            });

            adventures.Add(new Adventure
            {
                Name = "Test Adventure",
                Description = "Not sure if it will be fun as there are no details..",
                EstimatedCost = 1000.99M,
                PlannedDate = new DateTime(2019, 11, 2),
                Duration = 1,
                DurationUnits = Interval.Weeks,
                //Members = new List<Member> { 
                //members[2],
                //members[0]},
                Image = GetImageAsByteArray(@"Resources/southAmerica.jpg")
            });

            context.Adventure.AddRange(adventures);
        }

        private static byte[] GetImageAsByteArray(string path)
        {
            try
            {
                return System.IO.File.ReadAllBytes(path);
            }
            catch (Exception e)
            {
                return null;
            }
        }
       
    }
}
