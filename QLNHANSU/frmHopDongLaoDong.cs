using DataLayer;
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
using BusinessLayer;

namespace QLNHANSU
{
    public partial class frmHopDongLaoDong : DevExpress.XtraEditors.XtraForm
    {

        HOPDONGLAODONG _hdld;
        bool _them;
        string _soHD;
        public frmHopDongLaoDong()
        {
            InitializeComponent();
        }
        private void frmHopDongLaoDong_Load(object sender, EventArgs e)
        {
            _hdld = new HOPDONGLAODONG();
            _them = false;
            _showHide(true);
            loadData();
            splitContainer1.Panel1Collapsed = true;
        }
        private void _reset()// reset lai trang text khi sử dụng chức năng thêm
        {
            txtSoHD.Text = string.Empty;
            dtNgayBatDau.Value = DateTime.Now;
            dtNgayKetThuc.Value = dtNgayBatDau.Value.AddMonths(6);
            dtNgayKy.Value = DateTime.Now;
            spLanKy.Text = "1";
            spHeSoLuong.Text = "1";

            // picHinhAnh.Image = null;
        }
        private void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;//// mới chạy thì lưu và hủy cho nó mờ đi
            btnHuy.Enabled = !kt;////
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            btnIn.Enabled = kt;        
            gcDanhSach.Enabled = kt;
            txtSoHD.Enabled = !kt;
            dtNgayBatDau.Enabled = !kt;
            dtNgayKetThuc.Enabled = !kt;
            dtNgayKy.Enabled = !kt;
            spHeSoLuong.Enabled = !kt;
            spLanKy.Enabled=!kt;
            slkNhanVien.Enabled = !kt;

        }
        private void loadData()
        {
            gcDanhSach.DataSource = _hdld.getList();
            gvDanhSach.OptionsBehavior.Editable = false;
           
        }
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
 
        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
            _reset();
            splitContainer1.Panel1Collapsed = false; // khi thêm thì mới sổ cái bảng trên ra
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = false;
            //picHinhAnh.Image = _hinh;
            splitContainer1.Panel1Collapsed = false; // khi sửa thì mới sổ cái bảng trên ra
            gcDanhSach.Enabled = true;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _hdld.Delete(_soHD,1);
            loadData();
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            loadData();
            _showHide(true);
            _them = false;
            //splitContainer1.Panel1Collapsed = true;
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);
            //splitContainer1.Panel1Collapsed = true; // khi hủy thì cũng ẩn đi
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();   
        }
        private void SaveData()
        {


            if (_them)
            {
                

            }
            else
            {
               
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _soHD = gvDanhSach.GetFocusedRowCellValue("SOHD").ToString();
              
                //splitContainer1.Panel1Collapsed = false;
            }
        }
    }
}