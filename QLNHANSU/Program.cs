using DevExpress.Skins;
using DevExpress.UserSkins;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using BusinessLayer;

namespace QLNHANSU
{
    internal static class Program
    {
        public static int UserId { get; set; }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());
            Application.Run(new frmLogin());
        }

        //[STAThread]
        //static void Main(string[] args)
        //{
        //    string pass = "123";
        //    Clipboard.SetText(Encryption.Encrypt(pass));
        //    Console.WriteLine("Copied to clipboard");

        //}
    }
}
