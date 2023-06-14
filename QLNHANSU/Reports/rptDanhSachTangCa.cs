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
    public partial class rptDanhSachTangCa : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDanhSachTangCa()
        {
            InitializeComponent();
        }
        List<TANGCA_DTO> _lstTC;
        public rptDanhSachTangCa(List<TANGCA_DTO> lstTC)
        {
            InitializeComponent();
            this._lstTC = lstTC;
            this.DataSource = _lstTC;
            loadData();
        }
        void loadData()
        {
            lblid.DataBindings.Add("Text", _lstTC, "ID");// (truyền vào kiểu dữ liệu, datasource(_lstNV đã dựng), datamember(tên trường))
            lblnam.DataBindings.Add("Text", _lstTC, "NAM");
            lblthang.DataBindings.Add("Text", _lstTC, "THANG");
            lblngay.DataBindings.Add("Text", _lstTC, "NGAY");
            lblsogio.DataBindings.Add("Text", _lstTC, "SOGIO");
            lblhoten.DataBindings.Add("Text", _lstTC, "HOTEN");
            lblloaica.DataBindings.Add("Text", _lstTC, "TENLOAICA");
            lblsotien.DataBindings.Add("Text", _lstTC, "SOTIEN");
            lblghichu.DataBindings.Add("Text", _lstTC, "GHICHU");
            lbldelete.DataBindings.Add("Text", _lstTC, "DELETED_BY");

        }
    }
}
