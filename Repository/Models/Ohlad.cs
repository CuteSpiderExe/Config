using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Config.Repository.Models
{
    public partial class Ohlad
    {
        public Ohlad()
        {
            Sborka = new HashSet<Sborka>();
        }

        [Key]
        [Column("ID_ohlad")]
        public int IdOhlad { get; set; }
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

        [InverseProperty("IdOhladNavigation")]
        public virtual ICollection<Sborka> Sborka { get; set; }
    }
}
