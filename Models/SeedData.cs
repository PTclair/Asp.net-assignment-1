using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PranavSmartphones.Data;

namespace PranavSmartphones.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ApplicationDbContext>>()))
            {
                // Look for any movies.
                if (context.Smartphones.Any())
                {
                    return;   // DB has been seeded
                }

                context.Smartphones.AddRange(
                    new Smartphones
                    {
                        Name = "Sumsung M40",
                        Model = "M40",
                        Stroge = 256M,
                        Price = 240M
                    },

                    new Smartphones
                    {
                        Name = "Sumsung M50",
                        Model = "M50",
                        Stroge = 256M,
                        Price = 250M
                    },

                    new Smartphones
                    {
                        Name = "Sumsung M60",
                        Model = "M60",
                        Stroge = 256M,
                        Price = 450M
                    },

                    new Smartphones
                    {
                        Name = "Sumsung M31",
                        Model = "M31",
                        Stroge = 256M,
                        Price = 300M
                    },
                    new Smartphones
                    {
                        Name = "Sumsung M41",
                        Model = "M41",
                        Stroge = 256M,
                        Price = 450M
                    },
                    new Smartphones
                    {
                        Name = "Sumsung M21",
                        Model = "M21",
                        Stroge = 256M,
                        Price = 250M
                    },
                    new Smartphones
                    {
                        Name = "Sumsung M20",
                        Model = "M20",
                        Stroge = 256M,
                        Price = 300M
                    },
                    new Smartphones
                    {
                        Name = "Sumsung S20",
                        Model = "S20",
                        Stroge = 256M,
                        Price = 500M
                    },
                    new Smartphones
                    {
                        Name = "Sumsung S10",
                        Model = "S10",
                        Stroge = 256M,
                        Price = 700M
                    }
                    
                );
                context.SaveChanges();


            }
        }
            
    }
}
