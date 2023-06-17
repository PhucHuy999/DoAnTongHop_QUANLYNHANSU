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
using static DevExpress.Utils.Drawing.Helpers.NativeMethods;
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace QLNHANSU
{
    public partial class frmNhanVien_DieuChuyen : DevExpress.XtraEditors.XtraForm
    {
        public frmNhanVien_DieuChuyen()
        {
            InitializeComponent();
        }
        bool _them;
        string _soQD; //để sửa
        NHANVIEN_DIEUCHUYEN _nvdc;
        NHANVIEN _nhanvien;
        PHONGBAN _phongban;
        BOPHAN _bophan;
        CHUCVU _chucvu;
        List<NHANVIEN_DIEUCHUYEN_DTO> _lstNVDCDTO;

        private void frmNhanVien_DieuChuyen_Load(object sender, EventArgs e)
        {
             _nvdc = new NHANVIEN_DIEUCHUYEN(Program.UserId);
            _nhanvien = new NHANVIEN();
            _phongban = new PHONGBAN();
            _bophan = new BOPHAN();
            _chucvu = new CHUCVU();
            _them = false;
            _showHide(true);
            loadNhanVien();
            loadPhongBanDen();
            loadBoPhanDen();
            loadChucVuDen();
            loadData();

            splitContainer1.Panel1Collapsed = true;
        }
        private void _reset()// reset lai trang text khi sử dụng chức năng thêm
        {
            txtSoQD.Text = string.Empty;
            txtLyDo.Text = string.Empty;
            txtGhiChu.Text = string.Empty;

            
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
            dtNgay.Enabled = !kt;
            cboPhongBanDen.Enabled = !kt;  
            cboBoPhanDen.Enabled = !kt;
            cboChucVuDen.Enabled = !kt; 

            slkNhanVien.Enabled = !kt;

        }
        void loadPhongBanDen()
        {
            cboPhongBanDen.DataSource = _phongban.getList();
            cboPhongBanDen.DisplayMember = "TENPB";
            cboPhongBanDen.ValueMember = "IDPB";
        }
        void loadBoPhanDen()
        {
            cboBoPhanDen.DataSource = _bophan.getList();
            cboBoPhanDen.DisplayMember = "TENBP";
            cboBoPhanDen.ValueMember = "IDBP";
        }
        void loadChucVuDen()
        {
            cboChucVuDen.DataSource = _chucvu.getList();
            cboChucVuDen.DisplayMember = "TENCV";
            cboChucVuDen.ValueMember = "IDCV";
        }
        private void loadData()
        {
            gcDanhSach.DataSource = _nvdc.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
            _lstNVDCDTO = _nvdc.getListFull();

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

        //private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
        //    {
        //        _nvdc.Delete(_soQD, 1);// chưa xây dựng chức năng đăng nhập nên truyền thẳng manv==1 vào tạm
        //        loadData();
        //    }
        //}

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
            rptDanhSachDieuChuyen rpt = new rptDanhSachDieuChuyen(_lstNVDCDTO);
            rpt.ShowRibbonPreview();
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }

        
        private void SaveData()
        {
            tb_NHANVIEN_DIEUCHUYEN dc;
            if (_them)
            {
                //số hđ có dạng: 00001/2023/HĐĐC
                var maxSoQD = _nvdc.MaxSoQuyetDinh(); 
                int so = int.Parse(maxSoQD.Substring(0, 5)) + 1;
                dc = new tb_NHANVIEN_DIEUCHUYEN();
                dc.SOQD = so.ToString("00000") + @"/"+DateTime.Now.Year.ToString()+@"/QĐĐC";            
                dc.NGAY = dtNgay.Value;
                dc.LYDO = txtLyDo.Text;
                dc.GHICHU = txtGhiChu.Text;
                dc.MANV = int.Parse(slkNhanVien.EditValue.ToString());

                dc.MAPB = _nhanvien.getItem(int.Parse(slkNhanVien.EditValue.ToString())).IDPB;
                dc.MAPB2 = int.Parse(cboPhongBanDen.SelectedValue.ToString());

                dc.MABP = _nhanvien.getItem(int.Parse(slkNhanVien.EditValue.ToString())).IDBP;
                dc.MABP2 = int.Parse(cboBoPhanDen.SelectedValue.ToString());

                dc.MACV = _nhanvien.getItem(int.Parse(slkNhanVien.EditValue.ToString())).IDCV;
                dc.MACV2 = int.Parse(cboChucVuDen.SelectedValue.ToString());


                dc.CREATED_BY = Program.UserId;
                dc.CREATED_DATE = DateTime.Now;
               

                _nvdc.Add(dc);
            }
            else
            {
                dc = _nvdc.getItem(_soQD);
                dc.NGAY = dtNgay.Value;
                dc.LYDO = txtLyDo.Text;
                dc.GHICHU = txtGhiChu.Text;
                dc.MANV = int.Parse(slkNhanVien.EditValue.ToString());               
                dc.MAPB2 = int.Parse(cboPhongBanDen.SelectedValue.ToString());
                dc.MABP2 = int.Parse(cboBoPhanDen.SelectedValue.ToString());
                dc.MACV2 = int.Parse(cboChucVuDen.SelectedValue.ToString());
                dc.UPDATED_BY = Program.UserId;
                dc.UPDATED_DATE = DateTime.Now;

                _nvdc.Update(dc);
            }
            var nv = _nhanvien.getItem(dc.MANV.Value); // thêm vẫn phải update
            nv.IDPB = dc.MAPB2;
            nv.IDBP = dc.MABP2;
            nv.IDCV = dc.MACV2;

            _nhanvien.Update(nv);
        }
        
        private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Name == "DELETED_BY" && e.CellValue!=null)
            {
                Image img = Properties.Resources.del_Icon;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
        }

        private void gcDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _soQD = gvDanhSach.GetFocusedRowCellValue("SOQD").ToString();

                var dc = _nvdc.getItem(_soQD);
                txtSoQD.Text = _soQD;
                dtNgay.Value = dc.NGAY.Value;
                slkNhanVien.EditValue = dc.MANV;
                txtGhiChu.Text = dc.GHICHU;
                txtLyDo.Text = dc.LYDO;
                cboPhongBanDen.SelectedValue = dc.MAPB2;
                cboBoPhanDen.SelectedValue = dc.MABP2;
                cboChucVuDen.SelectedValue = dc.MACV2;
                
            }
        }
    }
}