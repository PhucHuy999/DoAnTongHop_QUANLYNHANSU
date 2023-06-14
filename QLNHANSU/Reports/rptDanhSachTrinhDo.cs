using DataLayer;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace QLNHANSU.Reports
{
    public partial class rptDanhSachTrinhDo : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDanhSachTrinhDo()
        {
            InitializeComponent();
        }
        List<tb_TRINHDO> _lstTD;
        public rptDanhSachTrinhDo(List<tb_TRINHDO> _lstTrinhDo)
        {
            InitializeComponent();
            this._lstTD = _lstTrinhDo;
            this.DataSource = _lstTD;
            loadData();
        }


        void loadData()
        {
            lblIDTD.DataBindings.Add("Text", DataSource, "IDTD");
            lblTENTD.DataBindings.Add("Text", DataSource, "TENTD");

        }
    }
}
