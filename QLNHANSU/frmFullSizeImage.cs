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
    public partial class frmFullSizeImage : DevExpress.XtraEditors.XtraForm
    {
        public frmFullSizeImage()
        {
            InitializeComponent();
        }
        public frmFullSizeImage(Image img, string hoten)
        {
            InitializeComponent();
            this._image = img;
            this._hoten = hoten;    

        }
        Image _image;
        string _hoten;
        private void frmFullSizeImage_Load(object sender, EventArgs e)
        {
            pictureBox1.Image = _image;
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;// co giãn form theo cỡ nào thì nó phóng ra cỡ đó
            groupBox1.Text = _hoten;           
        }
    }
}