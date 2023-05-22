using BusinessLayer;
using DevExpress.XtraEditors;
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

namespace QLNHANSU.Reports
{
    public partial class frmInBangCongChiTiet : DevExpress.XtraEditors.XtraForm
    {
        public frmInBangCongChiTiet()
        {
            InitializeComponent();
        }
        NHANVIEN _nhanvienn;
        BANGCONG_NHANVIEN_CHITIET _bcnvct;
        private void frmInBangCongChiTiet_Load(object sender, EventArgs e)
        {
            _nhanvienn = new NHANVIEN();
            _bcnvct = new BANGCONG_NHANVIEN_CHITIET();
            loadNhanVien();
            cboKyCong.SelectedIndex = DateTime.Now.Month - 1; //SelectedIndex lấy từ 0 nên muốn lấy tháng hiện tại thì -1

        }
        void loadNhanVien()
        {
            cboNhanVienn.DataSource = _nhanvienn.getList();
            cboNhanVienn.DisplayMember = "HOTEN";
            cboNhanVienn.ValueMember = "MANV";
        }
        private void btnIn_Click(object sender, EventArgs e)
        {
            var lst = _bcnvct.getBangCongChiTiet(DateTime.Now.Year * 100 + int.Parse(cboKyCong.Text), int.Parse(cboNhanVienn.SelectedValue.ToString()));
            rptBangCongNhanVienChiTiet rpt = new rptBangCongNhanVienChiTiet(lst);
            rpt.ShowPreviewDialog();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}