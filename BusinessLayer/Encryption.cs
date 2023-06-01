using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public static class Encryption
    {
        public static string Encrypt(string _input)
        {


            using (MD5 md5Hash = MD5.Create())
            {

                string hash = GetMD5Hash(md5Hash, _input);
                return hash;
                //return MyEncrypt(hash);
            }
        }
        public static string MyEncrypt(string _input)
        {
            // abc ~> 48 49 50: 48 +0+(49%2) ; 49+1+50%2    công thức
            // chuyển thành mảng char
            char[] char_input = _input.ToCharArray();


            //select val + ind ~> ano. type
            var input_WithIndex = char_input.Select((val, ind) => new { val, ind }).ToArray();

            //áp dụng công thức 
            var char_input_encripted = input_WithIndex.Select(c => c.val + c.ind +
            (input_WithIndex.Length > c.ind + 1 ? input_WithIndex[c.ind + 1].val % 2 : 0)).Select(c => (char)c).ToArray();

            //chuyển về string
            string resval = new string(char_input_encripted);
            return resval;
        }
        public static string GetMD5Hash(MD5 md5Hash, string input)
        {

            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            StringBuilder sBuilder = new StringBuilder();

            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();
        }
    }
}
