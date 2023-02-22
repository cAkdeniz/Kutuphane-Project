using KutuphaneProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneProject.Controllers
{
    public class DuyuruController : Controller
    {
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        // GET: Duyuru
        public ActionResult Index()
        {
            var duyurular = db.TBLDUYURULAR.ToList();

            return View(duyurular);
        }

        public ActionResult DuyuruEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DuyuruEkle(TBLDUYURULAR duyuru)
        {
            duyuru.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.TBLDUYURULAR.Add(duyuru);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DuyuruGetir(int id)
        {
            var duyuru = db.TBLDUYURULAR.Find(id);

            return View(duyuru);
        }

        [HttpPost]
        public ActionResult DuyuruGuncelle(TBLDUYURULAR model)
        {
            var guncellenecekDuyuru = db.TBLDUYURULAR.Find(model.Id);
            guncellenecekDuyuru.Kategori = model.Kategori;
            guncellenecekDuyuru.Icerik = model.Icerik;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult DuyuruSil(int id)
        {
            var duyuru = db.TBLDUYURULAR.Find(id);
            db.TBLDUYURULAR.Remove(duyuru);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}