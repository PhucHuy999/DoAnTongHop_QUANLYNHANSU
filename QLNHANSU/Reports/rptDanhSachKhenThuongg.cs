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
    public partial class rptDanhSachKhenThuongg : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDanhSachKhenThuongg()
        {
            InitializeComponent();
        }
        List<KHENTHUONG_KYLUAT_DTO> _lstKT;
        public rptDanhSachKhenThuongg(List<KHENTHUONG_KYLUAT_DTO> _lstKhenThuong)
        {
            InitializeComponent();
            this._lstKT = _lstKhenThuong;
            this.DataSource = _lstKT;
            loadData();
        }


        void loadData()
        {
            lblsoquyetdinh.DataBindings.Add("Text", _lstKT, "SOQUYETDINH");
            lblhoten.DataBindings.Add("Text", _lstKT, "HOTEN");
            lblngay.DataBindings.Add("Text", _lstKT, "NGAY");
            lbllydo.DataBindings.Add("Text", _lstKT, "LYDO");
            lblnoidung.DataBindings.Add("Text", _lstKT, "NOIDUNG");

        }
    }
}