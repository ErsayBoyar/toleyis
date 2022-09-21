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
    public class GorselController : Controller
    {
        TOLEYIS_Entities db = new TOLEYIS_Entities();
        Manager manager = new Manager();
        ViewModel model = new ViewModel();

        // GET: Gorsel
        public ActionResult Video(int sayfa = 1)
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();

            var yil = db.FotoKategori.OrderByDescending(x => x.Id).ToList();

            ViewBag.Yillar = new SelectList(yil, "Id", "Ad");

            var videosorgu = db.Galeri.Where(x => x.Sil != true && x.TurID == 2).OrderByDescending(x => x.Tarih).ToList().ToPagedList(sayfa, 8);

            return View(videosorgu);
        }
        public ActionResult YilSec(int? id, int sayfa = 1)
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();

            var deger1 = db.Galeri.Where(x => x.Sil != true && x.TurID == 2 && x.KateID == id).OrderByDescending(x => x.Tarih).ToList().ToPagedList(sayfa, 8);
            return PartialView(deger1);
        }
        public ActionResult FotoGaleri(int? Yillar, int sayfa = 1)
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();
            ViewBag.yılll = Yillar;
            var yil = db.FotoKategori.OrderByDescending(x => x.Id);

            ViewBag.Yillar = new SelectList(yil, "Id", "Ad");

            if (ViewBag.yılll != null)
            {

                var habergaleri = (from i in db.HaberGaleri
                                   where i.Sil != true
                                   select new Galerim
                                   {
                                       Id = i.Id,
                                       DosyaURL = i.Ad,
                                   }).OrderByDescending(x => x.Id).ToList();
                var galeri = (from i in db.Galeri
                              where i.Sil != true && i.TurID == 1 && i.KateID == Yillar
                              select new Galerim
                              {
                                  Id = i.Id,
                                  DosyaURL = i.DosyaURL,
                              }).OrderByDescending(x => x.Id).ToList();
                habergaleri.AddRange(galeri);
                ViewData["galeri"] = habergaleri.OrderByDescending(x => x.Id).ToPagedList(sayfa, 8);
                return View(ViewData["galeri"]);
            }
            else
            {
                var habergaleri = (from i in db.HaberGaleri
                             where i.Sil != true 
                             select new Galerim
                             {
                                 Id = i.Id,
                                 DosyaURL = i.Ad,
                             }).OrderByDescending(x => x.Id).ToList();
                var galeri = (from i in db.Galeri
                                 where i.Sil != true && i.TurID == 1
                              select new Galerim
                                 {
                                     Id = i.Id,
                                     DosyaURL = i.DosyaURL,
                                 }).OrderByDescending(x => x.Id).ToList();
                habergaleri.AddRange(galeri);
                ViewData["galeri"] = habergaleri.OrderByDescending(x => x.Id).ToPagedList(sayfa, 8);
                //var fotosorgu = db.Galeri.Where(x => x.Sil != true && x.TurID == 1).OrderByDescending(x => x.Id).ToList().ToPagedList(sayfa, 8);
                return View(ViewData["galeri"]);
            }
        }
        public ActionResult FotoYilSec(int? id, int sayfa = 1)
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();

            var deger1 = db.Galeri.Where(x => x.Sil != true && x.TurID == 1 && x.KateID == id).OrderByDescending(x => x.Tarih).ToList().ToPagedList(sayfa, 8);
            return PartialView(deger1);
        }
        public ActionResult FotoArsiv(int sayfa = 1)
        {
            ViewBag.dosyayolu = manager.GetAdminIPAndPort();

            model.Arsivs = db.Arsiv.Where(x => x.Sil != true).OrderByDescending(x => x.Id).ToPagedList(sayfa, 8).ToList();

            model.ArsivGaleris = db.ArsivGaleri.Where(x => x.Sil != true).OrderByDescending(x => x.Id).ToList();
            return View(model);
        }
    }
}