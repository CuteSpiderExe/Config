//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Config.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Videocard
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Videocard()
        {
            this.Sborka = new HashSet<Sborka>();
        }
    
        public int ID_videocard { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int Video_size { get; set; }
        public string GDDR { get; set; }
        public int Memory { get; set; }
        public int Power { get; set; }
        public decimal Cost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sborka> Sborka { get; set; }
    }
}
