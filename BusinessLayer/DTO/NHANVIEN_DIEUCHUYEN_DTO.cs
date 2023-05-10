using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class NHANVIEN_DIEUCHUYEN_DTO
    {

        public string SOQD { get; set; }
        public Nullable<System.DateTime> NGAY { get; set; }
        public Nullable<int> MANV { get; set; }
        public string HOTEN { set; get; }
        public Nullable<int> MAPB { get; set; }
        public string TENPB { set; get; }
        public Nullable<int> MAPB2 { get; set; }
        public string TENPB2 { set; get; }
        public Nullable<int> MABP { get; set; }
        public string TENBP { set; get; }
        public Nullable<int> MABP2 { get; set; }
        public string TENBP2 { set; get; }
        public Nullable<int> MACV { get; set; }
        public string TENCV { set; get; }
        public Nullable<int> MACV2 { get; set; }
        public string TENCV2 { set; get; }  
        public string LYDO { get; set; }
        public string GHICHU { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
        public Nullable<int> UPDATED_BY { get; set; }

        public virtual tb_NHANVIEN tb_NHANVIEN { get; set; }
    }
}
