using KutuphaneProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneProject.Controllers
{
    public class IstatistikController : Controller
    {
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        // GET: Istatistik
        public ActionResult Index()
        {
            ViewBag.Para = db.TBLCEZALAR.Sum(x => x.Para);
            ViewBag.KitapSayisi = db.TBLKITAP.Count();
            ViewBag.UyeSayisi = db.TBLUYELER.Count();
            ViewBag.EmanetKitapSayisi = db.TBLHAREKET.Where(x => x.IslemDurum == false).Count();
            return View();
        }

        public ActionResult Galeri()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ResimYukle(HttpPostedFileBase dosya)
        {
            if(dosya.ContentLength > 0)
            {
                var dosyaYolu = Path.Combine(Server.MapPath("~/web2/images/"), Path.GetFileName(dosya.FileName));
                dosya.SaveAs(dosyaYolu);
            }
            return RedirectToAction("Galeri");
        }
    }
}