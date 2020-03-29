using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
 
namespace Main.Tools
{
    /// <summary>
    /// 请求工具类
    /// </summary>
    public class HttpHelper
    {
        #region 请求
        /// <summary>
        /// 同步GET请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="param"></param>
        /// <param name="headers"></param>
        /// <param name="timeout">请求响应超时时间，单位/s(默认100秒)</param>
        /// <returns></returns>
        public static string HttpGet(string url, string param = "", Dictionary<string, string> headers = null, int timeout = 0)
        {
            url = url.LastIndexOf('?') > 0 ?
                $"{url}&{param}" :
                $"{url}?{param}";
            var httpclientHandler = new HttpClientHandler();
            httpclientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, error) => true;

            HttpClient client = HttpClientFactory.Create(httpclientHandler);
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            if (timeout > 0)
            {
                client.Timeout = new TimeSpan(0, 0, timeout);
            }
            Byte[] resultBytes = client.GetByteArrayAsync(url).Result;
            return Encoding.UTF8.GetString(resultBytes);
        }

        /// <summary>
        /// 同步POST请求
        /// </summary>
        /// <param name="url"></param>
        /// <param name="postData"></param>
        /// <param name="headers"></param>
        /// <param name="contentType"></param>
        /// <param name="timeout">请求响应超时时间，单位/s(默认100秒)</param>
        /// <param name="encoding">默认UTF8</param>
        /// <returns></returns>
        public static string HttpPost(string url, string postData, Dictionary<string, string> headers = null, string contentType = null, int timeout = 0, Encoding encoding = null)
        {
            var httpclientHandler = new HttpClientHandler();
            httpclientHandler.ServerCertificateCustomValidationCallback = (message, cert, chain, error) => true;

            HttpClient client = HttpClientFactory.Create(httpclientHandler);
            if (headers != null)
            {
                foreach (KeyValuePair<string, string> header in headers)
                {
                    client.DefaultRequestHeaders.Add(header.Key, header.Value);
                }
            }
            if (timeout > 0)
            {
                client.Timeout = new TimeSpan(0, 0, timeout);
            }
            using (HttpContent content = new StringContent(postData ?? "", encoding ?? Encoding.UTF8))
            {
                if (contentType != null)
                {
                    content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(contentType);
                }
                using (HttpResponseMessage responseMessage = client.PostAsync(url, content).Result)
                {
                    Byte[] resultBytes = responseMessage.Content.ReadAsByteArrayAsync().Result;
                    return Encoding.UTF8.GetString(resultBytes);
                }
            }
        }

        #endregion

        #region 扩展

        public static T HttpGet<T>(string url, string param = "", Dictionary<string, string> headers = null, int timeout = 0)
        {
            var ret = HttpGet(url, param, headers, timeout);
            return  JsonConvert.DeserializeObject<T>(ret);
        }

        public static T HttpPost<T>(string url, string postData, Dictionary<string, string> headers = null, string contentType = null, int timeout = 0, Encoding encoding = null)
        {
            var ret = HttpPost(url, postData, headers, contentType, timeout, encoding);
            return JsonConvert.DeserializeObject<T>(ret);
        }

        #endregion
    }
}