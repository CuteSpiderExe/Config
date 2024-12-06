using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Config.Repository.Models
{
    public partial class Processor
    {
        public Processor()
        {
            Sborka = new HashSet<Sborka>();
        }

        [Key]
        [Column("ID_processor")]
        public int IdProcessor { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        [Required]
        [StringLength(50)]
        public string Socket { get; set; }
        [Required]
        [StringLength(50)]
        public string Ddr { get; set; }
        [Column("TDP")]
        public int Tdp { get; set; }
        public int Core { get; set; }
        [Column("Core_shast")]
        public int CoreShast { get; set; }
        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        [InverseProperty("IdProcessorNavigation")]
        public virtual ICollection<Sborka> Sborka { get; set; }
    }
}
