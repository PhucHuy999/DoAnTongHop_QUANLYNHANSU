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
using static DevExpress.XtraEditors.Mask.MaskSettings;

namespace QLNHANSU
{
    public partial class frmQuanLyLuong : DevExpress.XtraEditors.XtraForm
    {
        public frmQuanLyLuong()
        {
            InitializeComponent();
        }
        bool _them;
        string _soQD; //để sửa
        NHANVIEN_NANGLUONG _nvnl;
        HOPDONGLAODONG _hopdong;
        NHANVIEN _nv;
        List<NHANVIEN_NANGLUONG_DTO> _lstNVNLDTO;
        private void frmQuanLyLuong_Load(object sender, EventArgs e)
        {
            _nvnl = new NHANVIEN_NANGLUONG(Program.UserId);
            _hopdong = new HOPDONGLAODONG();
            _nv = new NHANVIEN();

            _them = false;
            _showHide(true);
            loadHopDong();

            loadData();

            splitContainer1.Panel1Collapsed = true;
        }
        private void _reset()// reset lai trang text khi sử dụng chức năng thêm
        {
            //spHSLMoi.Value = string.Empty;
            //txtSoQD.Text = string.Empty;           
            txtGhiChu.Text = string.Empty;
            dtNgayKy.Value = DateTime.Now;
            dtNgayLenLuong.Value = DateTime.Now;
            //dtNgayLenLuong.Value = dtNgayKy.Value.AddDays(45);//thường thì sau khi nộp đơn 45 ngày là nghỉ


        }
        void loadHopDong()
        {
            slkHopDong.Properties.DataSource = _hopdong.getListFull();
            slkHopDong.Properties.ValueMember = "SOHD";
            slkHopDong.Properties.DisplayMember = "SOHD";
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
            txtGhiChu.Enabled = !kt;
            dtNgayKy.Enabled = !kt;
            slkHopDong.Enabled = !kt;

        }

        private void loadData()
        {
            gcDanhSach.DataSource = _nvnl.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
            _lstNVNLDTO = _nvnl.getListFull();
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
                _nvnl.Delete(_soQD);// chưa xây dựng chức năng đăng nhập nên truyền thẳng manv==1 vào tạm
                var hd = _hopdong.getItem(slkHopDong.EditValue.ToString()); // xóa thì phải cập nhật lại hsl cũ vào lại hđ
                hd.HESOLUONG = double.Parse(spHSLCu.EditValue.ToString());
                _hopdong.Update(hd);
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
            
                rptDanhSachNangLuong rpt = new rptDanhSachNangLuong(_lstNVNLDTO);
                rpt.ShowRibbonPreview();
            
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();
        }
        private void SaveData()
        {
            tb_NHANVIEN_NANGLUONG nl;
            if (_them)
            {
                //số hđ có dạng: 00001/2023/QĐTV
                var maxSoQD = _nvnl.MaxSoQuyetDinh();
                int so = int.Parse(maxSoQD.Substring(0, 5)) + 1;

                nl = new tb_NHANVIEN_NANGLUONG();
                nl.SOQD = so.ToString("00000") + @"/" + DateTime.Now.Year.ToString() + @"/QĐNL";
                nl.SOHD = slkHopDong.EditValue.ToString();
                nl.NGAYKY = dtNgayKy.Value;
                nl.NGAYLENLUONG = dtNgayLenLuong.Value;
                nl.HESOLUONGHIENTAI = _hopdong.getItem(slkHopDong.EditValue.ToString()).HESOLUONG;
                nl.HESOLUONGMOI = double.Parse (spHSLMoi.EditValue.ToString());
                nl.GHICHU = txtGhiChu.Text;
                nl.MANV = _hopdong.getItem(slkHopDong.EditValue.ToString()).MANV;               
                nl.CREATED_BY = Program.UserId;
                nl.CREATED_DATE = DateTime.Now;


                _nvnl.Add(nl);
            }
            else
            {
                nl = _nvnl.getItem(_soQD);
                nl.SOHD = slkHopDong.EditValue.ToString();
                nl.NGAYKY = dtNgayKy.Value;
                nl.NGAYLENLUONG = dtNgayLenLuong.Value;
                nl.HESOLUONGHIENTAI = _hopdong.getItem(slkHopDong.EditValue.ToString()).HESOLUONG;
                nl.HESOLUONGMOI = double.Parse(spHSLMoi.EditValue.ToString());
                nl.GHICHU = txtGhiChu.Text;
                nl.MANV = _hopdong.getItem(slkHopDong.EditValue.ToString()).MANV;

                nl.UPDATED_BY = Program.UserId;
                nl.UPDATED_DATE = DateTime.Now;

                _nvnl.Update(nl);
            }
            var hd = _hopdong.getItem(slkHopDong.EditValue.ToString()); // thêm vẫn phải update
            hd.HESOLUONG = double.Parse( spHSLMoi.EditValue.ToString());
            _hopdong.Update(hd);
        }
        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _soQD = gvDanhSach.GetFocusedRowCellValue("SOQD").ToString();

                var nl = _nvnl.getItem(_soQD);
                txtSoQD.Text = _soQD;
                dtNgayKy.Value = nl.NGAYKY.Value;
                dtNgayLenLuong.Value = nl.NGAYLENLUONG.Value;
                slkHopDong.EditValue = nl.SOHD;
                txtGhiChu.Text = nl.GHICHU;
                spHSLCu.EditValue = nl.HESOLUONGHIENTAI;
                spHSLMoi.EditValue = nl.HESOLUONGMOI;
                txtNhanVien.Text = gvDanhSach.GetFocusedRowCellValue("HOTEN").ToString();

            }
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

        private void slkHopDong_EditValueChanged(object sender, EventArgs e)
        {
            var hd = _hopdong.getItemFull(slkHopDong.EditValue.ToString());
            if (hd.Count !=0)
            {
                txtNhanVien.Text = hd[0].MANV + " - " + hd[0].HOTEN;
                spHSLCu.EditValue = hd[0].HESOLUONG;
            }
        }
    }
}