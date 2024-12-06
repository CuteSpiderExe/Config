using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Config.Repository.Models
{
    public partial class Motherboard
    {
        public Motherboard()
        {
            Sborka = new HashSet<Sborka>();
        }

        [Key]
        [Column("ID_Motherboard")]
        public int IdMotherboard { get; set; }
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
        [Column("DDR")]
        [StringLength(50)]
        public string Ddr { get; set; }
        [Required]
        [StringLength(50)]
        public string Standart { get; set; }
        [Required]
        [StringLength(50)]
        public string Chipset { get; set; }
        [Column("DDR_kol")]
        public int DdrKol { get; set; }
        [Required]
        [Column("PCI")]
        [StringLength(10)]
        public string Pci { get; set; }
        [Required]
        [StringLength(50)]
        public string M2 { get; set; }
        [Required]
        [StringLength(50)]
        public string Sata { get; set; }
        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        [InverseProperty("IdMotherboardNavigation")]
        public virtual ICollection<Sborka> Sborka { get; set; }
    }
}
