using BusinessLayer;
using DataLayer;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNHANSU.CHAMCONG
{
    public partial class frmBangCongChiTiet : DevExpress.XtraEditors.XtraForm
    {
        public frmBangCongChiTiet()
        {
            InitializeComponent();
        }
        NHANVIEN _nhanvien;
        KYCONG _kycong;
        KYCONGCHITIET _kcct;
        BANGCONG_NHANVIEN_CHITIET _bangcongNVCT;
        public int _makycong;
        public int _macty;
        public int _thang;
        public int _nam;
        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void frmBangCongChiTiet_Load(object sender, EventArgs e)
        {
            _kycong = new KYCONG();
            _kcct = new KYCONGCHITIET();
            _nhanvien = new NHANVIEN();
            _bangcongNVCT = new BANGCONG_NHANVIEN_CHITIET();
            gcBangCongChiTiet.DataSource = _kcct.getList(_makycong);
            gvBangCongChiTiet.OptionsBehavior.Editable = false;
            CustomView(_thang, _nam);
            cboThang.Text = _thang.ToString();
            cboNam.Text = _nam.ToString();
        }
        public void loadBangCong()
        {
            _kcct = new KYCONGCHITIET();
            gcBangCongChiTiet.DataSource = _kcct.getList(int.Parse(cboNam.Text) * 100 + int.Parse(cboThang.Text));
            CustomView(int.Parse(cboThang.Text), int.Parse(cboNam.Text));
            gvBangCongChiTiet.OptionsBehavior.Editable = false; // khóa click bảng công lại
        }
        private void btnPhatSinhKyCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SplashScreenManager.ShowForm(typeof(frmWaiting), true, true); // Câu lệnh mở form load

            if (_kycong.KiemTraPhatSinhKyCong(int.Parse(cboNam.Text) * 100 + int.Parse(cboThang.Text))) //kiểm tra đã phát sinh kỳ công hay chưa
            {
                MessageBox.Show("Kỳ công đã được phát sinh.", "Thông báo");
                SplashScreenManager.CloseForm();
                return;
            }
            List<tb_NHANVIEN> lstNhanVien = _nhanvien.getList();
            _kcct.phatSinhKyCongChiTiet(_macty, int.Parse(cboThang.Text), int.Parse(cboNam.Text));
            foreach(var item in lstNhanVien)
            {
                for (int i = 1; i <= GetDayNumber(int.Parse(cboThang.Text), int.Parse(cboNam.Text)); i++)//
                {
                    tb_BANGCONG_NHANVIEN_CHITIET bcct = new tb_BANGCONG_NHANVIEN_CHITIET();
                    bcct.MANV = item.MANV;
                    bcct.MACTY = item.MACTY;
                    bcct.HOTEN = item.HOTEN;
                    bcct.GIOVAO = "08:00";
                    bcct.GIORA = "17:00";
                    bcct.NGAY = DateTime.Parse( cboNam.Text + "-" + cboThang.Text + "-" + i.ToString());
                    bcct.THU = Functions_HyHy2.layThuTrongTuan(int.Parse(cboNam.Text), int.Parse(cboThang.Text), i);
                    bcct.NGAYPHEP = 0;
                    bcct.CONGNGAYLE = 0;
                    bcct.CONGCHUNHAT = 0;
                    if (bcct.THU == "Chủ nhật")
                        bcct.KYHIEU = "CN";
                    else
                        bcct.KYHIEU = "X";
                    bcct.MAKYCONG = _makycong;
                    bcct.CREATED_DATE = DateTime.Now;
                    bcct.CREATED_BY = 1;
                    _bangcongNVCT.Add(bcct);
                }
            }
            
            var kc = _kycong.getItem(int.Parse(cboNam.Text) * 100 + int.Parse(cboThang.Text));
            kc.TRANGTHAI = true;
            _kycong.Update(kc);
            SplashScreenManager.CloseForm();
            loadBangCong();
        }

        private void btnXemBangCong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadBangCong();
        }

        private void btnRefresh_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            loadBangCong();
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnDong_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.Close();

        }
        //custom gridview
        private void CustomView(int thang, int nam)
        {
            gvBangCongChiTiet.RestoreLayoutFromXml(Application.StartupPath + @"\BangCong_Layout.xml");//Đường dẫn thư mục gốc chạy của chương trình,
                                                                                                      //restore trước khi customview(khắc phục lỗi khi ẩn tháng 28 ngày thì bị ẩn luôn những tháng có nhiều ngày hơn)

            int i;
            foreach (GridColumn gridColumn in gvBangCongChiTiet.Columns)
            {
                if (gridColumn.FieldName == "HOTEN") continue;

                RepositoryItemTextEdit textEdit = new RepositoryItemTextEdit();
                //Ràng buộc nhập kiểu là chứ k nhập được số
                textEdit.Mask.MaskType = MaskType.RegEx;
                textEdit.Mask.EditMask = @"\p{Lu}+";
                gridColumn.ColumnEdit = textEdit;
            }

            for (i = 1; i <= GetDayNumber(thang, nam); i++)
            {
                DateTime newDate = new DateTime(_nam, _thang, i);

                GridColumn column = new GridColumn();
                column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
                string fieldName = "D" + i;
                switch (newDate.DayOfWeek.ToString())
                {
                    case "Monday":
                        column = gvBangCongChiTiet.Columns[fieldName];
                        column.Caption = "T.Hai " + Environment.NewLine + i;
                        column.OptionsColumn.AllowEdit = true;
                        column.AppearanceHeader.ForeColor = Color.Blue;
                        column.AppearanceHeader.BackColor = Color.Transparent;
                        column.AppearanceHeader.BackColor2 = Color.Transparent;
                        column.AppearanceCell.ForeColor = Color.Black;
                        column.AppearanceCell.BackColor = Color.Transparent;
                        column.OptionsColumn.AllowFocus = true;
                        // column.Width = 30;
                        //column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
                        break;

                    case "Tuesday":
                        column = gvBangCongChiTiet.Columns[fieldName];
                        column.Caption = "T.Ba " + Environment.NewLine + i;
                        column.OptionsColumn.AllowEdit = true;
                        column.AppearanceHeader.ForeColor = Color.Blue;
                        column.AppearanceHeader.BackColor = Color.Transparent;
                        column.AppearanceHeader.BackColor2 = Color.Transparent;
                        column.AppearanceCell.ForeColor = Color.Black;
                        column.AppearanceCell.BackColor = Color.Transparent;
                        column.OptionsColumn.AllowFocus = true;
                        //column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
                        // column.width = 30;
                        break;

                    case "Wednesday":
                        column = gvBangCongChiTiet.Columns[fieldName];
                        column.Caption = "T.Tư " + Environment.NewLine + i;
                        column.OptionsColumn.AllowEdit = true;
                        column.AppearanceHeader.ForeColor = Color.Blue;
                        column.AppearanceHeader.BackColor = Color.Transparent;
                        column.AppearanceHeader.BackColor2 = Color.Transparent;
                        column.AppearanceCell.ForeColor = Color.Black;
                        column.AppearanceCell.BackColor = Color.Transparent;
                        column.OptionsColumn.AllowFocus = true;
                        //column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
                        //column.width = 30;
                        break;
                    case "Thursday":
                        column = gvBangCongChiTiet.Columns[fieldName];
                        column.Caption = "T.Năm " + Environment.NewLine + i;
                        column.OptionsColumn.AllowEdit = true;
                        column.AppearanceHeader.ForeColor = Color.Blue;
                        column.AppearanceHeader.BackColor = Color.Transparent;
                        column.AppearanceHeader.BackColor2 = Color.Transparent;
                        column.AppearanceCell.ForeColor = Color.Black;
                        column.AppearanceCell.BackColor = Color.Transparent;
                        column.OptionsColumn.AllowFocus = true;
                        //column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
                        // column.width = 30;
                        break;
                    case "Friday":
                        column = gvBangCongChiTiet.Columns[fieldName];
                        column.Caption = "T.Sáu " + Environment.NewLine + i;
                        column.OptionsColumn.AllowEdit = true;
                        column.AppearanceHeader.ForeColor = Color.Blue;
                        column.AppearanceHeader.BackColor = Color.Transparent;
                        column.AppearanceHeader.BackColor2 = Color.Transparent;
                        column.AppearanceCell.ForeColor = Color.Black;
                        column.AppearanceCell.BackColor = Color.Transparent;
                        column.OptionsColumn.AllowFocus = true;
                        //column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
                        //column.width = 30;
                        break;
                    case "Saturday":
                        column = gvBangCongChiTiet.Columns[fieldName];
                        column.Caption = "T.Bảy " + Environment.NewLine + i;
                        column.OptionsColumn.AllowEdit = true;
                        column.AppearanceHeader.ForeColor = Color.Red;
                        column.AppearanceHeader.BackColor = Color.Violet;
                        column.AppearanceHeader.BackColor2 = Color.Violet;
                        column.AppearanceCell.ForeColor = Color.Black;
                        column.AppearanceCell.BackColor = Color.Khaki;
                        column.OptionsColumn.AllowFocus = true;
                        //column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
                        //column.width = 30;
                        break;
                    case "Sunday":
                        column = gvBangCongChiTiet.Columns[fieldName];
                        column.Caption = "CN " + Environment.NewLine + i;
                        column.OptionsColumn.AllowEdit = false;
                        column.AppearanceHeader.ForeColor = Color.Red;
                        column.AppearanceHeader.BackColor = Color.GreenYellow;
                        column.AppearanceHeader.BackColor2 = Color.GreenYellow;
                        column.AppearanceCell.ForeColor = Color.Black;
                        column.AppearanceCell.BackColor = Color.Orange;
                        //column.OptionsColumn.AllowFocus = false;
                        //column.AppearanceHeader.Font = new Font("Tahoma", 8, FontStyle.Regular);
                        //column.width = 30;
                        break;





                }

            }
            while (i <= 31) // Ẩn những cột trống đi bên KYCONGCHITIET (khi add các cột trống đủ 31 ngày)
            {
                gvBangCongChiTiet.Columns[i + 1].Visible = false;
                i++;
            }
        }
        private int GetDayNumber(int thang, int nam)
        {
            int dayNumber = 0;
            switch (thang)
            {
                case 2:
                    dayNumber = (nam % 4 == 0 && nam % 100 != 0) || nam % 400 == 0 ? 29 : 28;
                    break;

                case 4:
                case 6:
                case 9:
                case 11:
                    dayNumber = 30;
                    break;

                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    dayNumber = 31;
                    break;
            }
            return dayNumber;
        }

        private void mnCapNhatNgayCong_Click(object sender, EventArgs e)
        {
            frmCapNhatNgayCong frm = new frmCapNhatNgayCong();
            frm._makycong = _makycong;
            frm._manv = int.Parse(gvBangCongChiTiet.GetFocusedRowCellValue("MANV").ToString());
            frm._hoten = gvBangCongChiTiet.GetFocusedRowCellValue("HOTEN").ToString();
            frm._ngay = gvBangCongChiTiet.FocusedColumn.FieldName.ToString();
            frm.ShowDialog();
        }
  
    }
}