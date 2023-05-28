using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class HOPDONG_DTO
    {
        public string SOHD { get; set; }
        public string NGAYBATDAU { get; set; }
        public string NGAYKETTHUC { get; set; }
        public string NGAYKY { get; set; }
        public string NOIDUNG { get; set; }
        public Nullable<int> LANKY { get; set; }
        public string THOIHAN { get; set; }
        public Nullable<double> HESOLUONG { get; set; }
        public int?  LUONGCOBAN { set; get; }
        public Nullable<int> MANV { get; set; }
        public string HOTEN { set; get; }
        public string NGAYSINH { set; get; }
        public string DIENTHOAI { set; get; }
        public string CCCD { set; get; }
        public string DIACHI { set; get; }
        public Nullable<int> MACTY { get; set; }
        public Nullable<int> DELETED_BY { get; set; }
        public Nullable<System.DateTime> DELETED_DATE { get; set; }
        public Nullable<int> UPDATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }

   
    }
}
