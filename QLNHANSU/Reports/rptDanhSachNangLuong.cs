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
    public partial class rptDanhSachNangLuong : DevExpress.XtraReports.UI.XtraReport
    {
        public rptDanhSachNangLuong()
        {
            InitializeComponent();
        }
        List<NHANVIEN_NANGLUONG_DTO> _lstNL;
        public rptDanhSachNangLuong(List<NHANVIEN_NANGLUONG_DTO> lstNL)
        {
            InitializeComponent();
            this._lstNL = lstNL;
            this.DataSource = _lstNL;
            loadData();
        }
        void loadData()
        {
            lblsoqd.DataBindings.Add("Text", _lstNL, "SOQD");// (truyền vào kiểu dữ liệu, datasource(_lstNV đã dựng), datamember(tên trường))
            lblhoten.DataBindings.Add("Text", _lstNL, "HOTEN");
            lblhesoluonghientai.DataBindings.Add("Text", _lstNL, "HESOLUONGHIENTAI");
            lblhesoluongmoi.DataBindings.Add("Text", _lstNL, "HESOLUONGMOI");
            lblngaylenluong.DataBindings.Add("Text", _lstNL, "NGAYLENLUONG");
            lblghichu.DataBindings.Add("Text", _lstNL, "GHICHU");
            lbldeleted_by.DataBindings.Add("Text", _lstNL, "DELETED_BY");
        }
    }
}
