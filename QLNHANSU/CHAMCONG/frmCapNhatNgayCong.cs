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
        BANGCONG_NHANVIEN_CHITIET _bcnvct;
        frmBangCongChiTiet frmBCCT = (frmBangCongChiTiet) Application.OpenForms["frmBangCongChiTiet"];
        private void frmCapNhatNgayCong_Load(object sender, EventArgs e)
        {
            _kcct = new KYCONGCHITIET(Program.UserId);
            _bcnvct = new BANGCONG_NHANVIEN_CHITIET(Program.UserId);
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

            //double? tongngaycong = kcct.TONGNGAYCONG;
            //double? tongngayphep = kcct.NGAYPHEP;
            //double? tongngaykhongphep = kcct.NGHIKHONGPHEP;
            //double? tongcongle = kcct.CONGNGAYLE;


            //ràng buộc đang xem tháng nào chỉ chấm được tháng đó thôi
            if (cldNgayCong.SelectionRange.Start.Year * 100 + cldNgayCong.SelectionRange.Start.Month!=+_makycong) 
            {
                MessageBox.Show("Thực hiện chấm công không đúng kỳ công. Vui lòng kiểm tra lại tháng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            //cập nhật kỳ công chi tiết => cập nhật nhật bảng công NHÂN VIÊN chi tiết
            //Functions_HyHy2.execQuery("UPDATE tb_KYCONGCHITIET SET "+fieldName+"='"+_valueChamCong+"'WHERE MAKYCONG="+_makycong+" AND MANV="+_manv );
            Functions_HyHy2.execQuery("UPDATE tb_KYCONGCHITIET SET " + fieldName + "='" + _valueChamCong + "' +' '+ '" + _valueThoiGianNghi + "'WHERE MAKYCONG=" + _makycong + " AND MANV=" + _manv);


            tb_BANGCONG_NHANVIEN_CHITIET bcnvct = _bcnvct.getItem(_makycong, _manv, cldNgayCong.SelectionStart.Day);
            bcnvct.KYHIEU = _valueChamCong+' '+_valueThoiGianNghi;

            
            switch (_valueChamCong)
            {
                case "NP":
                    if(_valueThoiGianNghi=="nn")//thời gian nghỉ PHÉP nguyên ngày   
                    {
                        bcnvct.NGAYPHEP = 1;
                        bcnvct.NGAYCONG = 0;
                        bcnvct.NGHIKHONGPHEP = 0;
                        bcnvct.CONGNGAYLE = 0;
                        bcnvct.CONGCHUNHAT = 0;
                        bcnvct.XINNGHIVIECRIENG = 0;
                        //kcct.NGAYPHEP = tongngayphep + 0.5;
                        //kcct.TONGNGAYCONG = tongngaycong - 0.5;
                    }
                    else
                    {
                        bcnvct.NGAYPHEP = 0.5;//phép nửa ngày SÁNG hoặc CHIỀU thì như nhau
                        bcnvct.NGAYCONG = 0.5;
                        bcnvct.NGHIKHONGPHEP = 0;
                        bcnvct.CONGNGAYLE = 0;
                        bcnvct.CONGCHUNHAT = 0;
                        bcnvct.XINNGHIVIECRIENG = 0;
                        //kcct.NGAYPHEP = tongngayphep + 0.5;
                        //kcct.TONGNGAYCONG = tongngaycong - 0.5;

                    }
                    break;



                case "CT":
                    if (_valueThoiGianNghi == "nn")
                    {
                        bcnvct.NGAYPHEP = 0;
                        bcnvct.NGHIKHONGPHEP = 0;
                        bcnvct.NGAYCONG = 1;//công tác thì vẫn là đi làm nhưng chỗ khác
                        bcnvct.CONGNGAYLE = 0;
                        bcnvct.CONGCHUNHAT = 0;
                        bcnvct.XINNGHIVIECRIENG = 0;
                    }
                    else
                    {
                        bcnvct.NGAYPHEP = 0.5;// xác định công tác nửa buổi còn nửa buổi còn lại nghỉ phép nửa ngày
                        bcnvct.NGAYCONG = 0.5;
                        bcnvct.NGHIKHONGPHEP = 0;
                        bcnvct.CONGNGAYLE = 0;
                        bcnvct.CONGCHUNHAT = 0;
                        bcnvct.XINNGHIVIECRIENG = 0;
                    }
                    break;
                case "VR":
                    if (_valueThoiGianNghi == "nn")
                    {
                        bcnvct.NGAYCONG = 0;
                        bcnvct.NGAYPHEP = 0;
                        bcnvct.NGHIKHONGPHEP = 0;
                        bcnvct.CONGNGAYLE = 0;
                        bcnvct.CONGCHUNHAT = 0;
                        bcnvct.XINNGHIVIECRIENG = 1;
                    }
                    else
                    {
                        bcnvct.NGAYPHEP = 0; 
                        bcnvct.NGAYCONG = 0.5;
                        bcnvct.NGHIKHONGPHEP = 0;
                        bcnvct.CONGNGAYLE = 0;
                        bcnvct.CONGCHUNHAT = 0;
                        bcnvct.XINNGHIVIECRIENG = 0.5;
                    }
                    break;
                case "V":
                    if (_valueThoiGianNghi == "nn")
                    {
                        bcnvct.NGHIKHONGPHEP = 1;
                        bcnvct.NGAYPHEP = 0;
                        bcnvct.NGAYCONG = 0;
                        bcnvct.CONGNGAYLE = 0;
                        bcnvct.CONGCHUNHAT = 0;
                        bcnvct.XINNGHIVIECRIENG = 0;
                    }
                    else
                    {
                        bcnvct.NGHIKHONGPHEP = 0.5;
                        bcnvct.NGAYPHEP = 0;
                        bcnvct.NGAYCONG = 0.5;
                        bcnvct.CONGNGAYLE = 0;
                        bcnvct.CONGCHUNHAT = 0;
                        bcnvct.XINNGHIVIECRIENG = 0;
                    }
                    break;
                case "CLE":
                    if (_valueThoiGianNghi == "nn")
                    {
                        bcnvct.NGHIKHONGPHEP = 0;
                        bcnvct.NGAYPHEP = 0;
                        //bcnvct.NGAYCONG = 0;
                        bcnvct.CONGNGAYLE = 1;
                        bcnvct.CONGCHUNHAT = 0;
                        bcnvct.XINNGHIVIECRIENG = 0;
                    }
                    else
                    {
                        bcnvct.NGHIKHONGPHEP = 0;
                        bcnvct.NGAYPHEP = 0;
                        //bcnvct.NGAYCONG = 0;
                        bcnvct.CONGNGAYLE = 0.5;
                        bcnvct.CONGCHUNHAT = 0;
                        bcnvct.XINNGHIVIECRIENG = 0;
                    }
                    break;

                case "CCN":
                    if (_valueThoiGianNghi == "nn")
                    {
                        bcnvct.NGHIKHONGPHEP = 0;
                        bcnvct.NGAYPHEP = 0;
                        //bcnvct.NGAYCONG = 0;
                        bcnvct.CONGNGAYLE = 0;
                        bcnvct.CONGCHUNHAT = 1;
                        bcnvct.XINNGHIVIECRIENG = 0;
                    }
                    else
                    {
                        bcnvct.NGHIKHONGPHEP = 0;
                        bcnvct.NGAYPHEP = 0;
                        //bcnvct.NGAYCONG = 0;
                        bcnvct.CONGNGAYLE = 0;
                        bcnvct.CONGCHUNHAT = 0.5;
                        bcnvct.XINNGHIVIECRIENG = 0;
                    }
                    break;

                case "X":
                    if (_valueThoiGianNghi == " ")
                    {
                        bcnvct.NGHIKHONGPHEP = 0;
                        bcnvct.NGAYPHEP = 0;
                        bcnvct.NGAYCONG = 1;
                        bcnvct.CONGNGAYLE = 0;
                        bcnvct.CONGCHUNHAT = 0;
                        bcnvct.XINNGHIVIECRIENG = 0;
                    }
                  
                    break;
                case "CN":
                    if (_valueThoiGianNghi == " ")
                    {
                        //bcnvct.NGHIKHONGPHEP = 0;
                        //bcnvct.NGAYPHEP = 0;
                        bcnvct.NGAYCONG = 0;
                        bcnvct.CONGNGAYLE = 0;
                        bcnvct.CONGCHUNHAT = 0;
                        bcnvct.XINNGHIVIECRIENG = 0;
                    }
                    break;
                default:
                    break;
            }
            //CẬP NHẬT tb_BANGCONG_NHANVIEN_CHITIET (ky hiệu và ngày công ngày phép)
            _bcnvct.Update(bcnvct);

            //Tính lại tổng các ngày: phép, công, vắng....
            double tongngayphep = _bcnvct.tongNgayPhep(_makycong, _manv);
            double tongngaycong = _bcnvct.tongNgayCong(_makycong, _manv);
            double tongnghikhongphep = _bcnvct.tongNghiKhongPhep(_makycong, _manv);
            double tongcongngayle = _bcnvct.tongCongNgayLe(_makycong, _manv);
            double tongcongchunhat = _bcnvct.tongCongChuNhat(_makycong, _manv);
            double tongxinnghiviecrieng = _bcnvct.tongXinNghiViecRieng(_makycong, _manv);

            kcct.NGAYPHEP = tongngayphep;
            kcct.TONGNGAYCONG = tongngaycong;
            kcct.NGHIKHONGPHEP = tongnghikhongphep;
            kcct.CONGNGAYLE = tongcongngayle;
            kcct.CONGCHUNHAT = tongcongchunhat;
            kcct.XINNGHIVIECRIENG = tongxinnghiviecrieng;
            _kcct.Update(kcct);

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