using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Abner.Common.Utility
{

    public enum Bits
    {
        Eight,
        Sixteen,
        ThirtyTwo
    }

    public class Md5Utility
    {

        private static string GetString(byte[] md5Bytes, Bits bits = Bits.ThirtyTwo)
        {
            string md5string = string.Empty;

            int start = 0, end = 16;
            switch (bits)
            {
                case Bits.Eight:
                    start = 8;
                    end = 12;
                    break;
                case Bits.Sixteen:
                    start = 4;
                    end = 12;
                    break;
                case Bits.ThirtyTwo:
                    start = 0;
                    end = 16;
                    break;
                default:
                    throw new ArgumentException($"不存在的枚举类型{bits}");
            }
            for (int i = start; i < end; i++)
            {
                md5string += md5Bytes[i].ToString("x2");
            }

            return md5string;
        }

        /// <summary>
        /// 获取MD5字符串
        /// </summary>
        /// <param name="str">需要转换的字符串</param>
        /// <param name="bits">转换的位数</param>
        /// <returns>MD5字符串</returns>
        public static string ComputeMd5(string str, Bits bits = Bits.ThirtyTwo)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] buffer = Encoding.UTF8.GetBytes(str);
                byte[] md5Bytes = md5.ComputeHash(buffer);
                return GetString(md5Bytes, bits);
            }
        }

        /// <summary>
        /// 获取文件的MD5值
        /// </summary>
        /// <param name="file">指定的文件</param>
        /// <returns>MD5字符串</returns>
        public static string ComputeMd5(FileInfo file, Bits bits = Bits.ThirtyTwo)
        {
            if (!file.Exists)
            {
                throw new FileNotFoundException();
            }
            using (MD5 md5 = MD5.Create())
            {
                byte[] md5Bytes = null;
                using (FileStream fsRead = new FileStream(file.FullName, FileMode.Open, FileAccess.Read))
                {
                    md5Bytes = md5.ComputeHash(fsRead);
                }

                return GetString(md5Bytes, bits);
            }

        }
    }
}