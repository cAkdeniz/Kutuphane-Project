using KutuphaneProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KutuphaneProject.Controllers
{
    [Authorize]
    public class OgrenciController : Controller
    {
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        // GET: Ogrenci
        public ActionResult Index()
        {
            var kullaniciAd = (string)Session["Kullanici"];
            var uye = db.TBLUYELER.FirstOrDefault(x => x.KullaniciAd == kullaniciAd);
            return View(uye);
        }

        [HttpPost]
        public ActionResult GuncelleBilgilerim(TBLUYELER model)
        {
            var kullaniciAd = (string)Session["Kullanici"];

            var uye = db.TBLUYELER.FirstOrDefault(x => x.KullaniciAd == kullaniciAd);

            uye.Ad = model.Ad;
            uye.Soyad = model.Soyad;
            uye.Sifre = model.Sifre;
            uye.Email = model.Email;
            uye.Okul = model.Okul;
            uye.Fotograf = model.Fotograf;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Kitaplarim()
        {
            var kullaniciAd = (string)Session["Kullanici"];
            var uye = db.TBLUYELER.FirstOrDefault(x => x.KullaniciAd == kullaniciAd);
            var kitaplar = db.TBLHAREKET.Where(x => x.IslemDurum == true && x.UyeId == uye.Id).ToList();

            return View(kitaplar);
        }

        public ActionResult Duyurular()
        {
            var duyurular = db.TBLDUYURULAR.ToList();
            return View(duyurular);
        }

        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap","Login");
        }
    }
}