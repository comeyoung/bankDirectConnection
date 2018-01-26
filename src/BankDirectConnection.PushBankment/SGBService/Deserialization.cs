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
        public static CommonResponseMsg ParseResonseMsg(string ResponseMsg)
        {
            CommonResponseMsg responseMsg = new CommonResponseMsg();
            XDocument xDoc = XDocument.Parse(ResponseMsg);
            var xElement = xDoc.Descendants("ap");
            foreach (var item in xElement)
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
            foreach (var item in query)
            {
                responseMsg.CmeMsgs.Add(new CmeMsg()
                {
                    RecordNum = item.Element("RecordNum").Value,
                    FieldNum = item.Element("FieldNum").Value,
                    RespPrvData = item.Element("RespPrvData").Value,
                    BatchFileName = item.Element("BatchFileName").Value
                });
            }

            return responseMsg;
        }

        public static BatchTransResponse ParseBatchTransResponse(string ResponseMsg)
        {
            BatchTransResponse batchResponse = new BatchTransResponse();
            CommonResponseMsg responseMsg = new CommonResponseMsg();
            XDocument xDoc = XDocument.Parse(ResponseMsg);
            var xElement = xDoc.Descendants("ap");
            foreach (var item in xElement)
            {
                batchResponse.CCTransCode = item.Element("CCTransCode").Value;
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
            var queryCme = xElement.Descendants("Cme");
            var queryCmp = xElement.Descendants("Cmp");
            foreach (var item in queryCme)
            {
                responseMsg.CmeMsgs.Add(new CmeMsg()
                {
                    RecordNum = item.Element("RecordNum").Value,
                    FieldNum = item.Element("FieldNum").Value,
                    RespPrvData = item.Element("RespPrvData").Value,
                    BatchFileName = item.Element("BatchFileName").Value
                });
            }
            batchResponse.CommonResponse = responseMsg;
            foreach (var item in queryCmp)
            {
                batchResponse.CmpMsg.CmeSeqNo = item.Element("CmeSeqNo").Value;
                batchResponse.CmpMsg.JnlState = item.Element("JnlState").Value;
                batchResponse.CmpMsg.Postscript = item.Element("Postscript").Value;
                batchResponse.CmpMsg.RespSeqNo = item.Element("RespSeqNo").Value;
                batchResponse.CmpMsg.HostSeqNo = item.Element("HostSeqNo").Value;
                var cmpList = queryCmp.Descendants("List");
                foreach (var listItem in cmpList)
                {
                    batchResponse.CmpMsg.ListMsg.Add(new ListMsg()
                    {
                        ParentJnlno = listItem.Element("ParentJnlno").Value,
                        CertSeqNo = listItem.Element("CertSeqNo").Value,
                        JnlNo = listItem.Element("JnlNo").Value,
                        JnlState = listItem.Element("JnlState").Value,
                        Postscript = listItem.Element("Postscript").Value,
                        ReturnMsg = listItem.Element("ReturnMsg").Value
                    });
                }
            }
            return batchResponse;
        }

        public static QueryTransactionResultsResponse ParseTransactionResultsResonseMsg(string ResponseMsg)
        {
            QueryTransactionResultsResponse responseMsg = new QueryTransactionResultsResponse();
            XDocument xDoc = XDocument.Parse(ResponseMsg);
            var xElement = xDoc.Descendants("ap");
            responseMsg.Head.AuthNo = GetElementValue(xElement.Elements("CCTransCode").FirstOrDefault());
            var query = xElement.Descendants("Cmp");
            responseMsg.Trans.CmeSeqNo = GetElementValue(query.FirstOrDefault().Element("CmeSeqNo"));
            responseMsg.Trans.CertSeqNo = GetElementValue(query.FirstOrDefault().Element("CertSeqNo"));
            responseMsg.Trans.HostSeqNo = GetElementValue(query.FirstOrDefault().Element("HostSeqNo"));
            responseMsg.Trans.JnlState = GetElementValue(query.FirstOrDefault().Element("JnlState"));
            responseMsg.Trans.Postscript = GetElementValue(query.FirstOrDefault().Element("Postscript"));
            responseMsg.Trans.RespSeqNo = GetElementValue(query.FirstOrDefault().Element("RespSeqNo"));
            return responseMsg;
        }

        public static string GetElementValue(XElement element)
        {
            if (null == element) return string.Empty;
            return element.Value;
        }
    }

}




