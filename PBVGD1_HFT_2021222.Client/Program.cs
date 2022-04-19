using PBVGD1_HFT_2021222.Models;
using PBVGD1_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PBVGD1_HFT_2021222.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            IRepository<Sport> repo = new SportRepository(new SportDbContext());

            Sport newSport = new Sport()
            {
                SportName = "Soccer"
                
            };

            repo.Create(newSport);
            
            var items = repo.ReadAll().ToArray();
            foreach (var sports in items)
            {
                Console.WriteLine(sports.SportName + ":\n\t");
                if (sports.Brands!=null)
                    foreach (var brands in sports.Brands)
                    {
                        Console.WriteLine("\t" + brands.BrandName + ":\n");
                        if (brands.Products!= null)
                            foreach (var products in brands.Products)
                            {
                                Console.WriteLine("\t\t" + products.ProductName + "\n");
                            }
                    }
            }
            Console.ReadKey();
        }
    }
}
