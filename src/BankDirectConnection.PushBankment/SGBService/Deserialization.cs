using BankDirectConnection.Domain.SGB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankDirectConnection.PushBankment.SGBService
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 16:22:05
	===============================================================================================================================*/
    public class Deserialization
    {
        public static CommonResponseMsg PaseResonseMsg(string ResponseMsg)
        {
            CommonResponseMsg responseMsg = new CommonResponseMsg();
            XDocument xDoc = XDocument.Parse(ResponseMsg);
            var xElement = xDoc.Descendants("ap");
            foreach(var item in xElement)
            {
                responseMsg.CCTransCode = item.Element("CCTransCode").Value;
                responseMsg.ReqSeqNo = item.Element("ReqSeqNo").Value;
                responseMsg.RespSource = item.Element("RespSource").Value;
                responseMsg.RespSeqNo = item.Element("RespSeqNo").Value;
                responseMsg.HostSeqNo = item.Element("HostSeqNo").Value;
                responseMsg.RespDate = item.Element("RespDate").Value;
                responseMsg.RespTime = item.Element("RespTime").Value;
                responseMsg.RespCode = item.Element("RespCode").Value;
                responseMsg.RespInfo = item.Element("RespInfo").Value;
                responseMsg.RxtInfo = item.Element("RxtInfo").Value;
                responseMsg.FileFlag = item.Element("FileFlag").Value;
            }
            var query = xElement.Descendants("Cme");
            foreach(var item in query)
            {
                responseMsg.CmeMsgs.Add(new CmeMsg() {
                    RecordNum = item.Element("RecordNum").Value,
                    FieldNum = item.Element("FieldNum").Value,
                    RespPrvData = item.Element("RespPrvData").Value,
                    BatchFileName = item.Element("BatchFileName").Value
                });
            }

            return responseMsg;
        }
    }
}
