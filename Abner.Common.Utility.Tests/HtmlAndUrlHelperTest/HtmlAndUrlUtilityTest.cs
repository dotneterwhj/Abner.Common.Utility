using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xunit;

namespace Abner.Common.Utility.Tests.HtmlAndUrlHelper
{
    public class HtmlAndUrlUtilityTest
    {
        [Fact]
        public void HtmlEncodeOrDecode()
        {
            var html = @"<p>hello</p>";

            var string1 = HtmlAndUrlUtility.HtmlEncode("<p>hello</p>");
            var string11 = HtmlAndUrlUtility.HtmlEncode(string1);
            Assert.Equal(string11, HtmlAndUrlUtility.DoubleHtmlEncode(html));

            var string2 = HtmlAndUrlUtility.HtmlMiniEncode("<p>hello</p>");
            var string22 = HtmlAndUrlUtility.HtmlMiniEncode(string2);
            Assert.Equal(string22, HtmlAndUrlUtility.DoubleHtmlMiniEncode(html));

            var str3 = HtmlAndUrlUtility.HtmlDecode(string1);
            var str4 = HtmlAndUrlUtility.HtmlDecode(string2);

            Assert.Equal(html, str3);
            Assert.Equal(html, str4);
        }

        [Fact]
        public void UrlEncodeOrDecode()
        {
            var url = @"https://cn.bing.com/search?q=C#+数字枚举&qs=n&form=QBRE&sp=-1&pq=c#+数字枚举&sc=0-7&sk=&cvid=04847CCD3A1F4BC68F3CF30F13672715";

            var ur = HttpUtility.UrlEncodeUnicode(url);

            var url1 = HtmlAndUrlUtility.UrlEncode(url);
            var url2 = HtmlAndUrlUtility.UrlEncode(url1);
            Assert.Equal(url2, HtmlAndUrlUtility.DoubleUrlEncode(url));

            Assert.Equal(url, HtmlAndUrlUtility.UrlDecode(url1));
            Assert.Equal(url1, HtmlAndUrlUtility.UrlDecode(url2));
            Assert.Equal(url, HtmlAndUrlUtility.DoubleUrlDecode(url2));

        }
    }
}
