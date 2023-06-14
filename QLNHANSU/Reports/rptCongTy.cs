using DataLayer;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace QLNHANSU.Reports
{
    public partial class rptCongTy : DevExpress.XtraReports.UI.XtraReport
    {
        public rptCongTy()
        {
            InitializeComponent();
        }
        List<tb_CONGTY> _lstCT;
        public rptCongTy(List<tb_CONGTY> _lstCongTy)
        {
            InitializeComponent();
            this._lstCT = _lstCongTy;
            this.DataSource = _lstCT;
            loadData();
        }


        void loadData()
        {
            lblmacty.DataBindings.Add("Text", DataSource, "MACTY");
            lbltencty.DataBindings.Add("Text", DataSource, "TENCTY");
            lbldienthoai.DataBindings.Add("Text", DataSource, "DIENTHOAI");
            lblemail.DataBindings.Add("Text", DataSource, "EMAIL");
            lbldiachi.DataBindings.Add("Text", DataSource, "DIACHI");

        }
    }
}
