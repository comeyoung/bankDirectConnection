using BankDirectConnection.PushBankment.Http;
using MagicBox.Log;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public static string BaseUrl = ConfigurationManager.AppSettings["BOCUrl"];
      
        private static string GetPaymentsToPublicResult()
        {
            //return "<?xml version='1.0' encoding='UTF - 8'?><bocb2e version='120' locale='zh_CN'> <head> <termid>E163083136140</termid>  <custid>133812368</custid>  <cusopr>136140253</cusopr>  <trncod>b2e0009</trncod>  <token>1Yk532BscUL1HJB-vhG_yv3</token> </head>  <trans> <trn-b2e0009-rs> <status> <rspcod>B001</rspcod>  <rspmsg>ok</rspmsg> </status>  <serverdt>20180122164146</serverdt>  <token>1Yk532BscUL1HJB-vhG_yv3</token> </trn-b2e0009-rs> </trans> </bocb2e>";
              return "<?xml version='1.0' encoding='UTF - 8'?><bocb2e version='120' locale='zh_CN'><head><termid>E163083136140</termid><custid>133812368</custid><cusopr>136140253</cusopr><trncod>b2e0009</trncod><token>1Yk532BscUL1HJB-vhG_yv3</token></head><trans><trn-b2e0009-rs><status><rspcod>B001</rspcod><rspmsg>ok</rspmsg></status><b2e0009-rs><status><rspcod>B001</rspcod><rspmsg>ok</rspmsg></status><insid>1801260116980984136</insid><obssid>dasfadf4984</obssid></b2e0009-rs><serverdt>20180122164146</serverdt><token>1Yk532BscUL1HJB-vhG_yv3</token></trn-b2e0009-rs></trans></bocb2e>";
        }

        private static string GetWageAndReimbursementResult()
        {
            //return "<?xml version='1.0' encoding='UTF - 8'?><bocb2e version='120' locale='zh_CN'> <head> <termid>E163083136140</termid>  <custid>133812368</custid>  <cusopr>136140253</cusopr>  <trncod>b2e0078</trncod>  <token>1Yk532BscUL1HJB-vhG_yv3</token> </head>  <trans> <trn-b2e0078-rs> <status> <rspcod>B001</rspcod>  <rspmsg>ok</rspmsg> </status>  <serverdt>20180122164146</serverdt>  <token>1Yk532BscUL1HJB-vhG_yv3</token> </trn-b2e0078-rs> </trans> </bocb2e>";
            return "<bocb2e version='120' locale='zh_CN'> <trn-b2e0078-rs><status><rspcod>B001</rspcod><rspmsg>交易成功</rspmsg></status><b2e0078-rs><status><rspcod>B001</rspcod><rspmsg>交易成功</rspmsg></status><insid>CD111666</insid><obssid>95961qwerd8494d1asdsd</obssid></b2e0078-rs></trn-b2e0078-rs></bocb2e>";
        }
        //private static string GetTransactionStatusInquiryResult()
        //{
        //    return "<ap><CCTransCode>SGT002</CCTransCode><ReqSeqNo>2b54fcb176aed4b4fabf332de889949d1</ReqSeqNo><RespSource>ERP</RespSource><RespSeqNo>ERP40075328</RespSeqNo><HostSeqNo>364233</HostSeqNo><RespDate>20180118</RespDate><RespTime>144015134</RespTime><RespCode>0005</RespCode><RespInfo>交易成功</RespInfo><RxtInfo>交易待审核</RxtInfo><FileFlag/><Cme><RecordNum/><FieldNum/><RespPrvData/><BatchFileName/></Cme></ap>";
        //}
        public static string PostRequest(string RequestXML)
        {
            /*===================================生产环境=======================================*/
            Logger.Writer("push to SG:" + RequestXML);
            var rt = BaseHttpClient.PostRequest(BaseUrl, RequestXML);
            Logger.Writer("receipt from SG:" + rt);
            return rt;
            /*===================================生产环境=======================================*/
        }

    }
}
