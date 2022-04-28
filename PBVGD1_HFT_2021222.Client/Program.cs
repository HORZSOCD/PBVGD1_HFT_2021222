using PBVGD1_HFT_2021222.Logic;
using PBVGD1_HFT_2021222.Models;
using PBVGD1_HFT_2021222.Repository;
using System;
using System.Linq;

namespace PBVGD1_HFT_2021222.Client
{
    public class Program
    {
        static void Main(string[] args)
        {
            var ctx = new SportDbContext();

            IRepository<Sport> sportRepo = new SportRepository(ctx);
            IRepository<Brand> brandRepo = new BrandRepository(ctx);
            IRepository<Product> productRepo = new ProductRepository(ctx);

            SportLogic sportLogic = new SportLogic(sportRepo);
            BrandLogic brandLogic = new BrandLogic(brandRepo);
            ProductLogic productLogic = new ProductLogic(productRepo);

            
            
            
            
        }
    }
}
