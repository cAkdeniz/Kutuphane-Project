using KutuphaneProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneProject.Controllers
{
    [Authorize]
    public class MesajController : Controller
    {
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        // GET: Mesaj
        public ActionResult Index()
        {
            var kullanici = (string)Session["Kullanici"];
            var mesajlar = db.TBLMESAJ.Where(x => x.Alici == kullanici).ToList();
            return View(mesajlar);
        }

        public ActionResult GidenMesajlar()
        {
            var kullanici = (string)Session["Kullanici"];
            var mesajlar = db.TBLMESAJ.Where(x => x.Gonderen == kullanici).ToList();
            return View(mesajlar);
        }

        public ActionResult YeniMesaj()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniMesaj(TBLMESAJ mesaj)
        {
            var kullanici = (string)Session["Kullanici"];
            mesaj.Gonderen = kullanici;
            mesaj.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());

            db.TBLMESAJ.Add(mesaj);
            db.SaveChanges();

            return RedirectToAction("GidenMesajlar");
        }
    }
}