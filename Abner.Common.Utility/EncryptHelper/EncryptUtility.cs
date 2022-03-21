using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Abner.Common.Utility
{
    public class EncryptUtility
    {
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="plainText"></param>
        /// <param name="key">32位长度的字符串</param>
        /// <param name="IV">16位长度的字符串</param>
        /// <returns>返回base64编码后的字符串</returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static string AESEncrypt(string plainText, string key, string IV)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null)
                throw new ArgumentNullException("Key");
            if (key.Length != 32)
                throw new ArgumentException("Key's Length is not 32");
            if (IV == null)
                throw new ArgumentNullException("IV");
            if (IV.Length != 16)
                throw new ArgumentException("IV's Length is not 16");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = Encoding.UTF8.GetBytes(IV);

                // Create an encryptor to perform the stream transform.
                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for encryption.
                using (MemoryStream msEncrypt = new MemoryStream())
                {
                    using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                    {
                        using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                        {
                            //Write all data to the stream.
                            swEncrypt.Write(plainText);
                        }
                        encrypted = msEncrypt.ToArray();
                    }
                }
            }

            return Convert.ToBase64String(encrypted);
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="cipherText">base64编码的字符串</param>
        /// <param name="key">32位长度的字符串</param>
        /// <param name="IV">16位长度的字符串</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public static string AESDecrypt(string cipherText, string key, string IV)
        { 
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (key == null)
                throw new ArgumentNullException("Key");
            if (key.Length != 32)
                throw new ArgumentException("Key's Length is not 32");
            if (IV == null)
                throw new ArgumentNullException("IV");
            if (IV.Length != 16)
                throw new ArgumentException("IV's Length is not 16");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Encoding.UTF8.GetBytes(key);
                aesAlg.IV = Encoding.UTF8.GetBytes(IV);

                // Create a decryptor to perform the stream transform.
                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                // Create the streams used for decryption.
                using (MemoryStream msDecrypt = new MemoryStream(Convert.FromBase64String(cipherText)))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {

                            // Read the decrypted bytes from the decrypting stream
                            // and place them in a string.
                            plaintext = srDecrypt.ReadToEnd();
                        }
                    }
                }
            }

            return plaintext;
        }
    }
}
