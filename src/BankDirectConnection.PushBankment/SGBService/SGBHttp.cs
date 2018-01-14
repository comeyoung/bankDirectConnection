using BankDirectConnection.PushBankment.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.PushBankment.SGBService
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/11 13:34:39
	===============================================================================================================================*/
    public class SGBHttp
    {
        //T4测试环境专线 http://10.16.253.167:9082/B2EP/XmlServlet
        //T4测试环境公网 http://180.168.146.79:81/B2EP/XmlServlet
        public static string BaseUrl = "http://180.168.146.79:81/B2EP/XmlServlet";

        //public  static string PostRequest(string RequestXML)
        //{
        //    HttpContent httpContent = new StringContent(RequestXML, Encoding.UTF8, "application/xml");
        //    var handler = new HttpClientHandler() { AutomaticDecompression = DecompressionMethods.GZip };
        //    string result;
        //    using (var http = new HttpClient(handler))
        //    {
        //        // http.BaseAddress = new Uri(@BaseUrl);
        //        string url = BaseUrl;
        //        var response = http.PostAsync(url, httpContent).Result;
        //        response.EnsureSuccessStatusCode();
        //        result = response.Content.ReadAsStringAsync().Result;
        //    }
        //    return result;
        //}

        public static string PostRequest(string RequestXML)
        {
            return BaseHttpClient.PostRequest(BaseUrl, RequestXML);
        }
    }
}
