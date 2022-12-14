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
    
    public partial class Haber
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Haber()
        {
            this.HaberGaleri = new HashSet<HaberGaleri>();
        }
    
        public int Id { get; set; }
        public string BaslikTR { get; set; }
        public string BaslikEN { get; set; }
        public string texteditorTR { get; set; }
        public string texteditorEN { get; set; }
        public string Kapak { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public string PDF { get; set; }
        public Nullable<int> TurID { get; set; }
        public Nullable<int> KategoriID { get; set; }
        public Nullable<System.DateTime> BitTarih { get; set; }
        public Nullable<bool> Ulusal { get; set; }
        public Nullable<bool> Sil { get; set; }
        public Nullable<int> TolId { get; set; }
        public Nullable<bool> Banner { get; set; }
    
        public virtual HaberKategori HaberKategori { get; set; }
        public virtual HaberTur HaberTur { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<HaberGaleri> HaberGaleri { get; set; }
    }
}
