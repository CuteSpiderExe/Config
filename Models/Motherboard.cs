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
    
    public partial class Motherboard
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Motherboard()
        {
            this.Sborka = new HashSet<Sborka>();
        }
    
        public int ID_Motherboard { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string Socket { get; set; }
        public string DDR { get; set; }
        public string Standart { get; set; }
        public string Chipset { get; set; }
        public int DDR_kol { get; set; }
        public string PCI { get; set; }
        public string M2 { get; set; }
        public string Sata { get; set; }
        public decimal Cost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sborka> Sborka { get; set; }
    }
}