using KutuphaneProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KutuphaneProject.Controllers
{
    public class LoginController : Controller
    {
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        // GET: Login
        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(TBLUYELER uye)
        {
            var uyeGiris = db.TBLUYELER.FirstOrDefault(x => x.KullaniciAd == uye.KullaniciAd && x.Sifre == uye.Sifre);
            if(uyeGiris != null)
            {
                FormsAuthentication.SetAuthCookie(uyeGiris.KullaniciAd, false);
                Session["Kullanici"] = uyeGiris.KullaniciAd.ToString();
                return RedirectToAction("Index", "Ogrenci");
            }
            return View();
        }
    }
}