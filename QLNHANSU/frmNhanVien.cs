using BusinessLayer;
using BusinessLayer.DTO;
using DataLayer;
using DevExpress.XtraEditors;
using QLNHANSU.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using DevExpress.XtraRichEdit.API.Native.Implementation;

namespace QLNHANSU
{
    public partial class frmNhanVien : DevExpress.XtraEditors.XtraForm
    {
        public frmNhanVien()
        {
            InitializeComponent();
        }

        private NHANVIEN _nhanvien;
        private DANTOC _dantoc;
        private TONGIAO _tongiao;
        private CHUCVU _chucvu;
        private TRINHDO _trinhdo;
        private PHONGBAN _phongban;
        private BOPHAN _bophan;
        //private Image _hinh;

        private bool _them;
        private int _id;

        List<NHANVIEN_DTO> _lstNVDTO;

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            _them = false;
            _nhanvien = new NHANVIEN();
            _dantoc = new DANTOC();
            _tongiao = new TONGIAO();
            _chucvu = new CHUCVU();
            _trinhdo = new TRINHDO();
            _phongban = new PHONGBAN();
            _bophan = new BOPHAN();

            _showHide(true);
            loadData();
            loadcombo();
            splitContainer1.Panel1Collapsed = true; //splitContainer1 là tên của bảng trên (khi load thì mặc định cho ẩn đi đã)

        }


        void loadcombo()
        {
            cboPhongBan.DataSource = _phongban.getList();
            cboPhongBan.DisplayMember = "TENPB";
            cboPhongBan.ValueMember = "IDPB";

            cboBoPhan.DataSource = _bophan.getList();
            cboBoPhan.DisplayMember = "TENBP";
            cboBoPhan.ValueMember = "IDBP";

            cboChucVu.DataSource = _chucvu.getList();
            cboChucVu.DisplayMember = "TENCV";
            cboChucVu.ValueMember = "IDCV";

            cboTrinhDo.DataSource = _trinhdo.getList();
            cboTrinhDo.DisplayMember = "TENTD";
            cboTrinhDo.ValueMember = "IDTD";

            cboDanToc.DataSource = _dantoc.getList();
            cboDanToc.DisplayMember = "TENDT";
            cboDanToc.ValueMember = "ID";

            cboTonGiao.DataSource = _tongiao.getList();
            cboTonGiao.DisplayMember = "TENTG";
            cboTonGiao.ValueMember = "ID";
        }
        void _reset()// reset lai trang text khi sử dụng chức năng thêm
        {
            txtHoTen.Text = string.Empty;
            txtCCCD.Text = string.Empty;
            txtDienThoai.Text = string.Empty;
            txtDiaChi.Text = string.Empty;
            chkGioiTinh.Checked = false;                                                //////////
            picHinhAnh.Image = Properties.Resources.no_image;//noimage  Properties.

            // picHinhAnh.Image = null;
        }
        void _showHide(bool kt)
        {
            btnLuu.Enabled = !kt;//// mới chạy thì lưu và hủy cho nó mờ đi
            btnHuy.Enabled = !kt;////
            btnThem.Enabled = kt;
            btnSua.Enabled = kt;
            btnXoa.Enabled = kt;
            btnDong.Enabled = kt;
            btnIn.Enabled = kt;
            
            txtHoTen.Enabled = !kt;
            chkGioiTinh.Enabled = !kt;                                                  ////////
            dtNgaySinh.Enabled = !kt;
            txtDienThoai.Enabled = !kt;
            txtCCCD.Enabled = !kt;
            txtDiaChi.Enabled = !kt;
            //picHinhAnh.Enabled = !kt; // khỏi cần ẩn
            cboPhongBan.Enabled = !kt;
            cboBoPhan.Enabled = !kt;
            cboChucVu.Enabled = !kt;
            cboTrinhDo.Enabled = !kt;
            cboDanToc.Enabled = !kt;
            cboTonGiao.Enabled = !kt;
            btnChonHinh.Enabled = !kt;
            gcDanhSach.Enabled = kt;

        }
        void loadData()
        {
            gcDanhSach.DataSource = _nhanvien.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
            _lstNVDTO = _nhanvien.getListFull(); // nv dto mà đưa ra
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textEdit3_EditValueChanged(object sender, EventArgs e)
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
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _nhanvien.Delete(_id);
                loadData();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

           

            if (KiemTraThongTinNhap()) //lưu thì phải kiểm tra thông tin nhập đã đúng các định dạng chưa đã
            {
               
               

                SaveData();
                loadData();
                _showHide(true);
                _them = false;
                //splitContainer1.Panel1Collapsed = true; // lưu xong thì lại ẩn bảng trên đi
            }
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);
            //splitContainer1.Panel1Collapsed = true; // khi hủy thì cũng ẩn đi
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rptDanhSachNhanVien rpt = new rptDanhSachNhanVien(_lstNVDTO);
            rpt.ShowRibbonPreview();
        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
           this.Close();    
        }

        void SaveData()
        {
            

            if (_them)
            {
                tb_NHANVIEN nv = new tb_NHANVIEN();
                nv.HOTEN = txtHoTen.Text;
                nv.GIOITINH = chkGioiTinh.Checked;                                    ////////////
                nv.NGAYSINH = dtNgaySinh.Value;
                nv.DIENTHOAI = txtDienThoai.Text;
                nv.CCCD = txtCCCD.Text;
                nv.DIACHI = txtDiaChi.Text;
                nv.HINHANH = ImageToBase64(picHinhAnh.Image, picHinhAnh.Image.RawFormat);
                nv.IDPB = int.Parse(cboPhongBan.SelectedValue.ToString());
                nv.IDBP = int.Parse(cboBoPhan.SelectedValue.ToString());
                nv.IDCV = int.Parse(cboChucVu.SelectedValue.ToString());
                nv.IDTD = int.Parse(cboTrinhDo.SelectedValue.ToString());
                nv.IDDT = int.Parse(cboDanToc.SelectedValue.ToString());
                nv.IDTG = int.Parse(cboTonGiao.SelectedValue.ToString());
                nv.MACTY = 1;


                _nhanvien.Add(nv);

            }
            else
            {
                var nv = _nhanvien.getItem(_id);
                nv.HOTEN = txtHoTen.Text;
                nv.GIOITINH = chkGioiTinh.Checked;                                   ///////////
                nv.NGAYSINH = dtNgaySinh.Value;
                nv.DIENTHOAI = txtDienThoai.Text;
                nv.CCCD = txtCCCD.Text;
                nv.DIACHI = txtDiaChi.Text;
                nv.HINHANH = ImageToBase64(picHinhAnh.Image, picHinhAnh.Image.RawFormat);
                nv.IDPB = int.Parse(cboPhongBan.SelectedValue.ToString());
                nv.IDBP = int.Parse(cboBoPhan.SelectedValue.ToString());
                nv.IDCV = int.Parse(cboChucVu.SelectedValue.ToString());
                nv.IDTD = int.Parse(cboTrinhDo.SelectedValue.ToString());
                nv.IDDT = int.Parse(cboDanToc.SelectedValue.ToString());
                nv.IDTG = int.Parse(cboTonGiao.SelectedValue.ToString());
                nv.MACTY = 1;



                _nhanvien.Update(nv);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("MANV").ToString());
                //txtHoTen.Text = gvDanhSach.GetFocusedRowCellValue("HOTEN").ToString();//cho even click trên list tên gán lên text để sửa
                var nv = _nhanvien.getItem(_id);
                txtHoTen.Text = nv.HOTEN;
                chkGioiTinh.Checked = nv.GIOITINH.Value;                                   ////////////////////
                dtNgaySinh.Value = nv.NGAYSINH.Value;
                txtDienThoai.Text = nv.DIENTHOAI;
                txtCCCD.Text = nv.CCCD;
                txtDiaChi.Text = nv.DIACHI;
                picHinhAnh.Image = Base64ToImage(nv.HINHANH);
                cboPhongBan.SelectedValue = nv.IDPB;
                cboBoPhan.SelectedValue = nv.IDBP;
                cboChucVu.SelectedValue = nv.IDCV;
                cboTrinhDo.SelectedValue = nv.IDTD;
                cboDanToc.SelectedValue = nv.IDDT;
                cboTonGiao.SelectedValue = nv.IDTG;
                //nv.MACTY = 1;
                splitContainer1.Panel1Collapsed = false;
            }
        }

        public byte[] ImageToBase64(Image image, System.Drawing.Imaging.ImageFormat format)//mã hóa khi lưu ảnh vào database
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, format);
                byte[] imageBytes = ms.ToArray();   

                return imageBytes;
            }
        }

        public Image Base64ToImage(byte[] imageBytes)//giải mã
        {
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;        
        }

        private void btnChonHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Picture file (.png, .jpg)|*.png;*.jpg";
            openFile.Title = "Chọn hình ảnh";
            if(openFile.ShowDialog()==DialogResult.OK)
            {
                picHinhAnh.Image = Image.FromFile(openFile.FileName);
                picHinhAnh.SizeMode = PictureBoxSizeMode.StretchImage;
            }
        }

        private void labelControl10_Click(object sender, EventArgs e)
        {

        }

        private void labelControl5_Click(object sender, EventArgs e)
        {

        }

        private void cboDanToc_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void picHinhAnh_Click(object sender, EventArgs e)
        {
            //var nv = _nhanvien.getItem(int.Parse(gvDanhSach.GetFocusedRowCellValue("MANV").ToString());
            _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("MANV").ToString()); ///////////////////////////////////////////////////////// 
            var nv = _nhanvien.getItem(_id);
            frmFullSizeImage frm = new frmFullSizeImage(Base64ToImage(nv.HINHANH), nv.HOTEN);
            frm.ShowDialog();
        }
        bool KiemTraThongTinNhap()
        {
            string cccd = txtCCCD.Text;
            string dienthoai = txtDienThoai.Text;
            long _ketqua;
            char[] mangCCCD = cccd.ToCharArray();
            char[] mangDIENTHOAI = dienthoai.ToCharArray();

            if (txtHoTen.Text == "")
            {
                MessageBox.Show("Hãy nhập họ tên", "Thông Báo");
                txtHoTen.Focus();
                return false;
            }

            if (txtCCCD.Text == "")
            {
                MessageBox.Show("Hãy nhập số CCCD", "Thông Báo");
                txtCCCD.Focus();
                return false;
            }

            if (!(long.TryParse(cccd, out _ketqua)))// Kiểm tra định dạng số CCCD là số
            {
                MessageBox.Show("Hãy nhập đúng định dạng CCCD là số", "Thông Báo");
                txtCCCD.Focus();
                return false;
            } 
            
            if (_ketqua < 0) 
            {
                MessageBox.Show("Số CCCD không được âm", "Thông Báo");
                txtCCCD.Focus();
                return false;
            }

            if (mangCCCD.Length != 12)
            {
                MessageBox.Show("Số CCCD phải đúng đủ 12 số", "Thông Báo");
                txtCCCD.Focus();
                return false;
            }

            if (txtDienThoai.Text == "")
            {
                MessageBox.Show("Hãy nhập số điện thoại", "Thông Báo");
                txtDienThoai.Focus();
                return false;
            }

            if (!(long.TryParse(dienthoai, out _ketqua)))// Kiểm tra định dạng số điện thoại là số
            {
                MessageBox.Show("Hãy nhập đúng định dạng điện thoại là số", "Thông Báo");
                txtDienThoai.Focus();
                return false;
            }

            if (mangDIENTHOAI.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải đúng đủ 10 số", "Thông Báo");
                txtDienThoai.Focus();
                return false;
            }

            if (txtDiaChi.Text == "")
            {
                MessageBox.Show("Hãy nhập địa chỉ", "Thông Báo");
                txtDiaChi.Focus();
                return false;
            }


            return true;
  
        }

        private void gvDanhSach_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.Column.Name == "GIOITINH" && bool.Parse(e.CellValue.ToString()) == true)
            {
                Image img = Properties.Resources.GIOITINH_NAM__4_;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
                
            }
            if (e.Column.Name == "GIOITINH" && bool.Parse(e.CellValue.ToString()) == false)
            {
                Image img = Properties.Resources.GIOITINH_NU__2_;
                e.Graphics.DrawImage(img, e.Bounds.X, e.Bounds.Y);
                e.Handled = true;
            }
        }
    }
}