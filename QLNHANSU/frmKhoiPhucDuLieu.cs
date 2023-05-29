using DevExpress.XtraEditors;
using DevExpress.XtraSplashScreen;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLNHANSU
{
    public partial class frmKhoiPhucDuLieu : DevExpress.XtraEditors.XtraForm
    {
        public frmKhoiPhucDuLieu()
        {
            InitializeComponent();
        }
        SqlConnection con = new SqlConnection("Data Source = HY\\PHUCHUY; Initial Catalog = QLNHANSU; User ID= sa; Password=123321;");
        private void frmKhoiPhucDuLieu_Load(object sender, EventArgs e)
        {
            txtUrl.Enabled = false;
            btnKhoiPhuc.Enabled = false;
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Backup file (.bak)|*.bak";
            openFile.Title = "Phục hồi dữ liệu";
            if(openFile.ShowDialog()==DialogResult.OK)
            {
                txtUrl.Text = openFile.FileName;
                btnKhoiPhuc.Enabled = true;
            }
        }

        private void btnKhoiPhuc_Click(object sender, EventArgs e)
        {
            string database = con.Database.ToString();
            con.Open();
            try
            {
                SplashScreenManager.ShowForm(this, typeof(frmWaiting), true, true, false);
                string sql1 = "ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE";
                SqlCommand cmd1 = new SqlCommand(sql1, con);
                cmd1.ExecuteNonQuery();

                string sql2 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK='"+txtUrl.Text+"' WITH REPLACE";
                SqlCommand cmd2 = new SqlCommand(sql2, con);
                cmd2.ExecuteNonQuery();

                string sql3 = "ALTER DATABASE [" + database + "] SET MULTI_USER";
                SqlCommand cmd3 = new SqlCommand(sql3, con);
                cmd3.ExecuteNonQuery();

                con.Close();
                SplashScreenManager.CloseForm(true);
                MessageBox.Show("Khôi phục dữ liệu thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnKhoiPhuc.Enabled = false;
            }
            catch (Exception )
            {
                SplashScreenManager.CloseForm(true);
                btnKhoiPhuc.Enabled = false;
                MessageBox.Show("Khôi phục dữ liệu không thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
    }
}