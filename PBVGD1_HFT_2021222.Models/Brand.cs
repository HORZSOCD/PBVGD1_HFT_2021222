using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
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

        public int SportId { get; set; }
        public virtual Sport Sport { get; set; }

        [JsonIgnore]
        public virtual ICollection<Product> Products { get; set; }

        
    }
}
