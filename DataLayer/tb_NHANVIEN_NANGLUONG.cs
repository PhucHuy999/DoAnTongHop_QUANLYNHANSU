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
    
    public partial class tb_NHANVIEN_NANGLUONG
    {
        public string SOQD { get; set; }
        public Nullable<int> MANV { get; set; }
        public string SOHD { get; set; }
        public Nullable<double> HESOLUONGHIENTAI { get; set; }
        public Nullable<double> HESOLUONGMOI { get; set; }
        public Nullable<System.DateTime> NGAYLENLUONG { get; set; }
        public Nullable<System.DateTime> NGAYKY { get; set; }
        public string GHICHU { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<int> UPDATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
        public Nullable<int> DELETED_BY { get; set; }
        public Nullable<System.DateTime> DELETED_DATE { get; set; }
    
        public virtual tb_NHANVIEN tb_NHANVIEN { get; set; }
    }
}