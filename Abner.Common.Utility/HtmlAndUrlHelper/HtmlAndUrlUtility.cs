using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Abner.Common.Utility
{
    public class HtmlAndUrlUtility
    {
        /// <summary>
        /// Url编码，默认使用UTF8
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string UrlEncode(string url)
        {
            if (string.IsNullOrEmpty(url)) return url;
            return UrlEncode(url, Encoding.UTF8);
        }

        /// <summary>
        /// Url双重编码，默认使用UTF8
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string DoubleUrlEncode(string url)
        {
            return UrlEncode(UrlEncode(url));
        }

        /// <summary>
        /// Url编码
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string UrlEncode(string url, Encoding encoding)
        {
            if (string.IsNullOrEmpty(url)) return url;
            return HttpUtility.UrlEncode(url, encoding);
        }

        /// <summary>
        /// Url双重编码
        /// </summary>
        /// <param name="url"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string DoubleUrlEncode(string url, Encoding encoding)
        {
            return UrlEncode(UrlEncode(url, encoding), encoding);
        }

        /// <summary>
        /// Url解码，默认UTF8
        /// </summary>
        /// <param name="encodingUrl"></param>
        /// <returns></returns>
        public static string UrlDecode(string encodingUrl)
        {
            if (string.IsNullOrEmpty(encodingUrl)) return encodingUrl;
            return UrlDecode(encodingUrl, Encoding.UTF8);
        }

        /// <summary>
        /// url解码
        /// </summary>
        /// <param name="encodingUrl"></param>
        /// <returns></returns>
        public static string UrlDecode(string encodingUrl, Encoding encoding)
        {
            if (string.IsNullOrEmpty(encodingUrl)) return encodingUrl;
            return HttpUtility.UrlDecode(encodingUrl, encoding);
        }

        /// <summary>
        /// url双重解码，默认UTF8
        /// </summary>
        /// <param name="encodingUrl"></param>
        /// <returns></returns>
        public static string DoubleUrlDecode(string encodingUrl)
        {
            return UrlDecode(UrlDecode(encodingUrl));
        }

        /// <summary>
        /// url双重解码
        /// </summary>
        /// <param name="encodingUrl"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string DoubleUrlDecode(string encodingUrl, Encoding encoding)
        {
            return UrlDecode(UrlDecode(encodingUrl, encoding), encoding);
        }

        /// <summary>
        /// html编码
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string HtmlEncode(string html)
        {
            if (string.IsNullOrEmpty(html)) return html;
            return HttpUtility.HtmlEncode(html);
        }

        /// <summary>
        /// html双重编码
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string DoubleHtmlEncode(string html)
        {
            return HtmlEncode(HtmlEncode(html));
        }

        /// <summary>
        /// html最小化编码，只编码一个尖括号
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string HtmlMiniEncode(string html)
        {
            if (string.IsNullOrEmpty(html)) return html;
            return HttpUtility.HtmlAttributeEncode(html);
        }

        /// <summary>
        /// html最小化双重编码，只编码一个尖括号
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        public static string DoubleHtmlMiniEncode(string html)
        {
            return HtmlMiniEncode(HtmlMiniEncode(html));
        }

        /// <summary>
        /// html解码
        /// </summary>
        /// <param name="encodeHtml"></param>
        /// <returns></returns>
        public static string HtmlDecode(string encodeHtml)
        {
            if (string.IsNullOrEmpty(encodeHtml)) return encodeHtml;
            return HttpUtility.HtmlDecode(encodeHtml);
        }

        /// <summary>
        /// html双重解码
        /// </summary>
        /// <param name="encodeHtml"></param>
        /// <returns></returns>
        public static string DoubleHtmlDecode(string encodeHtml)
        {
            return HtmlDecode(HtmlDecode(encodeHtml));
        }
    }
}
