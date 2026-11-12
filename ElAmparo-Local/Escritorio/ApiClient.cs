using System;
using System.IO;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace el_amparo
{
    internal static class ApiClient
    {
        private static readonly JavaScriptSerializer Serializer = new JavaScriptSerializer();

        public static T Get<T>(string url)
        {
            string json = Request(url, "GET", null);
            return String.IsNullOrWhiteSpace(json) ? default(T) : Serializer.Deserialize<T>(json);
        }

        public static void Post(string url, object data)
        {
            Request(url, "POST", data);
        }

        public static void Put(string url, object data)
        {
            Request(url, "PUT", data);
        }

        private static string Request(string url, string method, object data)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = method;
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Proxy = null;
            request.UserAgent = "ElAmparo-Desktop";
            request.ContentType = "application/json; charset=utf-8";

            if (data != null)
            {
                byte[] body = Encoding.UTF8.GetBytes(Serializer.Serialize(data));
                request.ContentLength = body.Length;
                using (Stream stream = request.GetRequestStream())
                    stream.Write(body, 0, body.Length);
            }

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream stream = response.GetResponseStream())
            using (StreamReader reader = new StreamReader(stream))
                return HttpUtility.HtmlDecode(reader.ReadToEnd());
        }
    }
}
