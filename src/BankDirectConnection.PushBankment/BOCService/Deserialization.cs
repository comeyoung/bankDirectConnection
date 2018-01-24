using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.BOC;
using BankDirectConnection.Domain.ExceptionMsg;
using System.Xml.Linq;

namespace BankDirectConnection.PushBankment.BOCService
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 15:22:10
	===============================================================================================================================*/
    public class Deserialization
    {
        /// <summary>
        /// 反序列化接口回传的xml
        /// </summary>
        /// <param name="ResponseMsg">调用接口回传的xml</param>
        /// <param name="BussinessType">业务类型</param>
        /// <returns></returns>
        public static ResponseMsg ParseResponseMsg(string ResponseMsg,string BussinessType)
        {
            ResponseMsg res = new ResponseMsg();
            if (string.IsNullOrEmpty(ResponseMsg))
                throw new BusinessException("null callback") { Code = "3011001" };
            if (string.IsNullOrEmpty(BussinessType))
                throw new BusinessException("bussinesstype is null") { Code = "3011002" };
            XDocument xDoc = XDocument.Parse(ResponseMsg);
            var xElement = xDoc.Descendants("trn-"+ BussinessType + "-rs");
            foreach(var item in xElement)
            {
                 res.Token = GetElementValue(item.Element("token"));             
                res.Serverdt = GetElementValue(item.Element("serverdt"));
            }

            var status = xElement.Elements("status");
            if(null != status)
            {
                foreach (var item in status)
                {
                    res.Status.RspCod = GetElementValue(item.Element("rspcod"));
                    res.Status.RspMsg = GetElementValue(item.Element("rspmsg"));
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
                        detailLine.Status.RspCod = GetElementValue(detailItem.Element("rspcod"));
                        detailLine.Status.RspMsg = GetElementValue(detailItem.Element("rspmsg"));
                    }
                    detailLine.Insid = GetElementValue(item.Element("insid"));
                    detailLine.Obssid = GetElementValue(item.Element("obssid"));
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
