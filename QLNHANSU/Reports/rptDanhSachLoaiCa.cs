using DataLayer;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace QLNHANSU.Reports
{
    public partial class rptDanhSachLoaiCa : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDanhSachLoaiCa()
        {
            InitializeComponent();
        }
        List<tb_LOAICA> _lstLC;
        public rptDanhSachLoaiCa(List<tb_LOAICA> _lstLoaiCa)
        {
            InitializeComponent();
            this._lstLC = _lstLoaiCa;
            this.DataSource = _lstLC;
            loadData();
        }


        void loadData()
        {
            lblidloaica.DataBindings.Add("Text", DataSource, "IDLOAICA");
            lbltenloaica.DataBindings.Add("Text", DataSource, "TENLOAICA");
            lblheso.DataBindings.Add("Text", DataSource, "HESO");
            lbldelete.DataBindings.Add("Text", DataSource, "DELETED_BY");
        }
    }
}
