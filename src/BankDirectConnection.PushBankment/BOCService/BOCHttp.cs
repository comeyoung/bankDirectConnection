using BankDirectConnection.PushBankment.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.PushBankment.BOCService
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/11 9:53:39
	===============================================================================================================================*/
    public class BOCHttp
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
        private static string GetPaymentsToPublicResult()
        {
            return "<?xml version='1.0' encoding='UTF - 8'?><bocb2e version='120' locale='zh_CN'> <head> <termid>E163083136140</termid>  <custid>133812368</custid>  <cusopr>136140253</cusopr>  <trncod>b2e0001</trncod>  <token>1Yk532BscUL1HJB-vhG_yv3</token> </head>  <trans> <trn-b2e0001-rs> <status> <rspcod>B001</rspcod>  <rspmsg>ok</rspmsg> </status>  <serverdt>20180122164146</serverdt>  <token>1Yk532BscUL1HJB-vhG_yv3</token> </trn-b2e0001-rs> </trans> </bocb2e>";
        }

        private static string GetWageAndReimbursementResult()
        {
            return "<?xml version='1.0' encoding='utf - 8'?><bocb2e version='100' security='true' lang='chs'><head><termid>E163083136140</termid><trnid/><custid>133812368</custid><cusopr>136140253</cusopr><trncod>b2e0078</trncod><token>qgG6qc_GkLT8MSklp0krC_k</token></head><trans><trn-b2e0078-rq><b2e0078-rq><insid>0120180122165802001</insid><fractn><fribkn>40142</fribkn><actacn>327256085181</actacn><actnam/></fractn><pybcur>CNY</pybcur><pybamt>5000.00</pybamt><pybnum>1</pybnum><crdtyp>7</crdtyp><furinfo>EC</furinfo><useinf>EC</useinf><trfdate>20180122</trfdate><detail><toibkn>10</toibkn><tobank></tobank><toactn>327256085181</toactn><pydcur>CNY</pydcur><pydamt>5000.00</pydamt><toname>BOC</toname><toidtp></toidtp><toidet></toidet><furinfo></furinfo><purpose></purpose><reserve1></reserve1><reserve2></reserve2><reserve3></reserve3><reserve4></reserve4></detail></b2e0078-rq></trn-b2e0078-rq></trans></bocb2e>";
        }
        private static string GetTransactionStatusInquiryResult()
        {
            return "<ap><CCTransCode>SGT002</CCTransCode><ReqSeqNo>2b54fcb176aed4b4fabf332de889949d1</ReqSeqNo><RespSource>ERP</RespSource><RespSeqNo>ERP40075328</RespSeqNo><HostSeqNo>364233</HostSeqNo><RespDate>20180118</RespDate><RespTime>144015134</RespTime><RespCode>0005</RespCode><RespInfo>交易成功</RespInfo><RxtInfo>交易待审核</RxtInfo><FileFlag/><Cme><RecordNum/><FieldNum/><RespPrvData/><BatchFileName/></Cme></ap>";
        }
        public static string PostRequest(string RequestXML)
        {
            //return BaseHttpClient.PostRequest(BaseUrl, RequestXML);
            return GetPaymentsToPublicResult();
        }
    }
}
