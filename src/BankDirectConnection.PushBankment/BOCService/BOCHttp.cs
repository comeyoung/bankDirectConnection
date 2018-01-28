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
        private static string GetTransactionStatusInquiryResult()
        {
            return "<trn-b2e0007-rs><status><rspcod>B001</rspcod><rspmsg>交易成功</rspmsg></status><b2e0007-rs><rspcod>B001</rspcod><rspmsg>交易成功</rspmsg><insid>1801280117111417180</insid><obssid>2018369896</obssid><hostseqno>9651585584667</hostseqno></b2e0007-rs></trn-b2e0007-rs>";
        }
        public static string PostRequest(string RequestXML)
        {
            /*===================================生产环境=======================================*/
            //Logger.Writer("push to BOC:" + RequestXML);
            //var rt = BaseHttpClient.PostRequest(BaseUrl, RequestXML);
            //Logger.Writer("receipt from BOC:" + rt);
            //return rt;
            return GetWageAndReimbursementResult();
            /*===================================生产环境=======================================*/
        }

    }
}
