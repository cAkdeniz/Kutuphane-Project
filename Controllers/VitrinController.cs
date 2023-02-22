using KutuphaneProject.Models.Class;
using KutuphaneProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneProject.Controllers
{
    public class VitrinController : Controller
    {
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        // GET: Vitrin
        public ActionResult Index()
        {
            KitapVeHakkimizda models = new KitapVeHakkimizda();
            models.Kitap = db.TBLKITAP.ToList();
            models.Hakkimizda = db.TBLHAKKIMIZDA.ToList();
            return View(models);
        }

        [HttpPost]
        public ActionResult IletisimYolla(TBLILETISIM model)
        {
            db.TBLILETISIM.Add(model);
            db.SaveChanges();

            return RedirectToAction("/Index");
        }
    }
}