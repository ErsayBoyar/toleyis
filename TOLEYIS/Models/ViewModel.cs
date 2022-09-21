using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TOLEYIS.Models
{
    public class ViewModel
    {
        public List<Haber> Sliders { get; set; }
        public List<Haber> Habers { get; set; }
        public List<HaberGaleri> HaberGaleris { get; set; }
        public List<Haber> Duyurus { get; set; }
        public List<Galeri> Videos { get; set; }
        public List<Galeri> Fotos { get; set; }
        public List<Pratik> Pratiks { get; set; }
        public List<PratikDosya> PratikDosyas { get; set; }
        public List<PratikBilgiler> PratikBilgilers { get; set; }
        public List<GenelMerkez> GenelMerkezs { get; set; }
        public List<Yonetim> Yonetims { get; set; }
        public List<Subeler> Subelers { get; set; }
        public List<SubeTemsilci> SubeTemsilcis { get; set; }
        public List<SubeTemsilci> SubeTemsilciss { get; set; }
        public List<ILTemsilcileri> ILTemsilcileris { get; set; }
        public List<Orgutlu> Orgutlus { get; set; }
        public List<AnlasmaliKurumlar> AnlasmaliKurumlars { get; set; }
        public List<Iletisim> Iletisims { get; set; }
        public List<UstSlider> UstSliders { get; set; }
        public List<AltSlider> AltSliders { get; set; }
        public List<TefeTufe> TefeTufes { get; set; }
        public List<TefeTufeDosya> TefeTufeDosyas { get; set; }
        public List<Ay> Ays { get; set; }
        public List<Yil> Yils { get; set; }
        public List<Arsiv> Arsivs { get; set; }
        public List<ArsivGaleri> ArsivGaleris { get; set; }
    }
}