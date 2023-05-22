using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class BANGCONG_NHANVIEN_CHITIET
    {
        QLNHANSUEntities db = new QLNHANSUEntities();
        public tb_BANGCONG_NHANVIEN_CHITIET getItem(int makycong, int manv, int ngay)
        {
            return db.tb_BANGCONG_NHANVIEN_CHITIET.FirstOrDefault(x => x.MAKYCONG == makycong && x.MANV == manv && x.NGAY.Value.Day == ngay);
        }
        public List<tb_BANGCONG_NHANVIEN_CHITIET> getBangCongChiTiet(int makycong, int manv)
        {
            return db.tb_BANGCONG_NHANVIEN_CHITIET.Where(x => x.MAKYCONG == makycong && x.MANV == manv).ToList();

        }
        public tb_BANGCONG_NHANVIEN_CHITIET Add(tb_BANGCONG_NHANVIEN_CHITIET bcct)
        {
            try
            {
                db.tb_BANGCONG_NHANVIEN_CHITIET.Add(bcct);
                db.SaveChanges();
                return bcct;
            }
            catch (Exception ex)
            {
                throw new Exception("lỗi: " + ex.Message);
            }
        }
        public tb_BANGCONG_NHANVIEN_CHITIET Update(tb_BANGCONG_NHANVIEN_CHITIET bcct)
        {
            try
            {
                tb_BANGCONG_NHANVIEN_CHITIET bcnv = db.tb_BANGCONG_NHANVIEN_CHITIET.FirstOrDefault(x => x.MAKYCONG == bcct.MAKYCONG && x.MANV == bcct.MANV && x.NGAY == bcct.NGAY);
                bcnv.KYHIEU = bcnv.KYHIEU;
                bcnv.GIOVAO = bcct.GIOVAO;
                bcnv.GIORA = bcct.GIORA;
                bcnv.NGAYPHEP = bcct.NGAYPHEP;
                bcnv.GHICHU = bcct.GHICHU;
                bcnv.CONGCHUNHAT = bcct.CONGCHUNHAT;
                bcnv.CONGNGAYLE = bcct.CONGNGAYLE;
                bcnv.NGAYCONG = bcct.NGAYCONG;
                bcnv.NGHIKHONGPHEP = bcct.NGHIKHONGPHEP;
                bcnv.UPDATED_BY = bcct.UPDATED_BY;
                bcnv.UPDATED_DATE = bcct.UPDATED_DATE;
                db.SaveChanges();
                return bcct;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: "+ex.Message);
            }
        }
        public double tongNgayPhep(int makycong, int manv)
        {
            return db.tb_BANGCONG_NHANVIEN_CHITIET.Where(x=>x.MAKYCONG == makycong && x.MANV==manv && x.NGAYPHEP!=null).ToList().Sum(p=>p.NGAYPHEP.Value);
        }
        public double tongNgayCong(int makycong, int manv)
        {
            return db.tb_BANGCONG_NHANVIEN_CHITIET.Where(x => x.MAKYCONG == makycong && x.MANV == manv && x.NGAYCONG != null).ToList().Sum(p => p.NGAYCONG.Value + ((p.CONGNGAYLE.Value)*3) + p.CONGCHUNHAT.Value );//lương lễ 300%
        }
        public double tongNghiKhongPhep(int makycong, int manv)
        {
            return db.tb_BANGCONG_NHANVIEN_CHITIET.Where(x => x.MAKYCONG == makycong && x.MANV == manv && x.NGHIKHONGPHEP != null).ToList().Sum(p => p.NGHIKHONGPHEP.Value);
        }
        public double tongCongChuNhat(int makycong, int manv)
        {
            return db.tb_BANGCONG_NHANVIEN_CHITIET.Where(x => x.MAKYCONG == makycong && x.MANV == manv && x.CONGCHUNHAT != null).ToList().Sum(p => p.CONGCHUNHAT.Value);
        }
        public double tongCongNgayLe(int makycong, int manv)
        {
            return db.tb_BANGCONG_NHANVIEN_CHITIET.Where(x => x.MAKYCONG == makycong && x.MANV == manv && x.CONGNGAYLE != null).ToList().Sum(p => p.CONGNGAYLE.Value);
        }
    }
}
