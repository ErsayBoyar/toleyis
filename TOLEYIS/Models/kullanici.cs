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
    
    public partial class kullanici
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public kullanici()
        {
            this.SayfaYetki = new HashSet<SayfaYetki>();
        }
    
        public int Id { get; set; }
        public string AdSoyad { get; set; }
        public string Telefon { get; set; }
        public string Sifre { get; set; }
        public string Email { get; set; }
        public Nullable<int> RoleId { get; set; }
        public string ResetSifre { get; set; }
        public Nullable<bool> Sil { get; set; }
    
        public virtual Roles Roles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SayfaYetki> SayfaYetki { get; set; }
    }
}