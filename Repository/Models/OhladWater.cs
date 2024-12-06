using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Config.Repository.Models
{
    [Table("Ohlad_water")]
    public partial class OhladWater
    {
        public OhladWater()
        {
            Sborka = new HashSet<Sborka>();
        }

        [Key]
        [Column("ID_ohlad_water")]
        public int IdOhladWater { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        public int Size { get; set; }
        [Column("TDP")]
        public int Tdp { get; set; }
        [Required]
        [StringLength(50)]
        public string Socket { get; set; }
        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        [InverseProperty("IdOhladWaterNavigation")]
        public virtual ICollection<Sborka> Sborka { get; set; }
    }
}
