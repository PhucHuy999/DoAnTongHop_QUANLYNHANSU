using BusinessLayer;
using DataLayer;
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

namespace QLNHANSU
{
    public partial class frmDoiMatKhau : DevExpress.XtraEditors.XtraForm
    {
        
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }
        USERS _user = new USERS();

        
        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {

        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (txtTenDangNhap.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Tên Đăng Nhập.", "Thông báo");
                txtTenDangNhap.Focus();
                return;
            }
            if (txtMKcu.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Mật Khẩu Cũ.", "Thông báo");
                txtMKcu.Focus();
                return;
            }
            if (txtMKmoi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Mật Khẩu Mới.", "Thông báo");
                txtMKmoi.Focus();
                return;
            }
            if (txtXacNhanMKmoi.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập xác nhận Mật Khẩu Mới.", "Thông báo");
                txtXacNhanMKmoi.Focus();
                return;
            }
            DataTable dmk = new DataTable();
            string tendangnhap = txtTenDangNhap.Text;
            string matkhaucu = txtMKcu.Text;
            matkhaucu = Encryption.Encrypt(matkhaucu);

            string matkhaumoi = txtMKmoi.Text;
            matkhaumoi = Encryption.Encrypt(matkhaumoi);

            dmk = _user.GetData("select * from tb_User where USERNAME = '" + tendangnhap + "' and PASS ='" + matkhaucu + "'");
            if (dmk.Rows.Count == 1)
            {
                if (txtMKmoi.Text.Equals(txtXacNhanMKmoi.Text))
                {
                    _user.SetData("update tb_User set PASS ='" + matkhaumoi + "' where USERNAME = '" + tendangnhap + "' and PASS ='" + matkhaucu + "'");
                    MessageBox.Show("Đổi mật khẩu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Restart();// sau khi đổi thành công bắt đăng nhập lại cho chắc :v
                    Environment.Exit(0);//Thoát biến toàn cục
                }
                else
                {
                    MessageBox.Show("Mật khẩu mới không trùng nhau.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu của bạn muốn đổi không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }    
            
            

        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienMatKhau.Checked)
            {
                txtMKcu.PasswordChar = (char)0;
                txtMKmoi.PasswordChar = (char)0;
                txtXacNhanMKmoi.PasswordChar = (char)0;
            }
            else
            {
                txtMKcu.PasswordChar = '*';
                txtMKmoi.PasswordChar = '*';
                txtXacNhanMKmoi.PasswordChar = '*';
            }
        }
    }
}