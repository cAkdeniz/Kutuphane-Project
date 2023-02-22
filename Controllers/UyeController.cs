using KutuphaneProject.Models.Entity;
using PagedList;
using PagedList.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneProject.Controllers
{
    public class UyeController : Controller
    {
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        // GET: Uye
        public ActionResult Index(int sayfa = 1)
        {
            var uyeler = db.TBLUYELER.ToList().ToPagedList(sayfa, 3);
            return View(uyeler);
        }

        public ActionResult KitapGecmis(int id)
        {
            var uye = db.TBLUYELER.Find(id);
            var kitaplar = db.TBLHAREKET.Where(x => x.UyeId == uye.Id).ToList();
            ViewBag.UyeAd = uye.Ad;
            ViewBag.Soyad = uye.Soyad;
            return View(kitaplar);
        }
    }
}