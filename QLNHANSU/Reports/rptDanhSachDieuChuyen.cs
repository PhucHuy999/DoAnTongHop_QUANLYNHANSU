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
    public partial class rptDanhSachDieuChuyen : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDanhSachDieuChuyen()
        {
            InitializeComponent();
        }
        List<NHANVIEN_DIEUCHUYEN_DTO> _lstNVDC;
        public rptDanhSachDieuChuyen(List<NHANVIEN_DIEUCHUYEN_DTO> lstNVDC)
        {
            InitializeComponent();
            this._lstNVDC = lstNVDC;
            this.DataSource = _lstNVDC;
            loadData();
        }
        void loadData()
        {
            lblsoqd.DataBindings.Add("Text", _lstNVDC, "SOQD");// (truyền vào kiểu dữ liệu, datasource(_lstNV đã dựng), datamember(tên trường))
            lblnhanvien.DataBindings.Add("Text", _lstNVDC, "HOTEN");
            lblngay.DataBindings.Add("Text", _lstNVDC, "NGAY");
            lblpbcu.DataBindings.Add("Text", _lstNVDC, "TENPB");
            lblpbmoi.DataBindings.Add("Text", _lstNVDC, "TENPB2");
            lblbpcu.DataBindings.Add("Text", _lstNVDC, "TENBP");
            lblbpmoi.DataBindings.Add("Text", _lstNVDC, "TENBP2");
            lblcvcu.DataBindings.Add("Text", _lstNVDC, "TENCV");
            lblcvmoi.DataBindings.Add("Text", _lstNVDC, "TENCV2");
            lbllydo.DataBindings.Add("Text", _lstNVDC, "LYDO");
            lblghichu.DataBindings.Add("Text", _lstNVDC, "GHICHU");


        }
    }
}
