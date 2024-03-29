﻿using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.DTO
{
    public class TANGCA_DTO
    {
        public int ID { get; set; }
        public Nullable<int> NAM { get; set; }
        public Nullable<int> THANG { get; set; }
        public Nullable<int> NGAY { get; set; }


        public Nullable<double> SOGIO { get; set; }
        public Nullable<int> MANV { get; set; }
        public string HOTEN { set; get; }
        public Nullable<int> IDLOAICA { get; set; }
        public string TENLOAICA { set; get; }
        public double? HESO { set; get; }
        public double? SOTIEN { set; get; }
        public string GHICHU { get; set; }
        public Nullable<int> CREATED_BY { get; set; }
        public Nullable<System.DateTime> CREATED_DATE { get; set; }
        public Nullable<int> UPDATED_BY { get; set; }
        public Nullable<System.DateTime> UPDATED_DATE { get; set; }
        public Nullable<int> DELETED_BY { get; set; }
        public Nullable<System.DateTime> DELETED_DATE { get; set; }

        public virtual tb_LOAICA tb_LOAICA { get; set; }
        public virtual tb_NHANVIEN tb_NHANVIEN { get; set; }
    }
}
