﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.DTO;
using DataLayer;

namespace BusinessLayer
{
    public class HOPDONGLAODONG
    {
        QLNHANSUEntities db = new QLNHANSUEntities();
        private readonly int UserId;

        public HOPDONGLAODONG()
        {
            this.UserId = 2;
        }

        public HOPDONGLAODONG(int userId)
        {
            this.UserId = userId;
        }
        public tb_HOPDONG getItem(string sohd)
        {
            return db.tb_HOPDONG.FirstOrDefault(x => x.SOHD == sohd);
        }
        public List<HOPDONG_DTO> getItemFull(string sohd) // đưa về list 1 phần tử mới rpt mới nhận đậu xanh :v
        {
            List<tb_HOPDONG> lstHD = db.tb_HOPDONG.Where(x=>x.SOHD==sohd).ToList();
            List<HOPDONG_DTO> lstDTO = new List<HOPDONG_DTO>();
            HOPDONG_DTO hd;
            foreach (var item in lstHD)
            {
                hd = new HOPDONG_DTO();
                hd.SOHD = item.SOHD;
                //hd.NGAYBATDAU = "Từ ngày " + item.NGAYBATDAU.Value.ToString("dd/MM/yyyy").Substring(0, 2) + " tháng " + item.NGAYBATDAU.Value.ToString("dd/MM/yyyy").Substring(3, 2) + " năm " + item.NGAYBATDAU.Value.ToString("dd/MM/yyyy").Substring(6);
                hd.NGAYBATDAU = item.NGAYBATDAU.Value.ToString("dd/MM/yyyy");
                hd.NGAYKETTHUC = item.NGAYKETTHUC.Value.ToString("dd/MM/yyyy"); 
                //hd.NGAYKY = item.NGAYKY.Value.ToString("dd/MM/yyyy");
                hd.NGAYKY = "ngày " + item.NGAYKY.Value.ToString("dd/MM/yyyy").Substring(0, 2) + " tháng " + item.NGAYKY.Value.ToString("dd/MM/yyyy").Substring(3, 2) + " năm " + item.NGAYKY.Value.ToString("dd/MM/yyyy").Substring(6);
                hd.LANKY = item.LANKY;
                hd.HESOLUONG = item.HESOLUONG;
                hd.LUONGCOBAN = item.LUONGCOBAN;
                hd.NOIDUNG = item.NOIDUNG;
                hd.MANV = item.MANV;
                hd.THOIHAN = item.THOIHAN;
                var nv = db.tb_NHANVIEN.FirstOrDefault(n => n.MANV == item.MANV);
                hd.HOTEN = nv.HOTEN;
                hd.DIENTHOAI = nv.DIENTHOAI;
                hd.NGAYSINH = nv.NGAYSINH.Value.ToString("dd/MM/yyyy");
                hd.CCCD = nv.CCCD;
                hd.DIACHI = nv.DIACHI;
                hd.CREATED_BY = item.CREATED_BY;
                hd.CREATED_DATE = item.CREATED_DATE;
                hd.UPDATED_BY = item.UPDATED_BY;
                hd.UPDATED_DATE = item.UPDATED_DATE;
                hd.DELETED_BY = item.DELETED_BY;
                hd.DELETED_DATE = item.DELETED_DATE;
                hd.MACTY = item.MACTY;
                lstDTO.Add(hd);

            }
            return lstDTO;
        }
        public List<tb_HOPDONG> getList()
        {
            return db.tb_HOPDONG.ToList();
        }

        public List<HOPDONG_DTO> getListFull()
        {
            List<tb_HOPDONG> lstHD= db.tb_HOPDONG.ToList();
            List<HOPDONG_DTO> lstDTO = new List<HOPDONG_DTO>();
            HOPDONG_DTO hd;
            foreach(var item in lstHD)
            {
                hd = new HOPDONG_DTO();
                hd.SOHD = item.SOHD;
                //hd.NGAYBATDAU = "Từ ngày " + item.NGAYBATDAU.Value.ToString("dd/MM/yyyy").Substring(0, 2) + " tháng " + item.NGAYBATDAU.Value.ToString("dd/MM/yyyy").Substring(3, 2)+ " năm " + item.NGAYBATDAU.Value.ToString("dd/MM/yyyy").Substring(6);
                hd.NGAYBATDAU = item.NGAYBATDAU.Value.ToString("dd/MM/yyyy");
                hd.NGAYKETTHUC = item.NGAYKETTHUC.Value.ToString("dd/MM/yyyy");
                //hd.NGAYKY = item.NGAYKY.Value.ToString("dd/MM/yyyy");
                hd.NGAYKY = "ngày " + item.NGAYKY.Value.ToString("dd/MM/yyyy").Substring(0, 2) + " tháng " + item.NGAYKY.Value.ToString("dd/MM/yyyy").Substring(3, 2) + " năm " + item.NGAYKY.Value.ToString("dd/MM/yyyy").Substring(6);
                hd.LANKY = item.LANKY;
                hd.HESOLUONG = item.HESOLUONG;
                hd.LUONGCOBAN = item.LUONGCOBAN;
                hd.NOIDUNG = item.NOIDUNG;
                hd.MANV = item.MANV;    
                hd.THOIHAN = item.THOIHAN;
                var nv = db.tb_NHANVIEN.FirstOrDefault(n=>n.MANV==item.MANV);
                hd.HOTEN = nv.HOTEN;
                hd.NGAYSINH = nv.NGAYSINH.Value.ToString("dd/MM/yyyy");
                hd.DIENTHOAI = nv.DIENTHOAI;
                hd.CCCD =   nv.CCCD;
                hd.DIACHI = nv.DIACHI;                
                hd.CREATED_BY = item.CREATED_BY;
                hd.CREATED_DATE = item.CREATED_DATE;    
                hd.UPDATED_BY = item.UPDATED_BY;    
                hd.UPDATED_DATE = item.UPDATED_DATE;
                hd.DELETED_BY = item.DELETED_BY;    
                hd.DELETED_DATE = item.DELETED_DATE;
                hd.MACTY = item.MACTY;  
                lstDTO.Add(hd);

            }
            return lstDTO;
        }
        public tb_HOPDONG Add(tb_HOPDONG hd)
        {
            try
            {
                db.tb_HOPDONG.Add(hd);
                db.SaveChanges();
                return hd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public tb_HOPDONG Update(tb_HOPDONG hd)
        {
            try
            {
                var _hd= db.tb_HOPDONG.FirstOrDefault(x => x.SOHD == hd.SOHD);
                _hd.NGAYBATDAU = hd.NGAYBATDAU;
                _hd.NGAYKETTHUC = hd.NGAYKETTHUC;
                _hd.MANV = hd.MANV; 
                _hd.NGAYKY = hd.NGAYKY; 
                _hd.LANKY = hd.LANKY;
                _hd.HESOLUONG = hd.HESOLUONG;
                _hd.LUONGCOBAN = hd.LUONGCOBAN;
                _hd.NOIDUNG = hd.NOIDUNG;   
                _hd.THOIHAN = hd.THOIHAN;
                _hd.SOHD = hd.SOHD; 
                _hd.MACTY = hd.MACTY;  
                _hd.UPDATED_BY = hd.UPDATED_BY; 
                _hd.UPDATED_DATE = hd.UPDATED_DATE;
                

                db.SaveChanges();
                return hd;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void Delete(string sohd)
        {
            var _hd = db.tb_HOPDONG.FirstOrDefault(x => x.SOHD == sohd);

            _hd.DELETED_BY = UserId;
            _hd.DELETED_DATE = DateTime.Now;
        }
        public string MaxSoHopDong()
        {
            var _hd = db.tb_HOPDONG.OrderByDescending(x => x.CREATED_DATE).FirstOrDefault();// lấy theo ngày giảm dần và lấy ngày đầu tiên
            if (_hd != null)
            {
                return _hd.SOHD;
            }
            else
                return "00000";
        }
        
        public List<HOPDONG_DTO> getLenLuong()
        {
            List<tb_HOPDONG> lstHD = db.tb_HOPDONG.Where(x => /*(x.NGAYBATDAU.Value.Day - DateTime.Now.Day) == 0 && */(x.NGAYBATDAU.Value.Month - DateTime.Now.Month) == 0 && (DateTime.Now.Year - x.NGAYBATDAU.Value.Year) == 1).ToList(); // 1 năm lên lương 1 lần
            List<HOPDONG_DTO> lstDTO = new List<HOPDONG_DTO>();
            HOPDONG_DTO hd;
            foreach (var item in lstHD)
            {
                hd = new HOPDONG_DTO();
                hd.SOHD = item.SOHD;
                //hd.NGAYBATDAU = "Từ ngày " + item.NGAYBATDAU.Value.ToString("dd/MM/yyyy").Substring(0, 2) + " tháng " + item.NGAYBATDAU.Value.ToString("dd/MM/yyyy").Substring(3, 2)+ " năm " + item.NGAYBATDAU.Value.ToString("dd/MM/yyyy").Substring(6);
                hd.NGAYBATDAU = item.NGAYBATDAU.Value.ToString("dd/MM/yyyy");
                hd.NGAYKETTHUC = item.NGAYKETTHUC.Value.ToString("dd/MM/yyyy");
                //hd.NGAYKY = item.NGAYKY.Value.ToString("dd/MM/yyyy");
                hd.NGAYKY = "ngày " + item.NGAYKY.Value.ToString("dd/MM/yyyy").Substring(0, 2) + " tháng " + item.NGAYKY.Value.ToString("dd/MM/yyyy").Substring(3, 2) + " năm " + item.NGAYKY.Value.ToString("dd/MM/yyyy").Substring(6);
                hd.LANKY = item.LANKY;
                hd.HESOLUONG = item.HESOLUONG;
                hd.LUONGCOBAN = item.LUONGCOBAN;
                hd.NOIDUNG = item.NOIDUNG;
                hd.MANV = item.MANV;
                hd.THOIHAN = item.THOIHAN;
                var nv = db.tb_NHANVIEN.FirstOrDefault(n => n.MANV == item.MANV);
                hd.HOTEN = nv.HOTEN;
                hd.NGAYSINH = nv.NGAYSINH.Value.ToString("dd/MM/yyyy");
                hd.DIENTHOAI = nv.DIENTHOAI;
                hd.CCCD = nv.CCCD;
                hd.DIACHI = nv.DIACHI;
                hd.CREATED_BY = item.CREATED_BY;
                hd.CREATED_DATE = item.CREATED_DATE;
                hd.UPDATED_BY = item.UPDATED_BY;
                hd.UPDATED_DATE = item.UPDATED_DATE;
                hd.DELETED_BY = item.DELETED_BY;
                hd.DELETED_DATE = item.DELETED_DATE;
                hd.MACTY = item.MACTY;
                lstDTO.Add(hd);

            }
            return lstDTO;
        }

    }
}
