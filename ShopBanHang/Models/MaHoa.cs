using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Cryptography;
using System.Text;
namespace ShopBanHang.Models
{
    public class MaHoa
    {
        public static string encryptSHA256(string PlainText)
        {
            string reuslt = "";
            using (SHA256 bb = SHA256.Create())
            {
                byte[] sourceData = Encoding.UTF8.GetBytes(PlainText);

                byte[] hashResult = bb.ComputeHash(sourceData);
                reuslt = BitConverter.ToString(hashResult);
            }    
                return reuslt;
        }
    }
}