using BusinessLayer.DTO;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class NHANVIEN_DIEUCHUYEN
    {
        QLNHANSUEntities db = new QLNHANSUEntities();
        private readonly int UserId;

        public NHANVIEN_DIEUCHUYEN()
        {
            this.UserId = 2;
        }

        public NHANVIEN_DIEUCHUYEN(int userId)
        {
            this.UserId = userId;
        }

        public tb_NHANVIEN_DIEUCHUYEN getItem(string soqd)
        {
            return db.tb_NHANVIEN_DIEUCHUYEN.FirstOrDefault(x => x.SOQD == soqd);
        }
        public List<tb_NHANVIEN_DIEUCHUYEN> getList()
        {
            return db.tb_NHANVIEN_DIEUCHUYEN.ToList();
        }
        public List<NHANVIEN_DIEUCHUYEN_DTO> getListFull()
        {
            var lstDC =  db.tb_NHANVIEN_DIEUCHUYEN.ToList();
            List<NHANVIEN_DIEUCHUYEN_DTO> lstDTO = new List<NHANVIEN_DIEUCHUYEN_DTO>();
            NHANVIEN_DIEUCHUYEN_DTO nvDTO;
            foreach (var item in lstDC)
            {
                nvDTO = new NHANVIEN_DIEUCHUYEN_DTO();
                nvDTO.SOQD = item.SOQD;
                nvDTO.NGAY = item.NGAY;

                nvDTO.MANV = item.MANV;
                var nv = db.tb_NHANVIEN.FirstOrDefault(n => n.MANV == item.MANV);
                nvDTO.HOTEN = nv.HOTEN;

                nvDTO.MAPB = item.MAPB;
                var pb = db.tb_PHONGBAN.FirstOrDefault(b => b.IDPB == item.MAPB);
                nvDTO.TENPB = pb.TENPB;                        

                nvDTO.MAPB2 = item.MAPB2;
                var pb2 = db.tb_PHONGBAN.FirstOrDefault(b2 => b2.IDPB == item.MAPB2);
                nvDTO.TENPB2 = pb2.TENPB;

                nvDTO.MABP = item.MABP;
                var bp = db.tb_BOPHAN.FirstOrDefault(p => p.IDBP == item.MABP);
                nvDTO.TENBP = bp.TENBP;

                nvDTO.MABP2 = item.MABP2;
                var bp2 = db.tb_BOPHAN.FirstOrDefault(p2 => p2.IDBP == item.MABP2);
                nvDTO.TENBP2 = bp2.TENBP;

                nvDTO.MACV = item.MACV;
                var cv = db.tb_CHUCVU.FirstOrDefault(c => c.IDCV == item.MACV);
                nvDTO.TENCV = cv.TENCV;

                nvDTO.MACV2 = item.MACV2;
                var cv2 = db.tb_CHUCVU.FirstOrDefault(c2 => c2.IDCV == item.MACV2);
                nvDTO.TENCV2 = cv2.TENCV;

                nvDTO.LYDO = item.LYDO;
                nvDTO.GHICHU = item.GHICHU; 
                nvDTO.CREATED_BY = item.CREATED_BY;
                nvDTO.CREATED_DATE = item.CREATED_DATE;
                nvDTO.UPDATED_BY = item.UPDATED_BY;
                nvDTO.UPDATED_DATE = item.UPDATED_DATE; 
              
                lstDTO.Add(nvDTO);
            }
            return lstDTO;
        }
        public tb_NHANVIEN_DIEUCHUYEN Add(tb_NHANVIEN_DIEUCHUYEN dc)
        {
            try
            {
                db.tb_NHANVIEN_DIEUCHUYEN.Add(dc);
                db.SaveChanges();
                return dc;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        public tb_NHANVIEN_DIEUCHUYEN Update(tb_NHANVIEN_DIEUCHUYEN dc)
        {
            try
            {
                var _dc = db.tb_NHANVIEN_DIEUCHUYEN.FirstOrDefault(x=>x.SOQD == dc.SOQD);
                _dc.MAPB2 = dc.MAPB2;
                _dc.MABP2 = dc.MABP2;
                _dc.MACV2 = dc.MACV2;
                _dc.MANV = dc.MANV;
                _dc.NGAY = dc.NGAY; 
                _dc.LYDO = dc.LYDO;
                _dc.GHICHU = dc.GHICHU; 
                _dc.UPDATED_BY = dc.UPDATED_BY;
                _dc.UPDATED_DATE = dc.UPDATED_DATE;


                db.SaveChanges();
                return dc;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi: " + ex.Message);
            }
        }
        //public void Delete(string soqd, int iduser)
        //{
        //    try
        //    {
        //        var _dc = db.tb_NHANVIEN_DIEUCHUYEN.FirstOrDefault(x => x.SOQD == soqd);
        //        _dc.DELETED_BY = iduser;
        //        _dc.UPDATED_DATE = DateTime.Now;


        //        db.SaveChanges();
               
        //    }
        //    catch (Exception ex)
        //    {
        //        throw new Exception("Lỗi: " + ex.Message);
        //    }
        //}
        public string MaxSoQuyetDinh()
        {
            var _hd = db.tb_NHANVIEN_DIEUCHUYEN.OrderByDescending(x => x.CREATED_DATE).FirstOrDefault();// lấy theo ngày giảm dần và lấy ngày đầu tiên
            if (_hd != null)
            {
                return _hd.SOQD;
            }
            else
                return "00000";
        }
    }
}
