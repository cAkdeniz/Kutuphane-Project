using KutuphaneProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneProject.Controllers
{
    public class YazarController : Controller
    {
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        // GET: Yazar
        public ActionResult Index()
        {
            var yazarlar = db.TBLYAZAR.ToList();
            return View(yazarlar);
        }

        public ActionResult YazarEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YazarEkle(TBLYAZAR yazar)
        {
            if(!ModelState.IsValid)
            {
                return View(yazar);
            }
            db.TBLYAZAR.Add(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarSil(int id)
        {
            var yazar = db.TBLYAZAR.Find(id);
            db.TBLYAZAR.Remove(yazar);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult YazarGetir(int id)
        {
            var yazar = db.TBLYAZAR.Find(id);
            return View(yazar);
        }

        [HttpPost]
        public ActionResult YazarGuncelle(TBLYAZAR model)
        {
            var yazar = db.TBLYAZAR.Find(model.Id);
            yazar.Ad = model.Ad;
            yazar.Soyad = model.Soyad;
            yazar.Detay = model.Detay;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}