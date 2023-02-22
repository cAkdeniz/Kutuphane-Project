using KutuphaneProject.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KutuphaneProject.Models.Class
{
    public class KitapVeHakkimizda
    {
        public IEnumerable<TBLKITAP> Kitap { get; set; }
        public IEnumerable<TBLHAKKIMIZDA> Hakkimizda { get; set; }
    }
}