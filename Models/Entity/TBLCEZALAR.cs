//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace KutuphaneProject.Models.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class TBLCEZALAR
    {
        public int Id { get; set; }
        public Nullable<int> UyeId { get; set; }
        public Nullable<int> HareketId { get; set; }
        public Nullable<System.DateTime> Baslangic { get; set; }
        public Nullable<System.DateTime> Bitis { get; set; }
        public Nullable<decimal> Para { get; set; }
    
        public virtual TBLHAREKET TBLHAREKET { get; set; }
        public virtual TBLUYELER TBLUYELER { get; set; }
    }
}
