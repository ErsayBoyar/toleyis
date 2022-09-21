using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOLEYIS.Models;
using System.Data.Entity;
using PagedList;
using PagedList.Mvc;

namespace TOLEYIS.Controllers
{
    public class BilgiController : Controller
    {
        TOLEYIS_Entities db = new TOLEYIS_Entities();
        ViewModel model = new ViewModel();
        Manager manager = new Manager();

        // GET: Bilgi
        public ActionResult PratikBilgiler()
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();

            model.Pratiks = db.Pratik.Where(x => x.Sil != true).Include(x => x.PratikDosya).ToList();

            model.PratikBilgilers = db.PratikBilgiler.Where(x => x.Sil != true).ToList();
            return View(model);
        }
        public ActionResult AnlasmaliKurumlar()
        {
            ViewBag.Iller = new SelectList(db.IL, "Id", "Ad");

            var anlasmalikurum = db.AnlasmaliKurumlar.Where(x => x.Sil != true).ToList();

            return View(anlasmalikurum);
        }        
        public ActionResult IlSec(int? id)
        {
            var deger1 = db.AnlasmaliKurumlar.Where(x => x.Sil != true && x.ILID == id).OrderBy(x=>x.Ad).ToList();
            var iller = db.IL.Where(x => x.Id == id).First();

            ViewBag.il = iller.Ad;


            return PartialView(deger1);
        }
        public ActionResult KurumPopup(int? id)
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();
            //veritabanına eklenecek kurum tablosu
            var anlasmalikurum = db.AnlasmaliKurumlar.Where(x => x.Sil != true && x.Id == id).FirstOrDefault();

            return PartialView(anlasmalikurum);
        }
        public ActionResult SoruCevap()
        {
            var sorucevap = db.SoruCevap.Where(x => x.Sil != true).ToList();
            return View(sorucevap);
        }
        public ActionResult Sidebar()
        {
            return View();
        }
        public ActionResult Enflasyon()
        {
            var enf = db.Enflasyon.Where(x => x.Sil != true).OrderByDescending(k=>k.Tarih).ToList();
            return View(enf);
        }
        public ActionResult Nurer()
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();
            var nurer = db.Nurer.Where(x => x.Sil != true && x.Id == 1).ToList();

            ViewBag.deger = nurer.FirstOrDefault().texteditorTR.ToString().Replace("../", manager.GetAdminIPAndPort() + "/");

            return View(nurer);
        }
        public ActionResult TufeUfe(int? Aylar, int? Yillar, int sayfa = 1)
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();

            var ay = db.Ay;
            ViewBag.Aylar = new SelectList(ay, "Id", "Ad", "Aylar");
            var yil = db.Yil;
            ViewBag.Yillar = new SelectList(yil, "Id", "Ad", "Yillar");

            if (Aylar != null && Yillar != null)
            {
                var TefeTufes = db.TefeTufeDosya.Where(x=>x.TefeTufe.Id == x.TeteTufeID && x.TefeTufe.Ayid == Aylar && x.TefeTufe.Yilid== Yillar &&x.TefeTufe.Sil != true).ToList().ToPagedList(sayfa, 8);
                return View(TefeTufes);
            }
            else if (Aylar == null && Yillar != null)
            {
                var TefeTufes = db.TefeTufeDosya.Where(x => x.TefeTufe.Id == x.TeteTufeID && x.TefeTufe.Yilid == Yillar && x.TefeTufe.Sil != true).ToList().ToPagedList(sayfa, 8);
                return View(TefeTufes);
            }
            else if (Aylar != null && Yillar == null)
            {
                var TefeTufes = db.TefeTufeDosya.Where(x => x.TefeTufe.Id == x.TeteTufeID && x.TefeTufe.Ayid == Aylar && x.TefeTufe.Sil != true).ToList().ToPagedList(sayfa, 8);
                return View(TefeTufes);
            }
            else
            {
                var TefeTufes = db.TefeTufeDosya.Where(x=>x.TefeTufe.Sil != true).ToList().ToPagedList(sayfa, 8);
                return View(TefeTufes);
            }
        }
        public ActionResult AclikYoksulluk(int? Aylar, int? Yillar, int sayfa = 1)
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();

            var ay = db.Ay;
            ViewBag.Aylar = new SelectList(ay, "Id", "Ad", "Aylar");
            var yil = db.Yil;
            ViewBag.Yillar = new SelectList(yil, "Id", "Ad", "Yillar");

            if (Aylar != null && Yillar != null)
            {
                var Aclik = db.AclikDosya.Where(x => x.Aclik.Id == x.AclikID && x.Aclik.Ayid == Aylar && x.Aclik.Yilid == Yillar && x.Aclik.Sil != true).OrderByDescending(x => new { x.Aclik.Yilid, x.Aclik.Ayid }).ToList().ToPagedList(sayfa, 8);
                return View(Aclik);
            }
            else if (Aylar == null && Yillar != null)
            {
                var Aclik = db.AclikDosya.Where(x => x.Aclik.Id == x.AclikID && x.Aclik.Yilid == Yillar && x.Aclik.Sil != true).OrderByDescending(x => new { x.Aclik.Yilid, x.Aclik.Ayid }).ToList().ToPagedList(sayfa, 8);
                return View(Aclik);
            }
            else if (Aylar != null && Yillar == null)
            {
                var Aclik = db.AclikDosya.Where(x => x.Aclik.Id == x.AclikID && x.Aclik.Ayid == Aylar && x.Aclik.Sil != true).OrderByDescending(x => new { x.Aclik.Yilid, x.Aclik.Ayid }).ToList().ToPagedList(sayfa, 8);
                return View(Aclik);
            }
            else
            {
                var Aclik = db.AclikDosya.Where(x => x.Aclik.Sil != true).OrderByDescending(x=> new { x.Aclik.Yilid, x.Aclik.Ayid }).ToList().ToPagedList(sayfa, 8);
                return View(Aclik);
            }
        }

    }
}