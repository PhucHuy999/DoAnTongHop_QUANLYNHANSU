using DataLayer;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace QLNHANSU.Reports
{
    public partial class rptDanhSachChucVu : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDanhSachChucVu()
        {
            InitializeComponent();
        }
        List<tb_CHUCVU> _lstCV;
        public rptDanhSachChucVu(List<tb_CHUCVU> _lstChucVu)
        {
            InitializeComponent();
            this._lstCV = _lstChucVu;
            this.DataSource = _lstCV;
            loadData();
        }


        void loadData()
        {
            lblidcv.DataBindings.Add("Text", DataSource, "IDCV");
            lbltencv.DataBindings.Add("Text", DataSource, "TENCV");

        }
    }
}
