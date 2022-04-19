using PBVGD1_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBVGD1_HFT_2021222.Repository
{
    public class ProductRepository : Repository<Product>, IRepository<Product>
    {
        public ProductRepository(SportDbContext ctx) : base(ctx)
        {
        }

        public override Product Read(int id)
        {
            return ctx.Products.FirstOrDefault(p=>p.ProductId== id);
        }

        public override void Update(Product item)
        {
            var old = Read(item.BrandId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
