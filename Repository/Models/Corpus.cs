using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Config.Repository.Models
{
    public partial class Corpus
    {
        public Corpus()
        {
            Sborka = new HashSet<Sborka>();
        }

        [Key]
        [Column("ID_corpus")]
        public int IdCorpus { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [Required]
        [Column(TypeName = "image")]
        public byte[] Image { get; set; }
        [Required]
        [StringLength(50)]
        public string Size { get; set; }
        [Required]
        [Column("Mother_size")]
        [StringLength(50)]
        public string MotherSize { get; set; }
        [Required]
        [Column("Video_size")]
        [StringLength(50)]
        public string VideoSize { get; set; }
        [Required]
        [Column("PowerBlock_size")]
        [StringLength(50)]
        public string PowerBlockSize { get; set; }
        [Column("CPU_fun_size")]
        public int CpuFunSize { get; set; }
        [Column("CPU_water_size")]
        public int CpuWaterSize { get; set; }
        [Column("Sata_kol")]
        public int SataKol { get; set; }
        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        [InverseProperty("IdCorpusNavigation")]
        public virtual ICollection<Sborka> Sborka { get; set; }
    }
}
