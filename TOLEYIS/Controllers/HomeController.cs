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

    public class HomeController : Controller
    {

        TOLEYIS_Entities db = new TOLEYIS_Entities();
        ViewModel model = new ViewModel();
        Manager manager = new Manager();


        // GET: AnaSayfa
        public ActionResult Index()
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();

            var ilsayi = db.IL.Count();
            ViewBag.il = ilsayi;
            var subesayi = db.Subeler.Count();
            ViewBag.sube = subesayi;
            var uyesayi = db.UyeSayisiManuel.First();
            ViewBag.uye = uyesayi.UyeSayisi;
            if (uyesayi.Metin == null)
            {
                ViewBag.metin = "-";
            }
            else
            {
                ViewBag.metin = uyesayi.Metin;
            }

            model.Habers = db.Haber.Where(x => x.Sil != true && x.TurID == 1).OrderByDescending(x => x.Id).Take(7).ToList();
            model.Duyurus = db.Haber.Where(x => x.Sil != true && x.TurID == 2).OrderByDescending(x => x.Id).Take(5).ToList();
            model.Videos = db.Galeri.Where(x => x.Sil != true && x.TurID == 2).OrderByDescending(x => x.Id).Take(5).ToList();
            model.AltSliders = db.AltSlider.Where(x => x.Sil != true).OrderByDescending(x => x.Id).Take(3).ToList();

            var haber = (from i in db.Haber
                         where i.Sil != true && i.Banner == true
                         select new anaslider
                         {
                             Id = i.Id,
                             BaslikTR = i.BaslikTR,
                             Kapak = i.Kapak,
                             Tarih = i.Tarih.Value
                         }).OrderByDescending(x => x.Id).Take(5).ToList();
            var ustslider = (from i in db.UstSlider
                             where i.Sil != true
                             select new anaslider
                             {
                                 Id = i.Id,
                                 BaslikTR = i.BaslikTR,
                                 Kapak = i.Kapak,
                                 Tarih = i.Tarih.Value
                             }).OrderByDescending(x => x.Id).Take(5).ToList();
            haber.AddRange(ustslider);
            ViewData["slidee1"] = haber.OrderByDescending(x => x.Tarih).Take(1);
            ViewData["slidee2"] = haber.OrderByDescending(x => x.Tarih).Skip(1).Take(4);

            return View("Index", model);
        }
        [HttpPost]
        public JsonResult KayitKontrol(SiteUyelik p1)
        {
            var tck = db.SiteUyelik.Where(x => x.TC == p1.TC && x.Sil != true).ToList(); 
            if (tck.Count == 0)
            {
                p1.Onay = false;
                p1.Sil = false;
                db.SiteUyelik.Add(p1);
                db.SaveChanges();
                return Json(new { success = true, responseText = "REGISTRATION SUCCESSFUL." }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { success = true, responseText = "THE MEMBER REGISTERED WITH THIS TR ID NUMBER ALREADY EXISTS !" }, JsonRequestBehavior.AllowGet);
            }

        }
        public ActionResult Sidebar()
        {

            var toleyissorgu = db.Toleyis.ToList();
            return View(toleyissorgu);
        }

        public ActionResult LayoutMenuEN()
        {
            string ıp = Request.UserHostAddress;
            DateTime bugun = DateTime.Today;
            Ziyaret ziyaret = new Ziyaret();
            var sorgu = from x in db.Ziyaret
                        where
                        x.IP == ıp && x.Tarih == bugun
                        select x;
            if (sorgu.Any())
            {

            }
            else
            {
                ziyaret.IP = ıp;
                ziyaret.Tarih = DateTime.Today;
                db.Ziyaret.Add(ziyaret);
                db.SaveChanges();
            }
            var iletisim = db.iletisimTur.Where(x => x.Sil != true).ToList();
            var ktgr = db.HaberKategori.Where(x => x.Aktif != false && x.Sil != true);
            //var secilen = ViewBag.Kategori.Ad;
            return View(ktgr);
        }
        public ActionResult Search(string kelime, int sayfa = 1)
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();

            var arama = from x in db.Haber where x.Sil != true select x;
            if (!string.IsNullOrEmpty(kelime))
            {
                arama = arama.Where(m => m.BaslikTR.Contains(kelime) || m.texteditorTR.Contains(kelime) || m.Tarih.ToString().Contains(kelime));
            }

            return View(arama.OrderByDescending(x => x.Tarih).ToList().ToPagedList(sayfa, 9));
        }
        public ActionResult BasYazi()
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();

            var basyazi = db.Toleyis.Where(x => x.Sil != true && x.Id == 5).ToList();
            ViewBag.deger = basyazi.FirstOrDefault().texteditorTR.ToString().Replace("../", manager.GetAdminIPAndPort() + "/");
            return View(basyazi);
        }
        public ActionResult SonKonusma(int sayfa = 1)
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();

            var sonkonusma = db.SonKonusma.Where(x => x.Sil != true).OrderByDescending(x => x.Id).ToList().ToPagedList(sayfa, 8);
            return View(sonkonusma);
        }
        public ActionResult SonKonusmaDetay(int? id)
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();

            var sorgu = db.SonKonusma.Where(x => x.Id == id && x.Sil != true).ToList();
            return View(sorgu);
        }
        public ActionResult SonKonusmaSidebar()
        {
            var sorgu = db.SonKonusma.Where(x => x.Sil != true).OrderByDescending(x => x.Id).ToList();
            return View(sorgu);
        }
    }
}