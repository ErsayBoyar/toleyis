using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;
using TOLEYIS.Models;

namespace TOLEYIS.Controllers
{
    public class ContactController : Controller
    {
        TOLEYIS_Entities db = new TOLEYIS_Entities();
        // GET: Iletisim
        [HttpGet]
        public ActionResult Index(int? id)
        {
            //var iletisim = db.Iletisim.Where(x => x.Sil != true && x.TurID == id).ToList();
            //ViewBag.Baslik = iletisim.First().iletisimTur.AdTR;
            ViewBag.id = id;
            return View();
        }
        [HttpPost]
        public ActionResult Post(IletisimForm p1)
        {
            MailMessage mesajım = new MailMessage();
            SmtpClient istemci = new SmtpClient();
            istemci.Credentials = new NetworkCredential("catstoleyis@gmail.com", "Balkes10@");
            istemci.Port = 587;
            istemci.Host = "smtp.gmail.com";
            istemci.EnableSsl = true;
            mesajım.To.Add("site@toleyis.org.tr"); //site@toleyis.org.tr
            mesajım.From = new MailAddress("catstoleyis@gmail.com");
            mesajım.Subject = "Yeni İletişim";
            mesajım.Body = "Ad Soyad :" + " " + p1.Ad + "\n Telefon :" + " " + p1.Telefon + "\n Mail :" + " " + p1.Eposta + "\n İçerik:" + " " + p1.Mesaj;
            istemci.Send(mesajım);
            db.IletisimForm.Add(p1);
            db.SaveChanges();
            return RedirectToAction("Index", "AnaSayfa");

            //return Redirect("/AnaSayfa/Index");
            //return new RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary(new { action ="Index" , controller ="AnaSayfa"}));
        }
        public ActionResult Sidebar()
        {
            //var iletisim = db.iletisimTur.Where(x => x.Sil != true).ToList();
            return View();
        }

    }
}