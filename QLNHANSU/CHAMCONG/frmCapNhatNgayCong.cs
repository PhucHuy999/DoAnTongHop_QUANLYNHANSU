using BusinessLayer;
using DataLayer;
using DevExpress.Data.Filtering.Helpers;
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

namespace QLNHANSU.CHAMCONG
{
    public partial class frmCapNhatNgayCong : DevExpress.XtraEditors.XtraForm
    {
        public frmCapNhatNgayCong()
        {
            InitializeComponent();
        }
        public int _manv;
        public string _hoten;
        public int _makycong;
        public string _ngay;
        public int _cNgay;// ngày của cái cld
        KYCONGCHITIET _kcct;
        frmBangCongChiTiet frmBCCT = (frmBangCongChiTiet) Application.OpenForms["frmBangCongChiTiet"];
        private void frmCapNhatNgayCong_Load(object sender, EventArgs e)
        {
            _kcct = new KYCONGCHITIET();
            lblID.Text = _manv.ToString();
            lblHoTen.Text = _hoten;
            //bắt được ngày tháng năm khi click trên lưới
            string nam=_makycong.ToString().Substring(0, 4);//cắt luôn năm và tháng ra
            string thang=_makycong.ToString().Substring(4);
            string ngay = _ngay.Substring(1);// Đang trả về D+number ngày, nên cắt lấy số ngày thôi
            DateTime _d= DateTime.Parse(nam + "-" + thang + "-" + ngay);
            cldNgayCong.SetDate(_d);
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            //Lấy giá trị trên các groupcontrol
            string _valueChamCong = rdgChamCong.Properties.Items[rdgChamCong.SelectedIndex].Value.ToString();
            string _valueThoiGianNghi = rdgThoiGianNghi.Properties.Items[rdgThoiGianNghi.SelectedIndex].Value.ToString();
            string fieldName = "D" + _cNgay.ToString();
            var kcct = _kcct.getItem(_makycong, _manv);

            double? tongngaycong = kcct.TONGNGAYCONG;
            double? tongngayphep = kcct.NGAYPHEP;
            double? tongngaykhongphep = kcct.NGHIKHONGPHEP;
            double? tongcongle = kcct.CONGNGAYLE;
            //ràng buộc đang xem tháng nào chỉ chấm được tháng đó thôi
            if (cldNgayCong.SelectionRange.Start.Year * 100 + cldNgayCong.SelectionRange.Start.Month!=+_makycong) 
            {
                MessageBox.Show("Thực hiện chấm công không đúng kỳ công. Vui lòng kiểm tra lại tháng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //cập nhật kỳ công chi tiết => cập nhật nhật bảng công nhân viên chi tiết
            Functions_HyHy2.execQuery("UPDATE tb_KYCONGCHITIET SET "+fieldName+"='"+_valueChamCong+"'WHERE MAKYCONG="+_makycong+" AND MANV="+_manv );
            frmBCCT.loadBangCong();


            //MessageBox.Show(_valueChamCong +"--"+_valueThoiGianNghi);

        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void cldNgayCong_DateSelected(object sender, DateRangeEventArgs e)
        {
            _cNgay = cldNgayCong.SelectionRange.Start.Day;
        }
    }
}