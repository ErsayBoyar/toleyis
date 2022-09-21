using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOLEYIS.Models;
using PagedList;
using PagedList.Mvc;


namespace TOLEYIS.Controllers
{
    public class HaberlerController : Controller
    {
        TOLEYIS_Entities db = new TOLEYIS_Entities();
        ViewModel model = new ViewModel();
        Manager manager = new Manager();

        // GET: Haberler
        public ActionResult Haber(int? id,int? Kategori, int? Yillar, int sayfa = 1)
        {            
            if (id != null)
             {
                var ktgr = db.HaberKategori.Where(x => x.Aktif != false);
                ViewBag.Kategori = new SelectList(ktgr, "Id", "Ad", id, "Kategori");
            }
            else
            {
                var ktgr = db.HaberKategori.Where(x => x.Aktif != false);
                ViewBag.Kategori = new SelectList(ktgr, "Id", "Ad", "Kategori");
            }

            ViewBag.dosyayolu = manager.GetAdminIPAndPort();

            var yil = db.Haber.OrderByDescending(x => x.Tarih.Value.Year).Select(x => x.Tarih.Value.Year).ToList();
            var yil2 = yil.Distinct().ToList();
            ViewBag.Yillar = new SelectList(yil2);

            //kategori seçildi, yıl seçildi
            if (id != null && Yillar != null)
            {
                //1(tümü) haricinde seçildi
                if (id != 1)
                {
                    //bool secilenktgr = Convert.ToBoolean(Kategori);
                    var habersorgu = db.Haber.Where(x => x.Sil != true && x.TurID == 1 && x.KategoriID == Kategori && x.Tarih.Value.Year == Yillar && (x.BitTarih > DateTime.Today || x.BitTarih == null)).OrderByDescending(x => x.Id).ToList().ToPagedList(sayfa, 8);
                    return View(habersorgu);
                }
                //1(tümü) seçildi 
                else
                {
                    var habersorgu = db.Haber.Where(x => x.Sil != true && x.Tarih.Value.Year == Yillar && (x.BitTarih > DateTime.Today || x.BitTarih == null)).OrderByDescending(x => x.Id).ToList().ToPagedList(sayfa, 8);
                    return View(habersorgu);
                }
            }
            //kategori seçildi, yıl seçilmedi
            else if (id != null && Yillar == null)
            {
                //1(tümü) haricinde seçildi
                if (id != 1)
                {
                    //bool ulusal = Convert.ToBoolean(Kategori);
                    var habersorgu = db.Haber.Where(x => x.Sil != true && x.TurID == 1 && x.KategoriID == id && (x.BitTarih > DateTime.Today || x.BitTarih == null)).OrderByDescending(x => x.Id).ToList().ToPagedList(sayfa, 8);
                    return View(habersorgu);
                }
                //1(tümü) seçildi 
                else
                {
                    var habersorgu = db.Haber.Where(x => x.Sil != true && (x.BitTarih > DateTime.Today || x.BitTarih == null)).OrderByDescending(x => x.Id).ToList().ToPagedList(sayfa, 8);
                    return View(habersorgu);
                }
            }
            //kategori seçilmedi, yıl seçildi
            else if (Kategori == null && Yillar != null)
            {
                var habersorgu = db.Haber.Where(x => x.Sil != true && x.Tarih.Value.Year == Yillar && (x.BitTarih > DateTime.Today || x.BitTarih == null)).OrderByDescending(x => x.Id).ToList().ToPagedList(sayfa, 8);
                return View(habersorgu);
            }
            else
            {
                var habersorgu = db.Haber.Where(x => x.Sil != true && (x.BitTarih > DateTime.Today || x.BitTarih == null)).OrderByDescending(x => x.Id).ToList().ToPagedList(sayfa, 8);
                return View(habersorgu);
            }
        }

        public ActionResult HaberDetay(int? id)
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();

            model.Habers = db.Haber.Where(x => x.Id == id && x.Sil != true).ToList();
            var haber = (from i in db.Haber
                         where i.Sil != true && i.Id==id
                         select new HabGal
                         {
                             Ad = i.Kapak
                         }).ToList();
            var galeri = (from i in db.HaberGaleri
                             where i.Sil != true && i.HaberID == id
                          select new HabGal
                             {
                                 Ad = i.Ad,                                 
                             }).ToList();
            haber.AddRange(galeri);
            ViewData["slider"] = haber;
            ViewBag.gorselsayi = haber.Count();
            return View(model);
        }
        public ActionResult Sidebar()
        {
            var sorgu = db.Haber.Where(x => x.Sil != true).OrderByDescending(x => x.Tarih).Take(5).ToList();
            return View(sorgu);
        }
        
    }
}