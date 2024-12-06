using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Config.Repository.Models
{
    public partial class Zakaz
    {
        [Key]
        [Column("ID_zakaz")]
        public int IdZakaz { get; set; }
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }
        [Required]
        [StringLength(250)]
        public string Adress { get; set; }
        [Required]
        [StringLength(50)]
        public string Status { get; set; }
        [Column("ID_sborka")]
        public int IdSborka { get; set; }

        [ForeignKey(nameof(IdSborka))]
        [InverseProperty(nameof(Sborka.Zakaz))]
        public virtual Sborka IdSborkaNavigation { get; set; }
    }
}
