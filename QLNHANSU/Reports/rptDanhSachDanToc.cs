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
    public partial class rptDanhSachDanToc : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDanhSachDanToc()
        {
            InitializeComponent();
        }

        List<tb_DANTOC> _lstDT;
        public rptDanhSachDanToc(List<tb_DANTOC> _lstDanToc)
        {
            InitializeComponent();
            this._lstDT = _lstDanToc;
            this.DataSource = _lstDT;
            loadData();
        }

        
        void loadData()
        {
            lblID.DataBindings.Add("Text", DataSource, "ID");
            lblTEN.DataBindings.Add("Text", DataSource, "TENDT");
            
        }




    }
}
