using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Config.Repository.Models
{
    public partial class Sborka
    {
        public Sborka()
        {
            Zakaz = new HashSet<Zakaz>();
        }

        [Key]
        [Column("ID_sborka")]
        public int IdSborka { get; set; }
        [Required]
        [StringLength(250)]
        public string Name { get; set; }
        [Column("ID_processor")]
        public int? IdProcessor { get; set; }
        [Column("ID_Motherboard")]
        public int? IdMotherboard { get; set; }
        [Column("ID_corpus")]
        public int? IdCorpus { get; set; }
        [Column("ID_ohlad")]
        public int? IdOhlad { get; set; }
        [Column("ID_ohlad_water")]
        public int? IdOhladWater { get; set; }
        [Column("ID_ddr")]
        public int? IdDdr { get; set; }
        [Column("ID_memory")]
        public int? IdMemory { get; set; }
        [Column("ID_powerblock")]
        public int? IdPowerblock { get; set; }
        [Column("ID_User")]
        public int? IdUser { get; set; }
        [Column("ID_videocard")]
        public int? IdVideocard { get; set; }
        public int Quantity { get; set; }
        [Column(TypeName = "money")]
        public decimal Cost { get; set; }

        public bool? ZakazSborki { get; set; }

        [ForeignKey(nameof(IdCorpus))]
        [InverseProperty(nameof(Corpus.Sborka))]
        public virtual Corpus IdCorpusNavigation { get; set; }
        [ForeignKey(nameof(IdDdr))]
        [InverseProperty(nameof(Ddr.Sborka))]
        public virtual Ddr IdDdrNavigation { get; set; }
        [ForeignKey(nameof(IdMemory))]
        [InverseProperty(nameof(Memory.Sborka))]
        public virtual Memory IdMemoryNavigation { get; set; }
        [ForeignKey(nameof(IdMotherboard))]
        [InverseProperty(nameof(Motherboard.Sborka))]
        public virtual Motherboard IdMotherboardNavigation { get; set; }
        [ForeignKey(nameof(IdOhlad))]
        [InverseProperty(nameof(Ohlad.Sborka))]
        public virtual Ohlad IdOhladNavigation { get; set; }
        [ForeignKey(nameof(IdOhladWater))]
        [InverseProperty(nameof(OhladWater.Sborka))]
        public virtual OhladWater IdOhladWaterNavigation { get; set; }
        [ForeignKey(nameof(IdPowerblock))]
        [InverseProperty(nameof(PowerBlock.Sborka))]
        public virtual PowerBlock IdPowerblockNavigation { get; set; }
        [ForeignKey(nameof(IdProcessor))]
        [InverseProperty(nameof(Processor.Sborka))]
        public virtual Processor IdProcessorNavigation { get; set; }
        [ForeignKey(nameof(IdUser))]
        [InverseProperty(nameof(User.Sborka))]
        public virtual User IdUserNavigation { get; set; }
        [ForeignKey(nameof(IdVideocard))]
        [InverseProperty(nameof(Videocard.Sborka))]
        public virtual Videocard IdVideocardNavigation { get; set; }
        [InverseProperty("IdSborkaNavigation")]
        public virtual ICollection<Zakaz> Zakaz { get; set; }
    }
}
