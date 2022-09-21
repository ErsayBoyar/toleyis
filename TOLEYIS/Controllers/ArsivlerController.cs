using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOLEYIS.Models;

namespace TOLEYIS.Controllers
{
    public class ArsivlerController : Controller
    {
        // GET: Arsivler
        TOLEYIS_Entities db = new TOLEYIS_Entities();
        ViewModel model = new ViewModel();
        Manager manager = new Manager();

        // GET: Haberler
        public ActionResult Arsiv(int? Yillar, int sayfa = 1)
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();
            
          
                var arsiv = db.Arsiv.Where(x=>x.Sil!=true).OrderByDescending(x => x.Id).ToList();
              
                
            //var fotosorgu = db.Galeri.Where(x => x.Sil != true && x.TurID == 1).OrderByDescending(x => x.Id).ToList().ToPagedList(sayfa, 8);
            return View(arsiv);

        }
    }
}