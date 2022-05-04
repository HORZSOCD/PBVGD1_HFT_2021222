using PBVGD1_HFT_2021222.Models;
using PBVGD1_HFT_2021222.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PBVGD1_HFT_2021222.Logic
{
    public class ProductLogic:IProductLogic
    {
        IRepository<Product> productRepo;

        public ProductLogic(IRepository<Product> productRepo)
        {
            this.productRepo = productRepo;
        }

        //Crud methods
        public void Create(Product item)
        {
            if (item.ProductName.Length < 3)
                throw new ArgumentException("Product name must be at least 3 characher long.");
            this.productRepo.Create(item);
        }

        public void Delete(int id)
        {
            this.productRepo.Delete(id);
        }

        public Product Read(int id)
        {
            var product = this.productRepo.Read(id);
            if (product == null)
                throw new ArgumentException("Product does not exist.");
            return product;
        }

        public IEnumerable<Product> ReadAll()
        {
            return this.productRepo.ReadAll();
        }

        public void Update(Product item)
        {
            this.productRepo.Update(item);
        }



        //Non-crud methods
        public IEnumerable<PriceAverage> AveragePricePerBrand()
        {

            return from b in this.productRepo.ReadAll()
                   group b by b.Brand.BrandName into g
                   select new PriceAverage
                   {
                       Name = g.Key,
                       AveragePrice = g.Average(p => p.Price)
                   };

        }

        

        public IEnumerable<Product> ProductsInOrder()
        {

           

            return from b in this.productRepo.ReadAll()
                   orderby b.ProductName
                   group b by b.ProductName into g 
                   select new Product
                   {
                       ProductName = g.Key
                   };
            
        }





    }
}