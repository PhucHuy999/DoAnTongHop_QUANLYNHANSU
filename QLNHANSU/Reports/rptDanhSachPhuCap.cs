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
    public partial class rptDanhSachPhuCap : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDanhSachPhuCap()
        {
            InitializeComponent();
        }
        List<NHANVIEN_PHUCAP_DTO> _lstPC;
        public rptDanhSachPhuCap(List<NHANVIEN_PHUCAP_DTO> lstNV)
        {
            InitializeComponent();
            this._lstPC = lstNV;
            this.DataSource = _lstPC;
            loadData();
        }
        void loadData()
        {
            lblid.DataBindings.Add("Text", _lstPC, "ID");// (truyền vào kiểu dữ liệu, datasource(_lstNV đã dựng), datamember(tên trường))
            lblhoten.DataBindings.Add("Text", _lstPC, "HOTEN");
            lblphucap.DataBindings.Add("Text", _lstPC, "TENPC");
            lblngay.DataBindings.Add("Text", _lstPC, "NGAY");
            lblsotien.DataBindings.Add("Text", _lstPC, "SOTIEN");
            lblnoidung.DataBindings.Add("Text", _lstPC, "NOIDUNG");
            lbldelete.DataBindings.Add("Text", _lstPC, "DELETED_BY");

        }
    }
}
