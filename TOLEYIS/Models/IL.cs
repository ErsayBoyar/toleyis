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
    
    public partial class IL
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public IL()
        {
            this.AnlasmaliKurumlar = new HashSet<AnlasmaliKurumlar>();
            this.ILce = new HashSet<ILce>();
            this.Iletisim = new HashSet<Iletisim>();
            this.ILTemsilcileri = new HashSet<ILTemsilcileri>();
            this.Orgutlu = new HashSet<Orgutlu>();
            this.Subeler1 = new HashSet<Subeler>();
        }
    
        public int Id { get; set; }
        public string Ad { get; set; }
        public Nullable<int> SubeID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AnlasmaliKurumlar> AnlasmaliKurumlar { get; set; }
        public virtual Subeler Subeler { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ILce> ILce { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Iletisim> Iletisim { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ILTemsilcileri> ILTemsilcileri { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orgutlu> Orgutlu { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Subeler> Subeler1 { get; set; }
    }
}
