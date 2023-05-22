using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using DataLayer;
using System.Collections.Generic;

namespace QLNHANSU.Reports
{
    public partial class rptBangCongChiTiet : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBangCongChiTiet()
        {
            InitializeComponent();
        }
        public List<tb_BANGCONG_NHANVIEN_CHITIET> _bcct;
        public rptBangCongChiTiet(List<tb_BANGCONG_NHANVIEN_CHITIET> bcct)
        {
            InitializeComponent();
            this._bcct = bcct;
            this.DataSource=_bcct;
            BindingData();
        }
        void BindingData()
        {
            lblMANV.DataBindings.Add("Text", DataSource, "MANV");
            lblHOTEN.DataBindings.Add("Text", DataSource, "HOTEN");
            lblNGAY.DataBindings.Add("Text", DataSource, "NGAY");
            lblTHU.DataBindings.Add("Text", DataSource, "THU");
            lblGIOVAO.DataBindings.Add("Text", DataSource, "GIOVAO");
            lblGIORA.DataBindings.Add("Text", DataSource, "GIORA");
            lblNGAYPHEP.DataBindings.Add("Text", DataSource, "NGAYPHEP");
            lblNGAYLE.DataBindings.Add("Text", DataSource, "CONGNGAYLE");
            lblCHUNHAT.DataBindings.Add("Text", DataSource, "CONGCHUNHAT");
            lblNGAYCONG.DataBindings.Add("Text", DataSource, "NGAYCONG");
            lblNGHIKHONGPHEP.DataBindings.Add("Text", DataSource, "NGHIKHONGPHEP");
            lblKYHIEU.DataBindings.Add("Text", DataSource, "KYHIEU");
            lblGHICHU.DataBindings.Add("Text", DataSource, "GHICHU");
        }
    }
}
