﻿using BusinessLayer;
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

namespace QLNHANSU.TINHLUONG
{
    public partial class frmPhuCap : DevExpress.XtraEditors.XtraForm
    {
        public frmPhuCap()
        {
            InitializeComponent();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }
        PHUCAP _phucap;
        NHANVIEN _nhanvien;
        List<NHANVIEN_PHUCAP_DTO> _lstNVPCDTO;

        bool _them;
        int _id;
        private void frmPhuCap_Load(object sender, EventArgs e)
        {
            _them = false;
            _phucap = new PHUCAP(Program.UserId);
            _nhanvien = new NHANVIEN();
            _showHide(true);
            loadData();
            loadNhanVien();
            loadPhuCap();
            cboPhuCap.SelectedIndexChanged += CboPhuCap_SelectedIndexChanged;
        }

        private void CboPhuCap_SelectedIndexChanged(object sender, EventArgs e)
        {
            var pc = _phucap.getItemPC(int.Parse(cboPhuCap.SelectedValue.ToString()));
            if(pc!=null)
            {
                spSoTien.EditValue = pc.SOTIEN;
            }
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
            txtNoiDung.Enabled = !kt;
            spSoTien.Enabled = !kt;
            lkNhanVien.Enabled = !kt;
            cboPhuCap.Enabled = !kt;

        }
        void loadNhanVien()
        {
            lkNhanVien.Properties.DataSource = _nhanvien.getListFull();
            lkNhanVien.Properties.DisplayMember =  "HOTEN";
            lkNhanVien.Properties.ValueMember = "MANV";
        }
        void loadPhuCap()
        {
            cboPhuCap.DataSource = _phucap.getListPC();
            cboPhuCap.DisplayMember = "TENPC";
            cboPhuCap.ValueMember = "IDPC";
        }
        void loadData()
        {
            gcDanhSach.DataSource = _phucap.getListFull();
            gvDanhSach.OptionsBehavior.Editable = false;
            _lstNVPCDTO = _phucap.getListFull();
        }
        private void btnThem_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = true;
            txtNoiDung.Text = string.Empty;
            spSoTien.EditValue = 0;
            lkNhanVien.EditValue = 0;
            cboPhuCap.SelectedIndex = 0;
        }

        private void btnSua_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _showHide(false);
            _them = false;
        }

        private void btnXoa_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn xóa không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                _phucap.Delete(_id);
                loadData();
            }
        }

        private void btnLuu_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            SaveData();
            loadData();
            _showHide(true);
            _them = false;
        }

        private void btnHuy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            _them = false;
            _showHide(true);
        }

        private void btnIn_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            rptDanhSachPhuCap rpt = new rptDanhSachPhuCap(_lstNVPCDTO);
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
                tb_NHANVIEN_PHUCAP pc = new tb_NHANVIEN_PHUCAP();
                pc.IDPC = int.Parse(cboPhuCap.SelectedValue.ToString());
                pc.SOTIEN = int.Parse(spSoTien.EditValue.ToString());
                pc.MANV = int.Parse(lkNhanVien.EditValue.ToString());
                pc.NOIDUNG = txtNoiDung.Text;
                pc.NGAY = DateTime.Now;
                pc.CREATED_DATE = DateTime.Now;
                pc.CREATED_BY = Program.UserId;
                _phucap.Add(pc);

            }
            else
            {
                var pc = _phucap.getItem(_id);
                pc.IDPC = int.Parse(cboPhuCap.SelectedValue.ToString());
                pc.SOTIEN = int.Parse(spSoTien.EditValue.ToString());
                pc.MANV = int.Parse(lkNhanVien.EditValue.ToString());
                pc.NOIDUNG = txtNoiDung.Text;
                pc.NGAY = DateTime.Now;
                pc.UPDATED_BY = Program.UserId;
                pc.UPDATED_DATE = DateTime.Now;
                _phucap.Update(pc);
            }
        }

        private void gvDanhSach_Click(object sender, EventArgs e)
        {
            if (gvDanhSach.RowCount > 0)  // nếu có giá trị trong lưới thì mới chạy để không báo lỗi không có giá trị mà click á
            {
                _id = int.Parse(gvDanhSach.GetFocusedRowCellValue("ID").ToString());
                txtNoiDung.Text = gvDanhSach.GetFocusedRowCellValue("NOIDUNG").ToString();
                spSoTien.EditValue = gvDanhSach.GetFocusedRowCellValue("SOTIEN");
                lkNhanVien.EditValue = gvDanhSach.GetFocusedRowCellValue("MANV");
                cboPhuCap.SelectedValue = gvDanhSach.GetFocusedRowCellValue("IDPC");
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
    }
}