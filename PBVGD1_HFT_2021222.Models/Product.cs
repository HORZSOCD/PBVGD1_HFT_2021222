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
        public int ProductNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string ProductName { get; set; }
        public int Price { get; set; }

        [ForeignKey(nameof(Brand))]
        public int BrandId { get; set; }
    }
}
