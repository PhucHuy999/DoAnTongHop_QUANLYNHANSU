using DataLayer;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace QLNHANSU.Reports
{
    public partial class rptDanhSachBoPhan : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDanhSachBoPhan()
        {
            InitializeComponent();
        }
        List<tb_BOPHAN> _lstBP;
        public rptDanhSachBoPhan(List<tb_BOPHAN> _lstBoPhan)
        {
            InitializeComponent();
            this._lstBP = _lstBoPhan;
            this.DataSource = _lstBP;
            loadData();
        }


        void loadData()
        {
            lblidbp.DataBindings.Add("Text", DataSource, "IDBP");
            lbltenbp.DataBindings.Add("Text", DataSource, "TENBP");

        }
    }
}
