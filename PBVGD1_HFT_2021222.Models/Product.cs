using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBVGD1_HFT_2021222.Models
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }
        public int Price { get; set; }

        public virtual Brand Brand { get; set; }
        public int BrandId { get; set; }

        public override bool Equals(object obj)
        {
            Product b = obj as Product;
            if (b == null)
                return false;
            else
            {
                return ProductName == b.ProductName;
            }
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.ProductName);
        }

    }
}
