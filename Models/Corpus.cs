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
    
    public partial class Corpus
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Corpus()
        {
            this.Sborka = new HashSet<Sborka>();
        }
    
        public int ID_corpus { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public string Size { get; set; }
        public string Mother_size { get; set; }
        public string Video_size { get; set; }
        public string PowerBlock_size { get; set; }
        public int CPU_fun_size { get; set; }
        public int CPU_water_size { get; set; }
        public int Sata_kol { get; set; }
        public decimal Cost { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sborka> Sborka { get; set; }
    }
}
