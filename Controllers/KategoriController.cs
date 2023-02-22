using KutuphaneProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneProject.Controllers
{
    public class KategoriController : Controller
    {
        KutuphaneDBEntities db = new KutuphaneDBEntities();

        public ActionResult Index()
        {
            var kategoriler = db.TBLKATEGORI.Where(x=>x.Durum==true).ToList();
            return View(kategoriler);
        }

        public ActionResult KategoriEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KategoriEkle(TBLKATEGORI kategori)
        {
            kategori.Durum = true;
            db.TBLKATEGORI.Add(kategori);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KategoriSil(int id)
        {
            var kategori = db.TBLKATEGORI.Find(id);
            //db.TBLKATEGORI.Remove(kategori);
            kategori.Durum = false;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult KategoriGetir(int id)
        {
            var kategori = db.TBLKATEGORI.Find(id);
            return View(kategori);
        }

        
        public ActionResult Guncelle(TBLKATEGORI model)
        {
            var kategori = db.TBLKATEGORI.Find(model.Id);
            kategori.Ad = model.Ad;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}