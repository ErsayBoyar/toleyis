//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TOLEYIS.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class iletisimTur
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public iletisimTur()
        {
            this.Iletisim = new HashSet<Iletisim>();
        }
    
        public int Id { get; set; }
        public string AdTR { get; set; }
        public Nullable<bool> Sil { get; set; }
        public string AdEN { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Iletisim> Iletisim { get; set; }
    }
}
