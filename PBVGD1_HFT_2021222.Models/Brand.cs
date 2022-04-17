using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBVGD1_HFT_2021222.Models
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandId { get; set; }
        
        [Required]
        [StringLength(50)]
        public string BrandName { get; set; }

        [ForeignKey(nameof(Sport))]
        public int SportId { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
