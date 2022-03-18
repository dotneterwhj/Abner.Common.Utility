using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Abner.Common.Utility.Tests.EncyptHelperTest
{
    public class EncyptUtilityTest
    {
        [Fact]
        public void AESEncypt()
        {
            var key1 = Random.Shared.Next(343465767);
            var key2 = Random.Shared.Next(334098343);

            Assert.Throws<ArgumentNullException>(() => EncryptUtility.AESEncrypt("stetsaasd", null, "70(*&^%$#@hsac1q"));
            Assert.Throws<ArgumentNullException>(() => EncryptUtility.AESEncrypt(null, "sdhqjekalsoeiwjqna)2(12kfiuwqdf1", "70(*&^%$#@hsac1q"));
            Assert.Throws<ArgumentNullException>(() => EncryptUtility.AESEncrypt("stetsaasd", "sdhqjekalsoeiwjqna)2(12kfiuwqdf1", null));


            Assert.Throws<ArgumentException>(() => EncryptUtility.AESEncrypt("stetsaasd", "sdhqjekalsoeiwjqna)2(12kfiuwqdf1", key2.ToString()));
            Assert.Throws<ArgumentException>(() => EncryptUtility.AESEncrypt("stetsaasd", key1.ToString(), "70(*&^%$#@hsac1q"));

            var encrypt = EncryptUtility.AESEncrypt(key1.ToString(), "sdhqjekalsoeiwjqna)2(12kfiuwqdf1", "70(*&^%$#@hsac1q");
            var decrypt = EncryptUtility.AESDecrypt(encrypt, "sdhqjekalsoeiwjqna)2(12kfiuwqdf1", "70(*&^%$#@hsac1q");
            Assert.Equal(key1.ToString(), decrypt);

            Assert.Throws<ArgumentNullException>(() => EncryptUtility.AESDecrypt("stetsaasd", null, "70(*&^%$#@hsac1q"));
            Assert.Throws<ArgumentNullException>(() => EncryptUtility.AESDecrypt(null, "sdhqjekalsoeiwjqna)2(12kfiuwqdf1", "70(*&^%$#@hsac1q"));
            Assert.Throws<ArgumentNullException>(() => EncryptUtility.AESDecrypt("stetsaasd", "sdhqjekalsoeiwjqna)2(12kfiuwqdf1", null));


            Assert.Throws<ArgumentException>(() => EncryptUtility.AESDecrypt("stetsaasd", "sdhqjekalsoeiwjqna)2(12kfiuwqdf1", key2.ToString()));
            Assert.Throws<ArgumentException>(() => EncryptUtility.AESDecrypt("stetsaasd", key1.ToString(), "70(*&^%$#@hsac1q"));

        }
    }
}
