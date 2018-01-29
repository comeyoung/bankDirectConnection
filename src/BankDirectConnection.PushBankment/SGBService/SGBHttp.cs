using BankDirectConnection.PushBankment.Http;
using MagicBox.Log;
using System;
using System.Collections.Generic;
using System.Configuration;
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
        public static string BaseUrl = ConfigurationManager.AppSettings["SGBUrl"];

        private static string GetTestForeignResult()
        {
            return "<ap><CCTransCode>SGT003</CCTransCode><ReqSeqNo>2b35cb176aed4b4fabf332de889949d1</ReqSeqNo><RespSource>ERP</RespSource><RespSeqNo>ERP40075325</RespSeqNo><HostSeqNo>364232</HostSeqNo><RespDate>20180118</RespDate><RespTime>142825876</RespTime><RespCode>0005</RespCode><RespInfo>交易待审核</RespInfo><RxtInfo>交易待审核</RxtInfo><FileFlag></FileFlag><Cme><RecordNum></RecordNum><FieldNum></FieldNum><RespPrvData></RespPrvData><BatchFileName></BatchFileName></Cme></ap>";
        }

        private static string GetTestInnerResult()
        {
            return "<ap><CCTransCode>SGT001</CCTransCode><ReqSeqNo>2b35cb176aed4b4fabf332de889949d1</ReqSeqNo><RespSource>ERP</RespSource><RespSeqNo>ERP40075325</RespSeqNo><HostSeqNo>364232</HostSeqNo><RespDate>20180118</RespDate><RespTime>142825876</RespTime><RespCode>0005</RespCode><RespInfo>交易待审核</RespInfo><RxtInfo>交易待审核</RxtInfo><FileFlag></FileFlag><Cme><RecordNum></RecordNum><FieldNum></FieldNum><RespPrvData></RespPrvData><BatchFileName></BatchFileName></Cme></ap>";
        }
        private static string GetTestRMBResult()
        {
            return "<ap><CCTransCode>SGT002</CCTransCode><ReqSeqNo>2b54fcb176aed4b4fabf332de889949d1</ReqSeqNo><RespSource>ERP</RespSource><RespSeqNo>ERP40075328</RespSeqNo><HostSeqNo>364233</HostSeqNo><RespDate>20180118</RespDate><RespTime>144015134</RespTime><RespCode>0005</RespCode><RespInfo>交易成功</RespInfo><RxtInfo>交易待审核</RxtInfo><FileFlag/><Cme><RecordNum/><FieldNum/><RespPrvData/><BatchFileName/></Cme></ap>";
        }
        private static string GetTestQueryStatusResult()
        {
            return "<ap><CCTransCode>SGQ010</CCTransCode><ReqSeqNo>1801280217111417180</ReqSeqNo><RespSource>ERP</RespSource><RespSeqNo>ERP40075328</RespSeqNo><HostSeqNo>364233</HostSeqNo><RespDate>20180118</RespDate><RespTime>144015134</RespTime><RespCode>0005</RespCode><RespInfo>交易成功</RespInfo><RxtInfo>交易待审核</RxtInfo><FileFlag/><Cmp><CmeSeqNo>1801280217111417180</CmeSeqNo><JnlState>0000</JnlState><Postscript>交易成功</Postscript><RespSeqNo>3102</RespSeqNo><HostSeqNo>3021302166667777</HostSeqNo><CertSeqNo>7111377021677</CertSeqNo></Cmp></ap>";
        }
        public static string PostRequest(string RequestXML)
        {
            /*===================================生产环境=======================================*/
            Logger.Writer("push to SG:" + RequestXML);
            var rt = BaseHttpClient.PostRequest(BaseUrl, RequestXML);
            Logger.Writer("receip from SG:" + rt);
            return rt;
            //return GetTestQueryStatusResult();
            /*===================================生产环境=======================================*/
        }
    }
}
