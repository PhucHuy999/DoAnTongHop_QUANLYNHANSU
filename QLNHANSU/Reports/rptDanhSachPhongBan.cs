using DataLayer;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace QLNHANSU.Reports
{
    public partial class rptDanhSachPhongBan : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDanhSachPhongBan()
        {
            InitializeComponent();
        }
        List<tb_PHONGBAN> _lstPB;
        public rptDanhSachPhongBan(List<tb_PHONGBAN> _lstPhongBan)
        {
            InitializeComponent();
            this._lstPB = _lstPhongBan;
            this.DataSource = _lstPB;
            loadData();
        }


        void loadData()
        {
            lblidpb.DataBindings.Add("Text", DataSource, "IDPB");
            lbltenpb.DataBindings.Add("Text", DataSource, "TENPB");

        }
    }
}
