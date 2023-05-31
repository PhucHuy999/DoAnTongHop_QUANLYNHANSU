using BusinessLayer;
using DataLayer;
using DevExpress.XtraSplashScreen;
using QLNHANSU.CHAMCONG;
using QLNHANSU.Reports;
using QLNHANSU.TINHLUONG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QLNHANSU
{
    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        string IDUSER ="" , USERNAME = "", FULLNAME = "", PASS = "", QUYEN = "";

        public MainForm()
        {
            InitializeComponent();
        }
        public MainForm(string IDUSER,string USERNAME, string FULLNAME, string PASS, string QUYEN)
        {
            InitializeComponent();
            this.IDUSER = IDUSER;
            this.USERNAME = USERNAME;
            this.FULLNAME = FULLNAME;
            this.PASS = PASS;
            this.QUYEN = QUYEN;
        }
        void openForm(Type typeForm) ///// Đoạn này thiết lập openform cho nó không bị mở thêm form mới khi click vào button mà khi form đã mở 
        {
            foreach (var frm in MdiChildren)
            {
                if(frm.GetType()==typeForm)
                {
                    frm.Activate();
                    return;
                }
            }
            Form f =(Form)Activator.CreateInstance(typeForm);   
            f.MdiParent = this;
            f.Show();   

        }
        NHANVIEN _nhanvien;
        HOPDONGLAODONG _hopdong;


        //Tham số Overlay Form DevExpress lấy ở bài hướng dẫn trên trang chủ

       //OverlayWindowOptions options = new OverlayWindowOptions(
       //backColor: Color.Black,
       //opacity: 0.5,
       //fadeIn: false,
       //fadeOut: false
       // );
       // IOverlaySplashScreenHandle ShowProgressPanel(Control control, OverlayWindowOptions option)
       // {
       //     return SplashScreenManager.ShowOverlayForm(control, option);
       // }
        private void MainForm_Load(object sender, EventArgs e)
        {
            
            ribbonControl1.SelectedPage = ribbonPage2; //set khi load hiển thị lên ribbonPage2(Nhân sự) trước.

            //Functions_HyHy2.Commons.handle = ShowProgressPanel(this, options); // control là this, còn option là ở trên
            
                //frmLogin frm = new frmLogin();
                //frm.ShowDialog();
            
            _nhanvien = new NHANVIEN();
            _hopdong = new HOPDONGLAODONG();
            loadSinhNhat();
            loadLenLuong();
            txtTenNguoiDung.Text = FULLNAME;
            txtIDNguoiDung.Text = IDUSER;
        }
        void loadSinhNhat()
        {
            lstSinhNhat.DataSource = _nhanvien.getSinhNhat();
            lstSinhNhat.DisplayMember = "HOTEN";
            lstSinhNhat.ValueMember = "MANV";
        }
        void loadLenLuong()
        {
            lstLenLuong.DataSource = _hopdong.getLenLuong();
            lstLenLuong.DisplayMember = "HOTEN";
            lstLenLuong.ValueMember = "MANV";
        }
        //void loadNguoiDung()
        //{
        //    lstLenLuong.DataSource = _nguoidung.getList();
        //    lstLenLuong.DisplayMember = "IDUSER";
        //    lstLenLuong.ValueMember = "_user";
        //}
        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmDanToc frm = new frmDanToc();
            //frm.MdiParent = this;   
            //frm.Show();
            openForm(typeof(frmDanToc));
        }

        private void btnThoiViec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmNhanVien_ThoiViec));
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmLoaiCong));

        }

        private void btnTonGiao_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //frmTonGiao frm = new frmTonGiao();
            //frm.MdiParent = this;
            //frm.Show(); 
            openForm(typeof(frmTonGiAo)); 

        }

        private void btnTrinhDo_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmTrinhDo));
        }

        private void btnPhongBan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmPhongBan));
        }

        private void btnCongTy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmCongTy));
        }

        private void btnBoPhan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmBoPhan));
        }

        private void btnChucVu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmChucVu));
        }

        private void btnNhanVien_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmNhanVien));
        }

        private void btnHopDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmHopDongLaoDong));
        }

        private void btnKhenThuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmKhenThuong));
        }

        private void btnKyLuat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmKyLuat));
        }

        private void btnDieuchuyen_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmNhanVien_DieuChuyen));
        }

        private void btnThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn có chắc muốn thoát không?", "Error", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit();
        }

        private void btnThoatt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn có chắc muốn thoát không?", "Error", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit();
        }

        private void barButtonItem1_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmQuanLyLuong));

        }

        private void lstSinhNhat_CustomizeItem(object sender, DevExpress.XtraEditors.CustomizeTemplatedItemEventArgs e)
        {
            if (e.TemplatedItem.Elements[1].Text.Substring(0,2)==DateTime.Now.Day.ToString())
            {
                e.TemplatedItem.AppearanceItem.Normal.ForeColor = Color.Red;
            }
        }

        private void lstLenLuong_CustomizeItem(object sender, DevExpress.XtraEditors.CustomizeTemplatedItemEventArgs e)
        {
            if (e.TemplatedItem.Elements[1].Text.Substring(0, 2) == DateTime.Now.Day.ToString())
            {
                e.TemplatedItem.AppearanceItem.Normal.ForeColor = Color.Red;
            }
        }

        private void btnLoaiCa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmLoaiCa));

        }

        private void btnBangCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmBangCong));

        }

        private void btnBangCongCT_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            frmInBangCongChiTiet frm = new frmInBangCongChiTiet();
            frm.ShowDialog();
        }

        private void btnPhuCap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmPhuCap));

        }


        private void btnTangCa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmTangCa));

        }

        private void btnUngLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            openForm(typeof(frmUngLuong));

        }

        private void btnBangLuong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //openForm(typeof(frmBangLuong));
            frmBangLuong frm = new frmBangLuong();
            frm.ShowDialog();
        }

        

        private void btnBackup_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (QUYEN == "Admin")
            {
                frmSaoLuuDuLieu frm = new frmSaoLuuDuLieu();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không được quyền sử dụng tính năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnPhucHoiDuLieu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (QUYEN == "Admin")
            {
                frmKhoiPhucDuLieu frm = new frmKhoiPhucDuLieu();
                frm.ShowDialog();
            }
            else
            {
                MessageBox.Show("Bạn không được quyền sử dụng tính năng này!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }

        private void btnThoattt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DialogResult h = MessageBox.Show("Bạn có chắc muốn thoát không?", "Error", MessageBoxButtons.OKCancel);
            if (h == DialogResult.OK)
                Application.Exit();
        }
        private void btnDoiMatKhau_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
                frmDoiMatKhau frm = new frmDoiMatKhau();
                frm.ShowDialog();
            
        }
    }
}
