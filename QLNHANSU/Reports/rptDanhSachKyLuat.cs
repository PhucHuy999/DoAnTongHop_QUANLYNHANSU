using BusinessLayer.DTO;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace QLNHANSU.Reports
{
    public partial class rptDanhSachKyLuat : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDanhSachKyLuat()
        {
            InitializeComponent();
        }
        List<KHENTHUONG_KYLUAT_DTO> _lstKL;
        public rptDanhSachKyLuat(List<KHENTHUONG_KYLUAT_DTO> _lstKhenThuong)
        {
            InitializeComponent();
            this._lstKL = _lstKhenThuong;
            this.DataSource = _lstKL;
            loadData();
        }


        void loadData()
        {
            lblsoquyetdinh.DataBindings.Add("Text", _lstKL, "SOQUYETDINH");
            lblhoten.DataBindings.Add("Text", _lstKL, "HOTEN");
            lblngay.DataBindings.Add("Text", _lstKL, "NGAY");
            lbllydo.DataBindings.Add("Text", _lstKL, "LYDO");
            lblnoidung.DataBindings.Add("Text", _lstKL, "NOIDUNG");

        }
    }
}
