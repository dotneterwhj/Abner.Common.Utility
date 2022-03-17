using System;
using System.Collections.Generic;
using System.Text;

namespace Abner.Common.Utility
{
    public class Base64Utility
    {
        /// <summary>
        /// base64编码，默认采用utf8
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Base64Encode(string str)
        {
            return Base64Encode(Encoding.UTF8, str);
        }

        /// <summary>
        /// base64编码
        /// </summary>
        /// <param name="encoding"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Base64Encode(Encoding encoding, string str)
        {
            var bytes = encoding.GetBytes(str);

            return Convert.ToBase64String(bytes, Base64FormattingOptions.None);
        }

        /// <summary>
        /// base64编码 简体中文
        /// </summary>
        /// <param name="encoding"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Base64Encode(GBKEncoding encoding, string str)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            return Base64Encode(Encoding.GetEncoding(encoding.ToString()), str);
        }

        /// <summary>
        /// base64解码，默认采用utf8
        /// </summary>
        /// <param name="base64Str"></param>
        /// <returns></returns>
        public static string Base64Decode(string base64Str)
        {
            return Base64Decode(Encoding.UTF8, base64Str);
        }

        /// <summary>
        /// base64解码
        /// </summary>
        /// <param name="encoding"></param>
        /// <param name="base64Str"></param>
        /// <returns></returns>
        public static string Base64Decode(Encoding encoding, string base64Str)
        {
            var str = Convert.FromBase64String(base64Str);

            return encoding.GetString(str);
        }

        /// <summary>
        /// base64解码 简体中文
        /// </summary>
        /// <param name="encoding"></param>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string Base64Decode(GBKEncoding encoding, string str)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);

            return Base64Decode(Encoding.GetEncoding(encoding.ToString()), str);
        }

    }
}
