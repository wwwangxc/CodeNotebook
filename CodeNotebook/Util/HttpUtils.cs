using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace CodeNotebook.Util
{

    public static class HttpUtils
    {
        public static HttpHandler Get(string url) => new HttpHandler().CreateGetRequest(url);
        public static HttpHandler Post(string url) => new HttpHandler().CreatePostRequest(url);
    }

    public class HttpHandler
    {
        private HttpRequestInfo RequestInfo { get; set; } = new HttpRequestInfo();
        public HttpHandler CreatePostRequest(string url)
        {
            this.RequestInfo.Method = "POST";
            this.RequestInfo.Url = url;
            this.RequestInfo.ContentType = "application/json";
            return this;
        }
        public HttpHandler CreateGetRequest(string url)
        {
            this.RequestInfo.Method = "GET";
            this.RequestInfo.Url = url;
            this.RequestInfo.ContentType = "application/json";
            return this;
        }
        public HttpHandler ContentType(string value)
        {
            this.RequestInfo.ContentType = value;
            return this;
        }
        public HttpHandler Header(string key, string value)
        {
            if (string.IsNullOrWhiteSpace(key)) return this;
            if (key.ToLower() == "content-type")
            {
                this.ContentType(value);
            }
            else
            {
                this.RequestInfo.Headers.Add(key, value);
            }
            return this;
        }
        public HttpHandler Param(string name, object value)
        {
            this.RequestInfo.Params.Add(name, value);
            return this;
        }
        public HttpHandler Body(string body)
        {
            this.RequestInfo.Body = body;
            return this;
        }
        public T Do<T>() => this.GetResult<T>(this.GetRequest().GetResponse() as HttpWebResponse);
        private HttpWebRequest GetRequest()
        {
            this.CheckRequestInfo();
            var request = WebRequest.Create(this.GetUrl()) as HttpWebRequest;
            request.Method = this.RequestInfo.Method;
            if (!string.IsNullOrWhiteSpace(this.RequestInfo.ContentType)) request.ContentType = this.RequestInfo.ContentType;
            foreach (var pair in this.RequestInfo.Headers) request.Headers.Add(pair.Key, pair.Value);
            if (string.IsNullOrWhiteSpace(this.RequestInfo.Body)) return request;
            byte[] byteArray = Encoding.UTF8.GetBytes(this.RequestInfo.Body);
            using (Stream reqStream = request.GetRequestStream())
            {
                reqStream.Write(byteArray, 0, byteArray.Length);
            }
            return request;
        }
        private void CheckRequestInfo()
        {
            AssertUtil.NotNull(this.RequestInfo, "未设置有效的请求信息");
            AssertUtil.IsTrue(!string.IsNullOrWhiteSpace(this.RequestInfo.Url), "未识别的url");
            AssertUtil.IsTrue(!string.IsNullOrWhiteSpace(this.RequestInfo.Method), "未识别的请求Method");
        }
        private string GetUrl()
        {
            var url = this.RequestInfo.Url.Replace(@"\", @"/");
            var strBuilder = url.StartsWith(@"http://") ?
                            new StringBuilder() :
                            new StringBuilder(@"http://");
            strBuilder.Append(url);
            if (EmptyUtil.IsNullOrEmpty(this.RequestInfo.Params)) return strBuilder.ToString();
            strBuilder.Append("?");
            for (int i = 0; i < this.RequestInfo.Params.Count; i++)
            {
                if (i != 0) strBuilder.Append("&");
                var element = this.RequestInfo.Params.ElementAt(i);
                strBuilder.Append(element.Key);
                strBuilder.Append("=");
                strBuilder.Append(element.Value);
            }
            return strBuilder.ToString();
        }
        private T GetResult<T>(HttpWebResponse resp) =>
            (T)new DataContractJsonSerializer(
                typeof(T),
                new DataContractJsonSerializerSettings
                {
                    DateTimeFormat = new DateTimeFormat("yyyy-MM-dd HH:mm:ss")
                })
            .ReadObject(resp.GetResponseStream());
    }

    class HttpRequestInfo
    {
        public string Url { get; set; }
        public string Method { get; set; }
        public string ContentType { get; set; }
        public Dictionary<string, string> Headers { get; set; } = new Dictionary<string, string>();
        public Dictionary<string, object> Params { get; set; } = new Dictionary<string, object>();
        public string Body { get; set; }
    }
}
