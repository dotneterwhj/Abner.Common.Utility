using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Abner.Common.Utility
{
    public class UnicodeUtility
    {
        /// <summary> 
        /// 字符串转为UniCode码字符串 
        /// </summary> 
        /// <param name="str"></param> 
        /// <returns>Unicode编码后的字符串</returns> 
        public static string ToUnicode(string str)
        {
            char[] charbuffers = str.ToCharArray();
            byte[] buffer;
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < charbuffers.Length; i++)
            {
                buffer = System.Text.Encoding.Unicode.GetBytes(charbuffers[i].ToString());
                sb.Append(String.Format("\\u{0:X2}{1:X2}", buffer[1], buffer[0]));
            }
            return sb.ToString();
        }

        /// <summary>
        /// Unicode字符串解码
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string EscapeUnicode(string str)
        {
            return Regex.Escape(str);
        }

        public static string ToJsonUnicode<T>(T obj) where T : class, new()
        {
            return JsonConvert.SerializeObject(obj, new JsonSerializerSettings
            {
                StringEscapeHandling = StringEscapeHandling.EscapeNonAscii
            });
        }
    }
}
