using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Config.Repository.Models
{
    public partial class Role
    {
        public Role()
        {
            User = new HashSet<User>();
        }

        [Key]
        [Column("ID_role")]
        public int IdRole { get; set; }
        [Required]
        [Column("Name_role")]
        [StringLength(250)]
        public string NameRole { get; set; }

        [InverseProperty("IdRoleNavigation")]
        public virtual ICollection<User> User { get; set; }
    }
}
