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
    
    public partial class Ohlad_water
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Ohlad_water()
        {
            this.Sborka = new HashSet<Sborka>();
        }
    
        public int ID_ohlad_water { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public int Size { get; set; }
        public int TDP { get; set; }
        public string Socket { get; set; }
        public decimal Cost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sborka> Sborka { get; set; }
    }
}
