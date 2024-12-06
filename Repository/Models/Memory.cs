using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Config.Repository.Models
{
    public partial class Memory
    {
        public Memory()
        {
            Sborka = new HashSet<Sborka>();
        }

        [Key]
        [Column("ID_memory")]
        public int IdMemory { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        [Required]
        [StringLength(50)]
        public string Interface { get; set; }
        [Column("Memory_size")]
        public int MemorySize { get; set; }
        [Column("Speed_zap")]
        public int SpeedZap { get; set; }
        [Column("Speed_chten")]
        public int SpeedChten { get; set; }
        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        [InverseProperty("IdMemoryNavigation")]
        public virtual ICollection<Sborka> Sborka { get; set; }
    }
}
