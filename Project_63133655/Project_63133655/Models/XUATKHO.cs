//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project_63133655.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class XUATKHO
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public XUATKHO()
        {
            this.NDXUATKHO = new HashSet<NDXUATKHO>();
        }
    
        public string SoPhieuXuat { get; set; }
        public System.DateTime NgayXuat { get; set; }
        public string MaNV { get; set; }
        public string TenNgNhan { get; set; }
        public string DiaChi { get; set; }
        public string SDT { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<NDXUATKHO> NDXUATKHO { get; set; }
        public virtual NHANVIEN NHANVIEN { get; set; }
    }
}
