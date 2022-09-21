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
    
    public partial class Galeri
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Galeri()
        {
            this.GaleriFoto = new HashSet<GaleriFoto>();
        }
    
        public int Id { get; set; }
        public Nullable<int> TurID { get; set; }
        public Nullable<int> KateID { get; set; }
        public string BaslikTR { get; set; }
        public Nullable<System.DateTime> Tarih { get; set; }
        public string DosyaURL { get; set; }
        public string KapakURL { get; set; }
        public string Link { get; set; }
        public Nullable<bool> Sil { get; set; }
        public Nullable<int> TolId { get; set; }
    
        public virtual FotoKategori FotoKategori { get; set; }
        public virtual GaleriTur GaleriTur { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GaleriFoto> GaleriFoto { get; set; }
    }
}