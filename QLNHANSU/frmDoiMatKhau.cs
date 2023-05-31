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
        public frmDoiMatKhau(tb_User user)
        {
            InitializeComponent();
            this._user = user;
        }
        tb_User _user;
        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            _user = new tb_User();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {

        }

        private void btnDong_Click(object sender, EventArgs e)
        {

        }
    }
}