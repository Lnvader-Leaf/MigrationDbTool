using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MigrationDbForEF.ToolHelper
{
    public static class Helper
    {
        public static string GetTimeStamp(bool bflag)
        {
            TimeSpan ts = DateTime.UtcNow - new DateTime(1970, 1, 1, 0, 0, 0, 0);
            string ret = string.Empty;
            if (bflag)
                ret = Convert.ToInt64(ts.TotalSeconds).ToString();
            else
                ret = Convert.ToInt64(ts.TotalMilliseconds).ToString();

            return ret;
        }

        public static string Md5Func(string source)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.UTF8.GetBytes(source);
            byte[] md5Data = md5.ComputeHash(data, 0, data.Length);
            md5.Clear();

            string destString = string.Empty;
            for (int i = 0; i < md5Data.Length; i++)
            {
                //返回一个新字符串，该字符串通过在此实例中的字符左侧填充指定的 Unicode 字符来达到指定的总长度，从而使这些字符右对齐。
                // string num=12; num.PadLeft(4, '0'); 结果为为 '0012' 看字符串长度是否满足4位,不满足则在字符串左边以"0"补足
                //调用Convert.ToString(整型,进制数) 来转换为想要的进制数
                destString += System.Convert.ToString(md5Data[i], 16).PadLeft(2, '0');
            }
            //使用 PadLeft 和 PadRight 进行轻松地补位
            destString = destString.PadLeft(32, '0');
            return destString;
        }

        /// <summary>
        /// 发起POST同步请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="contentType">application/xml、application/json、application/text、application/x-www-form-urlencoded</param>
        /// <param name="headers">填充消息头</param>
        /// <returns></returns>
        public static string HttpPost(string url, string postData = null, string contentType = "application/json", int timeOut = 30, Dictionary<string, string> headers = null)
        {
            postData = postData ?? "";
            using (HttpClient client = new HttpClient())
            {
                if (headers != null)
                {
                    foreach (var header in headers)
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                using (HttpContent httpContent = new StringContent(postData, Encoding.UTF8))
                {
                    if (contentType != null)
                        httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);

                    HttpResponseMessage response = client.PostAsync(url, httpContent).Result;
                    return response.Content.ReadAsStringAsync().Result;
                }
            }
        }

        /// <summary>
        /// 发起POST异步请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="contentType">application/xml、application/json、application/text、application/x-www-form-urlencoded</param>
        /// <param name="headers">填充消息头</param>
        /// <returns></returns>
        public static async Task<string> HttpPostAsync(string url, string postData = null, string contentType = "application/json", int timeOut = 30, Dictionary<string, string> headers = null)
        {
            postData = postData ?? "";
            using (HttpClient client = new HttpClient())
            {
                client.Timeout = new TimeSpan(0, 0, timeOut);
                if (headers != null)
                {
                    foreach (var header in headers)
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                using (HttpContent httpContent = new StringContent(postData, Encoding.UTF8))
                {
                    if (contentType != null)
                        httpContent.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);

                    HttpResponseMessage response = await client.PostAsync(url, httpContent);
                    return await response.Content.ReadAsStringAsync();
                }
            }
        }

        /// <summary>
        /// 发起GET同步请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static string HttpGet(string url, string contentType = "application/json", Dictionary<string, string> headers = null)
        {
            using (HttpClient client = new HttpClient())
            {
                if (contentType != null)
                    client.DefaultRequestHeaders.Add("ContentType", contentType);
                if (headers != null)
                {
                    foreach (var header in headers)
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                HttpResponseMessage response = client.GetAsync(url).Result;
                return response.Content.ReadAsStringAsync().Result;
            }
        }

        /// <summary>
        /// 发起GET异步请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="headers"></param>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static async Task<string> HttpGetAsync(string url, string contentType = "application/json", Dictionary<string, string> headers = null)
        {
            using (HttpClient client = new HttpClient())
            {
                if (contentType != null)
                    client.DefaultRequestHeaders.Add("ContentType", contentType);
                if (headers != null)
                {
                    foreach (var header in headers)
                        client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
                HttpResponseMessage response = await client.GetAsync(url);
                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
