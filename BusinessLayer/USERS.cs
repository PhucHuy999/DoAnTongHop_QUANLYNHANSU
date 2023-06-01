using DataLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class USERS
    {
        QLNHANSUEntities db = new QLNHANSUEntities();
        public tb_User getItem(int idUser)
        {
            return db.tb_User.FirstOrDefault(x => x.IDUSER == idUser);
        }
        public tb_User getItem(string username, int macty)
        {
            return db.tb_User.FirstOrDefault(x => x.USERNAME == username && x.MACTY == macty);
        }
        public List<tb_User> getList()
        {
            return db.tb_User.ToList();
        }
        public tb_User Add(tb_User us)
        {
            try
            {
                db.tb_User.Add(us);
                db.SaveChanges();
                return us;
            }
            catch (Exception ex)
            {
                throw new Exception("lỗi: " + ex.Message);
            }
        }
        public tb_User Update(tb_User us)
        {

            var _us = db.tb_User.FirstOrDefault(x => x.IDUSER == us.IDUSER);
            _us.FULLNAME = us.FULLNAME;
            _us.PASS = us.PASS;
            _us.DIENTHOAI = us.DIENTHOAI;
            _us.EMAIL = us.EMAIL;
            _us.DIACHI = us.DIACHI;
            try
            {
                db.SaveChanges();
                return us;
            }
            catch (Exception ex)
            {
                throw new Exception("lỗi: " + ex.Message);
            }



        }

        //public int Login(string username, string pass )
        //{
        //    var us = db.tb_User.FirstOrDefault(x => x.USERNAME == username && x.PASS == pass);
        //    if (us != null)
        //        return 1;
        //    else
        //        return 0;
        //}

        //------------------------------
        #region Availible
        private SqlConnection Conn;
        private SqlCommand _cmd;
        private string StrCon = null;
        private string _error;

        public string Error
        {
            get { return _error; }
            set { _error = value; }
        }

        public SqlConnection Connection
        {
            get { return Conn; }
        }

        public SqlCommand CMD
        {
            get { return _cmd; }
            set { _cmd = value; }
        }



        #endregion
        #region Contrustor
        public USERS()
        {

            StrCon = @"Data Source=HY\PHUCHUY; ;Initial Catalog = QLNHANSU; User = sa; Password=123321";
            Conn = new SqlConnection(StrCon);
        }
        #endregion

        #region Methods
        public bool OpenConn()
        {
            try
            {
                if (Conn.State == ConnectionState.Closed)
                    Conn.Open();
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return false;
            }
            return true;
        }

        public bool CloseConn()
        {
            try
            {
                if (Conn.State == ConnectionState.Open)
                    Conn.Close();
            }
            catch (Exception ex)
            {
                _error = ex.Message;
                return false;
            }
            return true;
        }



        public DataTable GetData(string sql)
        {
            DataTable dt = new DataTable();
            _cmd = new SqlCommand();
            _cmd.CommandText = sql;
            _cmd.CommandType = CommandType.Text;
            _cmd.Connection = Conn;
            try
            {
                this.OpenConn();
                SqlDataAdapter sda = new SqlDataAdapter(_cmd);
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                _cmd.Dispose();
                this.CloseConn();
            }
            return dt;
        }

        public bool SetData(string sql)
        {
            _cmd = new SqlCommand();
            _cmd.CommandText = sql;
            _cmd.CommandType = CommandType.Text;
            _cmd.Connection = Conn;
            try
            {
                this.OpenConn();
                _cmd.ExecuteNonQuery();
                return true;
            }
            catch (Exception ex)
            {
                string mex = ex.Message;
                _cmd.Dispose();
                this.CloseConn();
            }
            return false;
        }
        //public List<tb_CHITIETQUYEN> getQuyen(int idnhom)
        //{
        //    List<tb_CHITIETQUYEN> obs = null;
        //    obs = db.chitietQHs.where (x=>x.nhomquyen==idnhom).ToList();    
        //    return obs;
        //}
        #endregion

    }
}
