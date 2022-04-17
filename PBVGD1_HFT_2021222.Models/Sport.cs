using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PBVGD1_HFT_2021222.Models
{
    public class Sport
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SportId { get; set; }

        [Required]
        [StringLength(50)]
        public string SportName { get; set; }

        public virtual ICollection<Brand> Brands { get; set; }

        
    }
}
