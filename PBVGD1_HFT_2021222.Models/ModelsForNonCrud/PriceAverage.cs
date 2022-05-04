using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBVGD1_HFT_2021222.Models
{
    public class PriceAverage
    {
        public double AveragePrice { get; set; }
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            PriceAverage b = obj as PriceAverage;
            if (b == null)
                return false;
            else
            {
                return AveragePrice == b.AveragePrice
                    && Name == b.Name;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.AveragePrice, this.Name);
        }
    }
}
