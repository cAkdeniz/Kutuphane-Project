using KutuphaneProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneProject.Controllers
{
    public class OduncController : Controller
    {
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        // GET: Odunc
        public ActionResult Index()
        {
            var hareketler = db.TBLHAREKET.Where(x=>x.IslemDurum == false).ToList();
            return View(hareketler);
        }

        public ActionResult OduncVer()
        {
            List<SelectListItem> kitaplar = (from k in db.TBLKITAP.Where(x=>x.Durum==true).ToList()
                                             select new SelectListItem
                                             {
                                                 Text = k.Ad,
                                                 Value = k.Id.ToString()
                                             }).ToList();

            List<SelectListItem> uyeler = (from u in db.TBLUYELER.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = u.Ad,
                                                    Value = u.Id.ToString()
                                                }).ToList();

            List<SelectListItem> personeller = (from p in db.TBLPERSONEL.ToList()
                                                select new SelectListItem
                                                {
                                                    Text = p.Personel,
                                                    Value = p.Id.ToString()
                                                }).ToList();

            ViewBag.Kitaplar = kitaplar;
            ViewBag.Uyeler = uyeler;
            ViewBag.Personeller = personeller;

            return View();
        }

        [HttpPost]
        public ActionResult OduncVer(TBLHAREKET hareket)
        {
            if(ModelState.IsValid)
            {
                hareket.IslemDurum = false;
                db.TBLHAREKET.Add(hareket);
                var kitap = db.TBLKITAP.Find(hareket.KitapId);
                kitap.Durum = false;
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(hareket);
        }

        public ActionResult OduncIade(int id)
        {
            var odunc = db.TBLHAREKET.Find(id);
            DateTime d1 = DateTime.Parse(odunc.IadeTarih.ToString());
            DateTime d2 = DateTime.Parse(DateTime.Now.ToShortDateString());
            TimeSpan d3 = d2 - d1;

            if(d3.TotalDays <= 0)
            {
                ViewBag.dgr = 0;
            }
            else
            {
                ViewBag.dgr = d3.TotalDays;
            }        
            return View(odunc);
        }

        [HttpPost]
        public ActionResult OduncGuncelle(TBLHAREKET model,string gec)
        {
            if(ModelState.IsValid)
            {
                TBLCEZALAR ceza = new TBLCEZALAR()
                {
                    UyeId = model.UyeId,
                    HareketId = model.Id,
                    Para = Convert.ToDecimal(gec)
                };
                db.TBLCEZALAR.Add(ceza);

                var hareket = db.TBLHAREKET.Find(model.Id);
                hareket.GetirilenTarih = model.GetirilenTarih;
                hareket.IslemDurum = true;

                var kitap = db.TBLKITAP.Find(model.KitapId);
                kitap.Durum = true;

                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View();
        }
    }
}