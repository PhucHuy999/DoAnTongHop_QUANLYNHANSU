using BusinessLayer.DTO;
using DataLayer;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace QLNHANSU.Reports
{
    public partial class rptDanhSachUngLuong : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDanhSachUngLuong()
        {
            InitializeComponent();
        }
        List<UNGLUONG_DTO> _lstUL;
        public rptDanhSachUngLuong(List<UNGLUONG_DTO> lstUL)
        {
            InitializeComponent();
            this._lstUL = lstUL;
            this.DataSource = _lstUL;
            loadData();
        }
        void loadData()
        {
            lblid.DataBindings.Add("Text", _lstUL, "ID");// (truyền vào kiểu dữ liệu, datasource(_lstNV đã dựng), datamember(tên trường))
            lblnam.DataBindings.Add("Text", _lstUL, "NAM");
            lblthang.DataBindings.Add("Text", _lstUL, "THANG");
            lblngay.DataBindings.Add("Text", _lstUL, "NGAY");
            lblhoten.DataBindings.Add("Text", _lstUL, "HOTEN");
            lblsotien.DataBindings.Add("Text", _lstUL, "SOTIEN");
            lblghichu.DataBindings.Add("Text", _lstUL, "GHICHU");
            lbldelete.DataBindings.Add("Text", _lstUL, "DELETED_BY");

        }
    }
}
