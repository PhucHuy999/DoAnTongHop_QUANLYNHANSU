﻿using BusinessLayer;
using DataLayer;
using DevExpress.Accessibility;
using DevExpress.XtraEditors;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace QLNHANSU
{
    public partial class frmLogin : DevExpress.XtraEditors.XtraForm
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        //USERS _user;
        USERS user = new USERS();


        private void frmLogin_Load(object sender, EventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Bạn có muốn thoát ?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
                Application.Exit();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            if(txtUserName.Text == "")
            {
                MessageBox.Show("Hãy nhập Tên Đăng nhập.", "Thông báo");
                txtUserName.Focus();
                return;
            }    
            if(txtPass.Text == "")
            {
                MessageBox.Show("Hãy nhập Mật Khẩu.", "Thông báo");
                txtPass.Focus();
                return;
            }    
            DataTable dt = new DataTable();

            string taikhoan = txtUserName.Text;
            string matkhau = txtPass.Text;
            matkhau = Encryption.Encrypt(matkhau);


            dt = user.GetData("select * from tb_User where USERNAME = '" + taikhoan + "' and PASS ='" + matkhau + "'");
            if (dt.Rows.Count == 1)
            {
                Program.UserId = Convert.ToInt32(dt.Rows[0][0]);
                MainForm f = new MainForm(dt.Rows[0][0].ToString(), dt.Rows[0][1].ToString(), dt.Rows[0][2].ToString(), dt.Rows[0][3].ToString(), dt.Rows[0][4].ToString());
                f.ShowDialog();
                this.Hide();
                this.Close();

            }

            else
            {
                MessageBox.Show("Tên đăng nhập hoặc mật khẩu không đúng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



        }

        private void chkHienMatKhau_CheckedChanged(object sender, EventArgs e)
        {
            if (chkHienMatKhau.Checked)
            {
                txtPass.PasswordChar = (char)0;
            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }


    }
}