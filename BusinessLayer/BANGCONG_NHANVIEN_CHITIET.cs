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
    }
}
