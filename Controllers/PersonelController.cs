using KutuphaneProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneProject.Controllers
{
    public class PersonelController : Controller
    {
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        // GET: Personel
        public ActionResult Index()
        {
            var personeller = db.TBLPERSONEL.ToList();
            return View(personeller);
        }

        public ActionResult PersonelEkle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult PersonelEkle(TBLPERSONEL model)
        {
            if(!ModelState.IsValid)
            {
                return View("PersonelEkle");
            }
            db.TBLPERSONEL.Add(model);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult PersonelSil(int id)
        {
            var personel = db.TBLPERSONEL.Find(id);
            db.TBLPERSONEL.Remove(personel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult PersonelGetir(int id)
        {
            var personel = db.TBLPERSONEL.Find(id);
            return View(personel);
        }

        public ActionResult PersonelGuncelle(TBLPERSONEL model)
        {
            var personel = db.TBLPERSONEL.Find(model.Id);
            personel.Personel = model.Personel;
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}