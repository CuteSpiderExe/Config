using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Config.Repository.Models
{
    [Table("DDR")]
    public partial class Ddr
    {
        public Ddr()
        {
            Sborka = new HashSet<Sborka>();
        }

        [Key]
        [Column("ID_ddr")]
        public int IdDdr { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        [Required]
        [StringLength(50)]
        public string Type { get; set; }
        public int Chast { get; set; }
        public int Memory { get; set; }
        public int Kol { get; set; }
        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        [InverseProperty("IdDdrNavigation")]
        public virtual ICollection<Sborka> Sborka { get; set; }
    }
}
