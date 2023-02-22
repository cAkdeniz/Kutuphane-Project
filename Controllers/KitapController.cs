using KutuphaneProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneProject.Controllers
{
    public class KitapController : Controller
    {
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        // GET: Kitap
        public ActionResult Index(string p)
        {
            var kitaplar = db.TBLKITAP.ToList();
            if(!string.IsNullOrEmpty(p))
            {
                kitaplar = db.TBLKITAP.Where(x => x.Ad.Contains(p)).ToList();
            }

            return View(kitaplar);
        }

        public ActionResult KitapEkle()
        {
            List<SelectListItem> yazarlar = (from y in db.TBLYAZAR.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = y.Ad + " " + y.Soyad,
                                                 Value = y.Id.ToString()
                                             }).ToList();

            List<SelectListItem> kategoriler = (from k in db.TBLKATEGORI.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = k.Ad,
                                                 Value = k.Id.ToString()
                                             }).ToList();

            ViewBag.Yazar = yazarlar;
            ViewBag.Kategori = kategoriler;

            return View();
        }

        [HttpPost]
        public ActionResult KitapEkle(TBLKITAP model)
        {
            model.Durum = true;

            db.TBLKITAP.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapSil(int id)
        {
            var kitap = db.TBLKITAP.Find(id);
            db.TBLKITAP.Remove(kitap);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult KitapGetir(int id)
        {
            var kitap = db.TBLKITAP.Find(id);

            List<SelectListItem> yazarlar = (from y in db.TBLYAZAR.ToList()
                                             select new SelectListItem
                                             {
                                                 Text = y.Ad + " " + y.Soyad,
                                                 Value = y.Id.ToString()
                                             }).ToList();

            List<SelectListItem> kategoriler = (from k in db.TBLKATEGORI.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = k.Ad,
                                                    Value = k.Id.ToString()
                                                }).ToList();

            ViewBag.Yazar = yazarlar;
            ViewBag.Kategori = kategoriler;

            return View(kitap);
        }

        [HttpPost]
        public ActionResult KitapGuncelle(TBLKITAP model)
        {
            var kitap = db.TBLKITAP.Find(model.Id);
            kitap.Ad = model.Ad;
            kitap.BasımYil = model.BasımYil;
            kitap.Sayfa = model.Sayfa;
            kitap.YayinEvi = model.YayinEvi;
            kitap.KategoriId = model.KategoriId;
            kitap.YazarId = model.YazarId;

            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}