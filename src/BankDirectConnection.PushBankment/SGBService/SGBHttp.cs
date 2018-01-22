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

        private static string GetTestForeignResult()
        {
            return "<ap><CCTransCode>SGT001</CCTransCode><ReqSeqNo>2b35cb176aed4b4fabf332de889949d1</ReqSeqNo><RespSource>ERP</RespSource><RespSeqNo>ERP40075325</RespSeqNo><HostSeqNo>364232</HostSeqNo><RespDate>20180118</RespDate><RespTime>142825876</RespTime><RespCode>0005</RespCode><RespInfo>交易待审核</RespInfo><RxtInfo>交易待审核</RxtInfo><FileFlag></FileFlag><Cme><RecordNum></RecordNum><FieldNum></FieldNum><RespPrvData></RespPrvData><BatchFileName></BatchFileName></Cme></ap>";
        }

        private static string GetTestInnerResult()
        {
            return "<ap><CCTransCode>SGT001</CCTransCode><ReqSeqNo>2b35cb176aed4b4fabf332de889949d1</ReqSeqNo><RespSource>ERP</RespSource><RespSeqNo>ERP40075325</RespSeqNo><HostSeqNo>364232</HostSeqNo><RespDate>20180118</RespDate><RespTime>142825876</RespTime><RespCode>0005</RespCode><RespInfo>交易待审核</RespInfo><RxtInfo>交易待审核</RxtInfo><FileFlag></FileFlag><Cme><RecordNum></RecordNum><FieldNum></FieldNum><RespPrvData></RespPrvData><BatchFileName></BatchFileName></Cme></ap>";
        }
        private static string GetTestRMBResult()
        {
            return "<ap><CCTransCode>SGT002</CCTransCode><ReqSeqNo>2b54fcb176aed4b4fabf332de889949d1</ReqSeqNo><RespSource>ERP</RespSource><RespSeqNo>ERP40075328</RespSeqNo><HostSeqNo>364233</HostSeqNo><RespDate>20180118</RespDate><RespTime>144015134</RespTime><RespCode>0005</RespCode><RespInfo>交易成功</RespInfo><RxtInfo>交易待审核</RxtInfo><FileFlag/><Cme><RecordNum/><FieldNum/><RespPrvData/><BatchFileName/></Cme></ap>";
        }

        public static string PostRequest(string RequestXML)
        {
            return GetTestForeignResult();
           // return BaseHttpClient.PostRequest(BaseUrl, RequestXML);
        }
    }
}
