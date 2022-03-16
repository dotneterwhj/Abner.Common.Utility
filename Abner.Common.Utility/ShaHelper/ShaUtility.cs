using System.Security.Cryptography;
using System.Text;

namespace Abner.Common.Utility
{
    public class ShaUtility
    {
        /// <summary>
        /// SHA1 加密 默认utf8编码
        /// </summary>
        /// <param name="str">需要加密字符串</param>
        /// <param name="encode">指定加密编码</param>
        public static string ComputeSHA1(string str)
        {
            using (var sha1 = SHA1.Create())
            {
                var buffer = Encoding.UTF8.GetBytes(str);
                var data = sha1.ComputeHash(buffer);
                var sb = new StringBuilder();
                foreach (var t in data)
                {
                    sb.Append(t.ToString("x2"));
                }
                return sb.ToString();
            }
        }

        /// <summary>
        /// SHA256加密
        /// </summary>
        /// <param name="str">要加密的string字符串</param>
        /// <returns>SHA256加密之后的密文</returns>
        public static string ComputeSHA256(string str)
        {
            using (var sha256 = SHA256.Create())
            {
                var buffer = Encoding.UTF8.GetBytes(str);
                var data = sha256.ComputeHash(buffer);
                var sb = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sb.Append(data[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
