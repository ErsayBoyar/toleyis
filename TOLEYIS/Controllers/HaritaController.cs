using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOLEYIS.Models;


namespace TOLEYIS.Controllers
{
    public class HaritaController : Controller
    {
        TOLEYIS_Entities db = new TOLEYIS_Entities();
        ViewModel model = new ViewModel();
        // GET: Harita
        public ActionResult Index()
        {
            return View();
        }
    }
}