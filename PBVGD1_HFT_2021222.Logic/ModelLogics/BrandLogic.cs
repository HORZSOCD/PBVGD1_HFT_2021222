using PBVGD1_HFT_2021222.Models;
using PBVGD1_HFT_2021222.Repository;
using System;
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
        public int ProductSum()
        {
            return this.brandRepo
                .ReadAll()
                .Sum(b => b.Products.Count);
        }

        public double AverageProductPerBrand()
        {
            return this.brandRepo
                .ReadAll()
                .Select(b => b.Products.Count)
                .Average();
        }





    }
}