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
    
    public partial class SayfaYetki
    {
        public int Id { get; set; }
        public int SayfaId { get; set; }
        public int KulliciId { get; set; }
    
        public virtual kullanici kullanici { get; set; }
        public virtual Sayfa Sayfa { get; set; }
    }
}
