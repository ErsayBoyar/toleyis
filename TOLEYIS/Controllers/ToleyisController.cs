using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOLEYIS.Models;

namespace TOLEYIS.Controllers
{
    public class ToleyisController : Controller
    {
        TOLEYIS_Entities db = new TOLEYIS_Entities();
        ViewModel model = new ViewModel();
        Manager manager = new Manager();

        // GET: Toleyis
        public ActionResult Tarihce()
        {
            var tarihcesorgu = db.Toleyis.Where(x => x.Sil != true && x.Id == 1).ToList();
            return View(tarihcesorgu);
        }
        public ActionResult GenelYonetim()
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();

            var yonetimsorgu = db.Yonetim.Where(x => x.Sil != true).ToList();
            return View(yonetimsorgu);
        }
        public ActionResult GenelYonPopup(int? id)
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();

            var popupsorgu = db.Yonetim.Where(x => x.Id == id && x.Sil != true).FirstOrDefault();
            return PartialView(popupsorgu);
        }
        public ActionResult SubeDetay(int? id)
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();

            if (id == null)
            {
                ViewBag.Subeler = new SelectList(db.Subeler, "Id", "Ad", 1);
                model.SubeTemsilcis = db.SubeTemsilci.Where(x => x.Sil != true && x.SubeId == 1).OrderBy(x => x.Sira).Skip(1).Take(5).ToList();
                model.SubeTemsilciss = db.SubeTemsilci.Where(x => x.Sil != true && x.SubeId == 1).Take(1).ToList();
                model.Iletisims = db.Iletisim.Where(x => x.Sil != true && x.SubeID == 1 && x.TurID == 4).ToList();
                var sube = db.Subeler.Where(x => x.Id == 1).First();
                ViewBag.sube = sube.Ad;
                return View(model);
            }
            else
            {
                ViewBag.Subeler = new SelectList(db.Subeler, "Id", "Ad", id);
                model.SubeTemsilcis = db.SubeTemsilci.Where(x => x.Sil != true && x.SubeId == id).OrderBy(x => x.Sira).Skip(1).Take(5).ToList();
                model.SubeTemsilciss = db.SubeTemsilci.Where(x => x.Sil != true && x.SubeId == id).Take(1).ToList();
                model.Iletisims = db.Iletisim.Where(x => x.Sil != true && x.SubeID == id && x.TurID == 4).ToList();
                var sube = db.Subeler.Where(x => x.Id == id).First();
                ViewBag.sube = sube.Ad;
                return View(model);
            }
        }
        public ActionResult SubeIlSec(int? id, int? durum)
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();
            if (durum == 0)
            {
                model.SubeTemsilcis = db.SubeTemsilci.Where(x => x.Sil != true && x.SubeId == id).OrderBy(x => x.Sira).Skip(1).Take(5).ToList();
                model.SubeTemsilciss = db.SubeTemsilci.Where(x => x.Sil != true && x.SubeId == id).Take(1).ToList();
                model.Iletisims = db.Iletisim.Where(x => x.Sil != true && x.SubeID == id && x.TurID == 4).ToList();
                var sube = db.Subeler.Where(x => x.Id == id).First();
                ViewBag.sube = sube.Ad;
                return PartialView(model);
            }
            else
            {
                var sorgu = db.IL.Where(x => x.Id == id).First();
                model.SubeTemsilcis = db.SubeTemsilci.Where(x => x.Sil != true && x.SubeId == sorgu.SubeID).OrderBy(x => x.Sira).Skip(1).Take(5).ToList();
                model.SubeTemsilciss = db.SubeTemsilci.Where(x => x.Sil != true && x.SubeId == sorgu.SubeID).Take(1).ToList();
                model.Iletisims = db.Iletisim.Where(x => x.Sil != true && x.SubeID == sorgu.SubeID && x.TurID == 4).ToList();
                var sube = db.Subeler.Where(x => x.Id == sorgu.SubeID).First();
                ViewBag.sube = sube.Ad;
                return PartialView(model);
            }

        }
        public ActionResult SubeSidebar()
        {
            var subeler = db.Subeler.Where(x => x.Sil != true).ToList();
            return View(subeler);
        }
        public ActionResult Calisanlar()
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();

            var calisanlarsorgu = db.Calisanlarimiz.Where(x => x.Sil != true).ToList();
            return View(calisanlarsorgu);
        }
        public ActionResult Kurulusİlkeleri()
        {
            var kurulussorgu = db.Toleyis.Where(x => x.Sil != true && x.Id == 2).ToList();
            return View(kurulussorgu);
        }
        public ActionResult CalismaSekli()
        {
            var calismaseklisorgu = db.Toleyis.Where(x => x.Sil != true && x.Id == 3).ToList();
            return View(calismaseklisorgu);
        }
        public ActionResult FaaliyetAlanlari()
        {
            var faaliyetalansorgu = db.Toleyis.Where(x => x.Sil != true && x.Id == 4).ToList();
            return View(faaliyetalansorgu);
        }
        public ActionResult BolgeTemsilcilik()
        {
            var bolge = db.Iletisim.Where(x => x.Sil != true && x.TurID == 2).ToList();
            return View(bolge);
        }
        public ActionResult GenelMerkez()
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();

            model.GenelMerkezs = db.GenelMerkez.Where(x => x.Sil != true).ToList();
            model.Yonetims = db.Yonetim.Where(x => x.Sil != true && x.UnvanID == 1 && x.Id == 1).ToList();

            return View(model);
        }
        public ActionResult IlTemsilcilik()
        {
            ViewBag.Iller = new SelectList(db.IL, "Id", "Ad");

            var ilTems = db.Iletisim.Where(x => x.Sil != true && x.TurID == 3).ToList();

            return View(ilTems);
        }
        public ActionResult TemsilcilikIlSec(int? id)
        {
            var deger1 = db.Iletisim.Where(x => x.Sil != true && x.ilID == id && x.TurID == 3).ToList();
            var iller = db.IL.Where(x => x.Id == id).First();
            ViewBag.il = iller.Ad;
            return PartialView(deger1);
        }
        public ActionResult Orgutlu()
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();

            ViewBag.Iller = new SelectList(db.IL, "Id", "Ad");

            var orgutlu = db.Orgutlu.Where(x => x.Sil != true).ToList();

            return View(orgutlu);
        }
        public ActionResult IlSec(int? id)
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();

            var deger1 = db.Orgutlu.Where(x => x.Sil != true && x.ilID == id).ToList();
            var iller = db.IL.Where(x => x.Id == id).First();
            ViewBag.il = iller.Ad;
            return PartialView(deger1);
        }
        public ActionResult UyeSayi()
        {
            var uyesorgu = db.UyeSay.Where(x => x.Sil != true).OrderByDescending(x => x.Tarih).ToList();
            return View(uyesorgu);
        }
    }
}