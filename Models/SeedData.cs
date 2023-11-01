
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MyScriptureJournal_Alma.Data;
using System;
using System.Linq;

namespace MyScriptureJournal_Alma.Models
{
    public class SeedData
    {

        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MyScriptureJournal_AlmaContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<MyScriptureJournal_AlmaContext>>()))
            {
                // Look for any movies.
                if (context.Scripture.Any())
                {
                    return;   // DB has been seeded
                }

                context.Scripture.AddRange(
                    new Scripture
                    {
                        EntryTitle = "Nice scripture",
                        DateAdded = DateTime.Parse("1989-2-12"),
                        Book = "D&C",
                      
                    },

                    new Scripture
                    {
                        EntryTitle = "Happy scripture",
                        DateAdded = DateTime.Parse("2000-6-18"),
                        Book = "Pear of Great Price",

                    },

                    new Scripture
                    {
                        EntryTitle = "Sad scripture",
                        DateAdded = DateTime.Parse("2005-4-12"),
                        Book = "Book of Mormon",

                    },

                    new Scripture
                    {
                        EntryTitle = "Melow scripture",
                        DateAdded = DateTime.Parse("2022-9-19"),
                        Book = "Bible",

                    }
                );
                context.SaveChanges();
            }
        }
    }
}
