using BankDirectConnection.Domain.BOC;
using BankDirectConnection.Domain.Exception;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankDirectConnection.PushBankment.BOCService
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 15:22:10
	===============================================================================================================================*/
    public class Deserialization
    {
        public static ResponseMsg ParseResponseMsg(string ResponseMsg,string BussinessType)
        {
            ResponseMsg res = new ResponseMsg();
            if (string.IsNullOrEmpty(ResponseMsg))
                throw new BusinessException("null callback") { Code = "10021" };
            if (string.IsNullOrEmpty(BussinessType))
                throw new BusinessException("inner code,bussinesstype is null") { Code = "20001" };
            XDocument xDoc = XDocument.Parse(ResponseMsg);
            var xElement = xDoc.Descendants("trn-"+ BussinessType + "-rs");
            foreach(var item in xElement)
            {
                res.token = GetElementValue(item.Element("token"));
                res.serverdt = GetElementValue(item.Element("serverdt"));
            }

            var status = xElement.Descendants("status");
            if(null != status)
            {
                foreach (var item in status)
                {
                    res.status.RspCod = GetElementValue(item.Element("rspcode"));
                    res.status.RspMsg = GetElementValue(item.Element("rspmsg"));
                }
            }
            var resDetail = xElement.Descendants(BussinessType + "-rs");
            if(null != resDetail)
            {
                foreach(var item in resDetail)
                {
                    DetailResponse detailLine = new DetailResponse();
                    var detailStatus = resDetail.Descendants("status");
                    foreach(var detailItem in detailStatus)
                    {
                        detailLine.status.RspCod = GetElementValue(detailItem.Element("rspcode"));
                        detailLine.status.RspMsg = GetElementValue(detailItem.Element("rspmsg"));
                    }
                    detailLine.insid = GetElementValue(item.Element("insid"));
                    detailLine.obssid = GetElementValue(item.Element("obssid"));
                    res.DetailResponses.Add(detailLine);
                }
            }
            return res;
        }

        public static string GetElementValue(XElement element)
        {
            if (null == element) return string.Empty;
            return element.Value;
        }
    }
}
