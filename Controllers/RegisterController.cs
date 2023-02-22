using KutuphaneProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneProject.Controllers
{
    public class RegisterController : Controller
    {
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        // GET: Register
        public ActionResult KayitOl()
        {
            return View();
        }

        [HttpPost]
        public ActionResult KayitOl(TBLUYELER uye)
        {
            db.TBLUYELER.Add(uye);
            db.SaveChanges();

            return RedirectToAction("GirisYap", "Login");
        }
    }
}