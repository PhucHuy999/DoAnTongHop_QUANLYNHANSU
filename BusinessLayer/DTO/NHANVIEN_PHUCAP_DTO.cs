using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class NHANVIEN_PHUCAP_DTO
    {
        public int ID { get; set; }
        public Nullable<int> MANV { get; set; }
        public string HOTEN { set; get; }
        public string TENCV { set; get; }
        public Nullable<int> IDPC { get; set; }
        public string TENPC { set; get; }
        public Nullable<System.DateTime> NGAY { get; set; }
        public string NOIDUNG { get; set; }
        public Nullable<double> SOTIEN { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<int> UPDATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
        public Nullable<int> DELETED_BY { get; set; }
        public Nullable<System.DateTime> DELETED_DATE { get; set; }

        public virtual tb_NHANVIEN tb_NHANVIEN { get; set; }
        public virtual tb_PHUCAP tb_PHUCAP { get; set; }
    }
}
