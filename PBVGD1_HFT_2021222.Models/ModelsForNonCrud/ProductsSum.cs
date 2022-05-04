using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBVGD1_HFT_2021222.Models
{
    public class ProductsSum
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public override bool Equals(object obj)
        {
            ProductsSum b = obj as ProductsSum;
            if (b == null)
                return false;
            else
            {
                return b.Price == Price
                    && b.Name == Name;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.Price, this.Name);
        }

    }
}
