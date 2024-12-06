using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Config.Repository.Models
{
    public partial class User
    {
        public User()
        {
            IdRole = 1;
            Sborka = new HashSet<Sborka>();
        }

        [Key]
        [Column("ID_user")]
        public int IdUser { get; set; }
        [Required]
        [StringLength(250)]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }
        [Column("ID_role")]
        public int IdRole { get; set; }

        [ForeignKey(nameof(IdRole))]
        [InverseProperty(nameof(Role.User))]
        public virtual Role IdRoleNavigation { get; set; }
        [InverseProperty("IdUserNavigation")]
        public virtual ICollection<Sborka> Sborka { get; set; }

                 
    }
}
