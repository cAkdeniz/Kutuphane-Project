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
    
    public partial class TBLYAZAR
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TBLYAZAR()
        {
            this.TBLKITAP = new HashSet<TBLKITAP>();
        }
    
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string Detay { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TBLKITAP> TBLKITAP { get; set; }
    }
}
