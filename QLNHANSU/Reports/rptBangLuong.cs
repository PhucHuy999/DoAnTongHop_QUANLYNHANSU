using DataLayer;
using DevExpress.XtraReports.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;

namespace QLNHANSU.Reports
{
    public partial class rptBangLuong : DevExpress.XtraReports.UI.XtraReport
    {
        public rptBangLuong()
        {
            InitializeComponent();
        }
        List<tb_BANGLUONG> _lst;
        int _namky;
        public rptBangLuong(List<tb_BANGLUONG> _lstBangLuong, int namky)
        {
            InitializeComponent();
            this._lst = _lstBangLuong;
            this._namky = namky;
            lblThangNam.Text = "Tháng " + _namky.ToString().Substring(4) + " Năm " + _namky.ToString().Substring(0, 4);// cắt chuỗi lấy tháng năm ra
            this.DataSource = _lst;
            loadData();
        }
        void loadData()
        {
            lblMANV.DataBindings.Add("Text",DataSource,"MANV");
            lblHOTEN.DataBindings.Add("Text",DataSource,"HOTEN");
            lblNGAYCONGTRONGTHANG.DataBindings.Add("Text",DataSource, "NGAYCONGTRONGTHANG");
            lblSONGAYTHUCLAM.DataBindings.Add("Text",DataSource, "SONGAYTHUCLAM");
            lblNGAYPHEP.DataBindings.Add("Text",DataSource, "NGAYPHEP");
            lblNGAYLE.DataBindings.Add("Text",DataSource, "NGAYLE");
            lblNGAYCHUNHAT.DataBindings.Add("Text",DataSource,"NGAYCHUNHAT");
            lblTANGCA.DataBindings.Add("Text",DataSource, "TANGCA");
            lblPHUCAP.DataBindings.Add("Text",DataSource,"PHUCAP");
            lblUNGLUONG.DataBindings.Add("Text",DataSource, "UNGLUONG");
            lblTHUCLANH.DataBindings.Add("Text",DataSource,"THUCLANH");
            lblNGAYTHUONG.DataBindings.Add("Text",DataSource,"NGAYTHUONG");
        }
    }
}
