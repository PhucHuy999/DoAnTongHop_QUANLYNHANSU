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
    public partial class frmNhanVien_ThoiViec : DevExpress.XtraEditors.XtraForm
    {
        public frmNhanVien_ThoiViec()
        {
            InitializeComponent();
        }
        bool _them;
        string _soQD; //để sửa
        NHANVIEN_THOIVIEC _nvtv;
        NHANVIEN _nhanvien;
        List<NHANVIEN_THOIVIEC_DTO> _lstNVTVDTO;

        private void frmNhanVien_ThoiViec_Load(object sender, EventArgs e)
        {
            _nvtv = new NHANVIEN_THOIVIEC(Program.UserId);
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
            txtGhiChu.Text = string.Empty;
            dtNgayNopDon.Value= DateTime.Now;
            dtNgayNghi.Value= dtNgayNopDon.Value.AddDays(45);//thường thì sau khi nộp đơn 45 ngày là nghỉ


        }
        void loadNhanVien()
        {
            slkNhanVien.Properties.DataSource = _nhanvien.getListFull();
            slkNhanVien.Properties.ValueMember = "MANV";
            slkNhanVien.Properties.DisplayMember = "HOTEN";
            //slkNhanVien.Properties.ValueMember = "MAPB";
            //slkNhanVien.Properties.DisplayMember = "TENPB";
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
            txtGhiChu.Enabled = !kt;
            dtNgayNopDon.Enabled = !kt;
            slkNhanVien.Enabled = !kt;


        }
        
        private void loadData()
        {
            gcDanhSach.DataSource = _nvtv.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
            _lstNVTVDTO = _nvtv.getListFull();
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
                _nvtv.Delete(_soQD);// chưa xây dựng chức năng đăng nhập nên truyền thẳng manv==1 vào tạm
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
            rptDanhSachThoiViec rpt = new rptDanhSachThoiViec(_lstNVTVDTO);
            rpt.ShowRibbonPreview();
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void SaveData()
        {
            tb_NHANVIEN_THOIVIEC tv;
            if (_them)
            {
                //số hđ có dạng: 00001/2023/QĐTV
                var maxSoQD = _nvtv.MaxSoQuyetDinh();
                int so = int.Parse(maxSoQD.Substring(0, 5)) + 1;

                tv = new tb_NHANVIEN_THOIVIEC();
                tv.SOQD = so.ToString("00000") + @"/" + DateTime.Now.Year.ToString() + @"/QĐTV";
                tv.NGAYNOPDON = dtNgayNopDon.Value;
                tv.NGAYNGHI = dtNgayNghi.Value;
                tv.LYDO = txtLyDo.Text;
                tv.GHICHU = txtGhiChu.Text;
                tv.MANV = int.Parse(slkNhanVien.EditValue.ToString());

                tv.CREATED_BY = Program.UserId;
                tv.CREATED_DATE = DateTime.Now;


                _nvtv.Add(tv);
            }
            else
            {
                tv  = _nvtv.getItem(_soQD);
                tv.NGAYNOPDON = dtNgayNopDon.Value;
                tv.NGAYNGHI = dtNgayNghi.Value;
                tv.LYDO = txtLyDo.Text;
                tv.GHICHU = txtGhiChu.Text;
                tv.MANV = int.Parse(slkNhanVien.EditValue.ToString());               
                tv.UPDATED_BY = Program.UserId;
                tv.UPDATED_DATE = DateTime.Now;

                _nvtv.Update(tv);
            }
            var nv = _nhanvien.getItem(tv.MANV.Value); // thêm vẫn phải update
            nv.DATHOIVIEC = true;          

            _nhanvien.Update(nv);
        }
        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _soQD = gvDanhSach.GetFocusedRowCellValue("SOQD").ToString();

                var tv = _nvtv.getItem(_soQD);
                txtSoQD.Text = _soQD;
                dtNgayNopDon.Value = tv.NGAYNOPDON.Value;
                dtNgayNghi.Value = tv.NGAYNGHI.Value;
                slkNhanVien.EditValue = tv.MANV;
                txtGhiChu.Text = tv.GHICHU;
                txtLyDo.Text = tv.LYDO;
              

            }
        }

        

        private void dtNgayNopDon_ValueChanged(object sender, EventArgs e)
        {
            dtNgayNghi.Value = dtNgayNopDon.Value.AddDays(45);
        }

        private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Name == "DELETED_BY" && e.CellValue != null)
            {
                Image img = Properties.Resources.del_Icon;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
        }
    }
}