using DataLayer;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace QLNHANSU.Reports
{
    public partial class rptDanhSachLoaiCong : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDanhSachLoaiCong()
        {
            InitializeComponent();
        }
        List<tb_LOAICONG> _lstLCONG;
        public rptDanhSachLoaiCong(List<tb_LOAICONG> _lstLoaiCong)
        {
            InitializeComponent();
            this._lstLCONG = _lstLoaiCong;
            this.DataSource = _lstLCONG;
            loadData();
        }


        void loadData()
        {
            lblidlc.DataBindings.Add("Text", DataSource, "IDLC");
            lbltenlc.DataBindings.Add("Text", DataSource, "TENLC");
            lblheso.DataBindings.Add("Text", DataSource, "HESO");
            lbldelete.DataBindings.Add("Text", DataSource, "DELETED_BY");
        }
    }
}
