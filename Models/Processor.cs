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
    
    public partial class Processor
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Processor()
        {
            this.Sborka = new HashSet<Sborka>();
        }
    
        public int ID_processor { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string Socket { get; set; }
        public string Ddr { get; set; }
        public int TDP { get; set; }
        public int Core { get; set; }
        public int Core_shast { get; set; }
        public decimal Cost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sborka> Sborka { get; set; }
    }
}
