//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_CONGTY
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tb_CONGTY()
        {
            this.tb_BANGCONG_NHANVIEN_CHITIET = new HashSet<tb_BANGCONG_NHANVIEN_CHITIET>();
            this.tb_KYCONG = new HashSet<tb_KYCONG>();
            this.tb_KYCONGCHITIET = new HashSet<tb_KYCONGCHITIET>();
            this.tb_NHANVIEN = new HashSet<tb_NHANVIEN>();
            this.tb_User = new HashSet<tb_User>();
        }
    
        public int MACTY { get; set; }
        public string TENCTY { get; set; }
        public string DIENTHOAI { get; set; }
        public string EMAIL { get; set; }
        public string DIACHI { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_BANGCONG_NHANVIEN_CHITIET> tb_BANGCONG_NHANVIEN_CHITIET { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_KYCONG> tb_KYCONG { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_KYCONGCHITIET> tb_KYCONGCHITIET { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_NHANVIEN> tb_NHANVIEN { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tb_User> tb_User { get; set; }
    }
}
