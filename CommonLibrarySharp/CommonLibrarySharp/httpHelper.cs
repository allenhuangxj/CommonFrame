using CommonLibrarySharp.WriteLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace CommonLibrarySharp.http
{
    public class httpHelper
    {
        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {  // 总是接受  
            return true;
        }

        /// <summary>
        /// 直接通过 url 去 GET/POST 请求数据(参数也都携带在url后面)
        /// </summary>
        /// <param name="url"></param>
        /// <param name="strPostType"></param>
        /// <returns></returns>
        public static string CommonUrl(string url, string strPostType)
        {
            string result = "";
            try
            {
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    // 设置协议类型。
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                }

                HttpWebRequest wbRequest = (HttpWebRequest)WebRequest.Create(url);
                wbRequest.Timeout = 15 * 1000;                      //10秒超时
                wbRequest.Method = strPostType;
                HttpWebResponse wbResponse = (HttpWebResponse)wbRequest.GetResponse();
                using (Stream responseStream = wbResponse.GetResponseStream())
                {
                    using (StreamReader sReader = new StreamReader(responseStream))
                    {
                        result = sReader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteMessage("CommonUrl 捕获到异常:" + ex.Message, true);
            }
            return result;
        }

        // POST提交表单数据
        public static string HttpPostFormData(string url, Dictionary<string, string> parameters = null)
        {
            string result = string.Empty;
            try
            {
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    // 设置协议类型。
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                }

                Log.WriteMessage("HttpPostFormData 请求url为:" + url);

                Encoding code = Encoding.GetEncoding("utf-8");
                HttpWebRequest wbRequest = (HttpWebRequest)WebRequest.Create(url);
                wbRequest.Timeout = 15 * 1000;                      //15秒超时
                wbRequest.Method = "POST";
                wbRequest.ContentType = "application/x-www-form-urlencoded";

                StringBuilder buffer = new StringBuilder();

                if (parameters != null && parameters.Count > 0)
                {
                    int i = 0;
                    foreach (string key in parameters.Keys)
                    {
                        if (i > 0)
                        {
                            buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                        }
                        else
                        {
                            buffer.AppendFormat("{0}={1}", key, parameters[key]);
                        }
                        i++;
                    }
                }

                string strParam = buffer.ToString();
                Log.WriteMessage("HttpPost 请求参数为:");
                Log.WriteMessage(strParam);

                if (!string.IsNullOrEmpty(buffer.ToString()))
                {
                    byte[] postData = code.GetBytes(buffer.ToString());
                    Stream reqStream = wbRequest.GetRequestStream();
                    reqStream.Write(postData, 0, postData.Length);
                    reqStream.Close();
                }

                HttpWebResponse wbResponse = (HttpWebResponse)wbRequest.GetResponse();
                using (Stream responseStream = wbResponse.GetResponseStream())
                {
                    using (StreamReader sread = new StreamReader(responseStream))
                    {
                        result = sread.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteMessage("HttpPost 捕获到异常:" + ex.Message, true);
            }
            return result;
        }

        // 提交json数据

        public static string HttpPostJsonData(string requestURL, string json)
        {
            try
            {
                Log.WriteMessage("HttpPostJsonData 请求url为:" + requestURL);

                if (string.IsNullOrEmpty(requestURL))
                {
                    Log.WriteMessage("HttpPostJsonData, empty URL!", true);
                    return "";
                }

                if (string.IsNullOrEmpty(json))
                {
                    Log.WriteMessage("HttpPostJsonData, empty json!", true);
                    return "";
                }

                //json格式请求数据
                string requestData = json;
                Log.WriteMessage("HttpPostJsonData 请求的json数据为:");
                Log.WriteMessage(requestData);
                //拼接URL
                string serviceUrl = requestURL;

                if (serviceUrl.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    // 设置协议类型。
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | (SecurityProtocolType)768 | (SecurityProtocolType)3072;
                }

                HttpWebRequest myRequest = (HttpWebRequest)WebRequest.Create(serviceUrl);
                //utf-8编码
                byte[] buf = Encoding.GetEncoding("UTF-8").GetBytes(requestData);

                //请求头相关
                myRequest.Method = "POST";
                myRequest.ContentLength = buf.Length;
                myRequest.Timeout = 10 * 1000;                      //10秒超时
                myRequest.ContentType = "application/json";
                myRequest.AllowAutoRedirect = true;
                myRequest.KeepAlive = false;
                var proxy = WebRequest.DefaultWebProxy;
                if (proxy != null)
                {
                    myRequest.Proxy = proxy;
                }
                else
                {
                    myRequest.Proxy = null;                            //无代理
                }
                myRequest.ServicePoint.Expect100Continue = false;

                Stream newStream = myRequest.GetRequestStream();
                newStream.Write(buf, 0, buf.Length);
                newStream.Flush();
                newStream.Close();

                //获得接口返回值
                HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                string ReqResult = reader.ReadToEnd();
                reader.Close();
                myResponse.Close();
                if (myRequest != null)
                {
                    myRequest = null;
                }

                return ReqResult;
            }
            catch (Exception ex)
            {
                Log.WriteMessage("HttpPostJsonData 捕获到异常:" + ex.Message, true);
                Log.WriteMessage("requestURL:" + requestURL, true);
                Log.WriteMessage("json:" + json, true);
            }

            return "";
        }
    }
}
