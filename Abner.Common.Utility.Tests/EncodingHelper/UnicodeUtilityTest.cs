
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace Abner.Common.Utility.Tests.EncodingHelper
{
    public class UnicodeUtilityTest
    {
        [Fact]
        public void Unicode()
        {

            var a = "你好，earth!\r\n好<p>sda</p>";
            //            var js = JsonConvert.SerializeObject(a,new JsonSerializerSettings
            //            {
            //                StringEscapeHandling = StringEscapeHandling.Default
            //            });

            var js = System.Text.Json.JsonSerializer.Serialize(a, new JsonSerializerOptions
            {
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.Default
            });

            var url = "http://www.baidu.com?t%3Dhello";

            var s = Regex.Unescape(js);
        }
    }
}
