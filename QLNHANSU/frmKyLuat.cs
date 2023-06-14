using BusinessLayer;
using BusinessLayer.DTO;
using DataLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraReports.UI;
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

namespace QLNHANSU
{
    public partial class frmKyLuat : DevExpress.XtraEditors.XtraForm
    {
        public frmKyLuat()
        {
            InitializeComponent();
        }
        bool _them;
        string _soQD; 
        KHENTHUONG_KYLUAT _ktkl;
        NHANVIEN _nhanvien;
        List<KHENTHUONG_KYLUAT_DTO> _lstKL;

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmKyLuat_Load(object sender, EventArgs e)
        {
            _ktkl = new KHENTHUONG_KYLUAT(Program.UserId);
            _nhanvien = new NHANVIEN();
            _them = false;
            _showHide(true);
            loadNhanVien();
            loadData();

            splitContainer1.Panel1Collapsed = true;
        }
        private void _reset()// reset lai trang text khi sử dụng chức năng thêm
        {
            txtSoQD.Text = string.Empty;
            txtLyDo.Text = string.Empty;
            txtNoiDung.Text = string.Empty;

            //dtNgayBatDau.Value = DateTime.Now;
            //dtNgayKetThuc.Value = dtNgayBatDau.Value.AddMonths(6);


            // picHinhAnh.Image = null;
        }
        void loadNhanVien()
        {
            slkNhanVien.Properties.DataSource = _nhanvien.getList();
            slkNhanVien.Properties.ValueMember = "MANV";
            slkNhanVien.Properties.DisplayMember = "HOTEN";
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
            txtSoQD.Enabled = !kt;
            txtLyDo.Enabled = !kt;
            txtNoiDung.Enabled = !kt;
            dtNgay.Enabled = !kt;
            dtTuNgay.Enabled = !kt;
            dtDenNgay.Enabled = !kt;
            //chkDisabled.Enabled = kt;
            //dtNgayBatDau.Enabled = !kt;
            //dtNgayKetThuc.Enabled = !kt;

            slkNhanVien.Enabled = !kt;

        }
        private void loadData()
        {
            gcDanhSach.DataSource = _ktkl.getListFull(2);
            gvDanhSach.OptionsBehavior.Editable = false;
            _lstKL = _ktkl.getListFull(2);

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
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _ktkl.Delete(_soQD);// chưa xây dựng chức năng đăng nhập nên truyền thẳng manv==1 vào tạm
                loadData();
            }
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
            rptDanhSachKyLuat rpt = new rptDanhSachKyLuat(_lstKL);
            rpt.ShowRibbonPreview();
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void SaveData()
        {

            if (_them)
            {
                //số hđ có dạng: 00001/2023/QĐKL
                var maxSoQD = _ktkl.MaxSoQuyetDinh(2); //loại "1" là khen thưởng
                int so = int.Parse(maxSoQD.Substring(0, 5)) + 1;

                tb_KHENTHUONG_KYLUAT kl = new tb_KHENTHUONG_KYLUAT();
                kl.SOQUYETDINH = so.ToString("00000") + @"/2023/QĐKL";
                //hd.NGAYBATDAU = dtNgayBatDau.Value;
                //hd.NGAYKETTHUC = dtNgayKetThuc.Value;
                kl.TUNGAY = dtTuNgay.Value;
                kl.DENNGAY = dtDenNgay.Value;
                kl.NGAY = dtNgay.Value;
                kl.LYDO = txtLyDo.Text;
                kl.NOIDUNG = txtNoiDung.Text;
                kl.MANV = int.Parse(slkNhanVien.EditValue.ToString());
                kl.LOAI = 2; // loại 2 là KỶ LUẬT
                kl.CREATED_BY = Program.UserId;
                kl.CREATED_DATE = DateTime.Now;
                kl.DISABLED = chkDisabled.Checked;
                _ktkl.Add(kl);
            }
            else
            {
                var kl = _ktkl.getItem(_soQD);
                //hd.SOHD = so.ToString("00000") + @"/2023/HĐLĐ"; //số hợp đồng k cho sửa 
                //hd.NGAYBATDAU = dtNgayBatDau.Value;
                //hd.NGAYKETTHUC = dtNgayKetThuc.Value;
                kl.NGAY = dtNgay.Value;
                kl.TUNGAY = dtTuNgay.Value;
                kl.DENNGAY = dtDenNgay.Value;
                kl.MANV = int.Parse(slkNhanVien.EditValue.ToString());
                kl.LYDO = txtLyDo.Text;
                kl.NOIDUNG = txtNoiDung.Text;
                kl.UPDATED_BY = Program.UserId;
                kl.UPDATED_DATE = DateTime.Now;
                kl.DISABLED = chkDisabled.Checked;
                _ktkl.Update(kl);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _soQD = gvDanhSach.GetFocusedRowCellValue("SOQUYETDINH").ToString();

                var kl = _ktkl.getItem(_soQD);
                txtSoQD.Text = _soQD;
                //dtNgayBatDau.Value = hd.NGAYBATDAU.Value;
                //dtNgayKetThuc.Value = hd.NGAYKETTHUC.Value;
                dtNgay.Value = kl.NGAY.Value;
                dtTuNgay.Value = kl.TUNGAY.Value;
                dtDenNgay.Value = kl.DENNGAY.Value;
                slkNhanVien.EditValue = kl.MANV;
                txtNoiDung.Text = kl.NOIDUNG;
                txtLyDo.Text = kl.LYDO;
                //_lstHD = _hdld.getItemFull(_soHD);
                chkDisabled.Checked = bool.Parse(gvDanhSach.GetFocusedRowCellValue("DISABLED").ToString());

                //splitContainer1.Panel1Collapsed = false;
            }
        }
        

        private void gvDanhSach_CustomDrawCell_1(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Name == "DISABLED" && bool.Parse(e.CellValue.ToString()) == true)
            {
                Image img = Properties.Resources.del_Icon;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
        }
    }
}