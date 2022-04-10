using CommonLibrarySharp.WriteLog;
using System;
using System.Collections.Generic;

namespace CommonLibrarySharp.Web
{
    public class MyWebService
    {
        public static string RequestWebService(string strUrl, string strMethod, List<WebServiceClient.Parameter> lstParameters)
        {
            string strRes = "";
            try
            {
                WebServiceClient client = new WebServiceClient
                {
                    WebMethod = strMethod,
                    Url = strUrl,
                    WSServiceType = WebServiceClient.ServiceType.Traditional,
                    Parameters = lstParameters
                };

                for (int i = 0; i < lstParameters.Count; i++)
                {
                    Log.WriteMessage(string.Format("请求参数:{0}, 对应的值为:{1}", lstParameters[i].Name, lstParameters[i].Value));
                }

                strRes = client.InvokeService();
            }
            catch (Exception ex)
            {
                Log.WriteMessage(string.Format("RequestWebService 捕获到异常:{0}", ex.Message.ToString()), true);
            }

            return strRes;
        }

        public static string RequestWcf(string strUrl, string strMethod, List<WebServiceClient.Parameter> lstParameters, string strContractName)
        {
            string strRes = "";
            try
            {
                WebServiceClient client = new WebServiceClient
                {
                    WebMethod = strMethod,
                    Url = strUrl,
                    // 如果是WCF接口 则使用下面
                    WSServiceType = WebServiceClient.ServiceType.WCF,
                    WCFContractName = strContractName,
                    Parameters = lstParameters
                };

                for (int i = 0; i < lstParameters.Count; i++)
                {
                    Log.WriteMessage(string.Format("请求参数:{0}, 对应的值为:{1}", lstParameters[i].Name, lstParameters[i].Value));
                }

                strRes = client.InvokeService();
            }
            catch (Exception ex)
            {
                Log.WriteMessage(string.Format("RequestWebService 捕获到异常:{0}", ex.Message.ToString()), true);
            }

            return strRes;
        }
    }
}
