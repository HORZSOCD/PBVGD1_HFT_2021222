using PBVGD1_HFT_2021222.Models;
using PBVGD1_HFT_2021222.Repository;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace PBVGD1_HFT_2021222.Logic
{
    public class BrandLogic : IBrandLogic
    {
        IRepository<Brand> brandRepo;

        public BrandLogic(IRepository<Brand> brandRepo)
        {
            this.brandRepo = brandRepo;
        }
        //Crud methods
        public void Create(Brand item)
        {
            if (item.BrandName.Length < 3)
                throw new ArgumentException("Sport name must be at least 3 characher long.");
            this.brandRepo.Create(item);
        }

        public void Delete(int id)
        {
            this.brandRepo.Delete(id);
        }

        public Brand Read(int id)
        {
            var brand = this.brandRepo.Read(id);
            if (brand == null)
                throw new ArgumentException("Brand does not exist.");
            return brand;
        }

        public IEnumerable<Brand> ReadAll()
        {
            return this.brandRepo.ReadAll();
        }

        public void Update(Brand item)
        {
            this.brandRepo.Update(item);
        }

        //Non-crud methods

        public IEnumerable<AverageBrand> AverageProductPerBrand()
        {
            return from b in this.brandRepo.ReadAll()
                   group b by b.BrandName into g
                   select new AverageBrand
                   {
                       Name = g.Key,
                       Proucts = g.Sum(a => a.Products.Count)
                   };
        }

        public IEnumerable<ProductsSum> PruductsUnder10000Huf()
        {
            return (from x in this.brandRepo.ReadAll()
                   from product in x.Products
                   where product.Price < 10000
                   group product by product.ProductName into g
                   select new ProductsSum
                   {
                       Name = g.Key,
                       Price = g.Select(x => x.Price).FirstOrDefault()
                   }).OrderBy(x => x.Price);
            
        }
    }
}