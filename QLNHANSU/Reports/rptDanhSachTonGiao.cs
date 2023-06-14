using DataLayer;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace QLNHANSU.Reports
{
    public partial class rptDanhSachTonGiao : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDanhSachTonGiao()
        {
            InitializeComponent();
        }
        List<tb_TONGIAO> _lstTG;
        public rptDanhSachTonGiao(List<tb_TONGIAO> _lstTonGiao)
        {
            InitializeComponent();
            this._lstTG = _lstTonGiao;
            this.DataSource = _lstTG;
            loadData();
        }


        void loadData()
        {
            lblID.DataBindings.Add("Text", DataSource, "ID");
            lblTEN.DataBindings.Add("Text", DataSource, "TENTG");

        }
    }
}
