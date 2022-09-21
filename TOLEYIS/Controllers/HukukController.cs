using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOLEYIS.Models;
namespace TOLEYIS.Controllers
{
    public class HukukController : Controller
    {
        TOLEYIS_Entities db = new TOLEYIS_Entities();
        // GET: Hukuk
        public ActionResult Kararnameler()
        {
            var kararname = db.Hukuk.Where(x => x.Sil != true && x.TurID == 1).ToList();
            return View(kararname);
        }
        public ActionResult Genelgeler()
        {
            var genelge = db.Hukuk.Where(x => x.Sil != true && x.TurID == 2).ToList();
            return View(genelge);
        }
        public ActionResult Kanunlar()
        {
            var kanun = db.Hukuk.Where(x => x.Sil != true && x.TurID == 3).ToList();
            return View(kanun);
        }
        public ActionResult Yonetmelikler()
        {
            var yonetmelik = db.Hukuk.Where(x => x.Sil != true && x.TurID == 4).ToList();
            return View(yonetmelik);
        }
        public ActionResult Tebligler()
        {
            var teblig = db.Hukuk.Where(x => x.Sil != true && x.TurID == 5).ToList();
            return View(teblig);
        }
        public ActionResult SidebarHukuk()
        {
            return View();
        }
    }
}