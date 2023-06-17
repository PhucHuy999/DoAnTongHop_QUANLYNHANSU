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
    public partial class rptDanhSachThoiViec : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDanhSachThoiViec()
        {
            InitializeComponent();
        }
        List<NHANVIEN_THOIVIEC_DTO> _lstNVTV;
        public rptDanhSachThoiViec(List<NHANVIEN_THOIVIEC_DTO> lstNVTV)
        {
            InitializeComponent();
            this._lstNVTV = lstNVTV;
            this.DataSource = _lstNVTV;
            loadData();
        }
        void loadData()
        {
            lblsoqd.DataBindings.Add("Text", _lstNVTV, "SOQD");// (truyền vào kiểu dữ liệu, datasource(_lstNV đã dựng), datamember(tên trường))
            lblhoten.DataBindings.Add("Text", _lstNVTV, "HOTEN");
            lblngaynopdon.DataBindings.Add("Text", _lstNVTV, "NGAYNOPDON");
            lblngaynghi.DataBindings.Add("Text", _lstNVTV, "NGAYNGHI");
            lbldelete.DataBindings.Add("Text", _lstNVTV, "DELETED_BY");
            lbllydo.DataBindings.Add("Text", _lstNVTV, "LYDO");
            lblghichu.DataBindings.Add("Text", _lstNVTV, "GHICHU");
            

        }
    }
}
