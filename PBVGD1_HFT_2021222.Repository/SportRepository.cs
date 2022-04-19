using PBVGD1_HFT_2021222.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBVGD1_HFT_2021222.Repository
{
    public class SportRepository : Repository<Sport>, IRepository<Sport>
    {
        public SportRepository(SportDbContext ctx) : base(ctx)
        {
        }

        public override Sport Read(int id)
        {
            return ctx.Sports.FirstOrDefault(s=>s.SportId == id);
        }

        public override void Update(Sport item)
        {
            var old = Read(item.SportId);
            foreach (var prop in old.GetType().GetProperties())
            {
                prop.SetValue(old, prop.GetValue(item));
            }
            ctx.SaveChanges();
        }
    }
}
