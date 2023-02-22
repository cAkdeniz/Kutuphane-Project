using KutuphaneProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KutuphaneProject.Controllers
{
    public class IslemController : Controller
    {
        KutuphaneDBEntities db = new KutuphaneDBEntities();
        // GET: Islem
        public ActionResult Index()
        {
            var hareketler = db.TBLHAREKET.Where(x => x.IslemDurum == true).ToList();
            return View(hareketler);
        }
    }
}