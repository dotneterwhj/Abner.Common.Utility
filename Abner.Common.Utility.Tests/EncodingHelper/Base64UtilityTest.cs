using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Abner.Common.Utility.Tests.EncodingHelper
{
    public class Base64UtilityTest
    {
        [Fact]
        public void Base64EncodeAndDecode()
        {
            var st1 = "dsaasdqweqweqwe撕得粉碎的方式东方闪电dsaasdqweqweqwe撕得粉碎的方式东方闪电dsaasdqweqweqwe撕得粉碎的方式东方闪电dsaasdqweqweqwe撕得粉碎的方式东方闪电dsaasdqweqweqwe撕得粉碎的方式东方闪电dsaasdqweqweqwe撕得粉碎的方式东方闪电dsaasdqweqweqwe撕得粉碎的方式东方闪电dsaasdqweqweqwe撕得粉碎的方式东方闪电";
            var s1 = Base64Utility.Base64Encode(st1);
            var des1 = Base64Utility.Base64Decode(s1);
            Assert.Equal(st1, des1);

            var st2 = "kjhsdjfasoiwe32092sdfsd";
            var s2 = Base64Utility.Base64Encode(Encoding.ASCII, st2);
            var des2 = Base64Utility.Base64Decode(Encoding.ASCII, s2);
            Assert.Equal(st2, des2);

            var st3 = "dsaasdqweqweqwe撕得粉碎的方式东方闪电";
            var s3 = Base64Utility.Base64Encode(Encoding.Unicode, st3);
            var des3 = Base64Utility.Base64Decode(Encoding.Unicode, s3);
            Assert.Equal(st3, des3);

            var st4 = "dsaasdqweqweqwe撕得粉碎的方式东方闪电";
            var s4 = Base64Utility.Base64Encode(GBKEncoding.GBK, st4);
            var des4 = Base64Utility.Base64Decode(GBKEncoding.GBK, s4);
            Assert.Equal(st4, des4);

            var st5 = "dsaasdqweqweqwe撕得粉碎的方式东方闪电";
            var s5 = Base64Utility.Base64Encode(GBKEncoding.GB18030, st5);
            var des5 = Base64Utility.Base64Decode(GBKEncoding.GB18030, s5);
            Assert.Equal(st5, des5);

            var st6 = "dsaasdqweqweqwe撕得粉碎的方式东方闪电";
            var s6 = Base64Utility.Base64Encode(GBKEncoding.GB2312, st6);
            var des6 = Base64Utility.Base64Decode(GBKEncoding.GB18030, s6);
            Assert.Equal(st6, des6);
        }
    }
}
