using BusinessLayer;
using DevExpress.XtraEditors;
using QLNHANSU.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DataLayer;
using DevExpress.Accessibility;

namespace QLNHANSU.TINHLUONG
{
    public partial class frmBangLuong : DevExpress.XtraEditors.XtraForm
    {
        string IDUSER;
        public frmBangLuong()
        {
            InitializeComponent();
        }
        public frmBangLuong(string IDUSER)
        {
            InitializeComponent();
            this.IDUSER = IDUSER;
        }

        BANGLUONG _bangluong;
        List<tb_BANGLUONG> _lstBangLuong;
        int _namky;
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmBangLuong_Load(object sender, EventArgs e)
        {
            _bangluong = new BANGLUONG();
            cboNam.Text = DateTime.Now.Year.ToString();
            cboThang.Text = DateTime.Now.Month.ToString();

        }

        private void btnTinhLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _bangluong.TinhLuongNhanVien(int.Parse(cboNam.Text) *100+ int.Parse(cboThang.Text));
            loadData();
            
        }
        void loadData()
        {
            gcDanhSach.DataSource = _bangluong.getList(int.Parse(cboNam.Text) *100+ int.Parse(cboThang.Text));
            gvDanhSach.OptionsBehavior.Editable = false;
            _lstBangLuong = _bangluong.getList(int.Parse(cboNam.Text) * 100 + int.Parse(cboThang.Text));
            _namky = int.Parse(cboNam.Text) * 100 + int.Parse(cboThang.Text);
        }
        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rptBangLuong rpt = new rptBangLuong(_lstBangLuong,_namky);
            rpt.ShowPreviewDialog();
        }
        
        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        private void btnXemBangLuong_Click(object sender, EventArgs e)
        {
            loadData();
        }
    }
}