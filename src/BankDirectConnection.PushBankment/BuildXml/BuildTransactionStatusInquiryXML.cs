using BankDirectConnection.Domain.BOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankDirectConnection.PushBankment.BuildXml
{
    /*===============================================================================================================================
	*	Create by Fancy at 2017/12/25 21:02:54
	===============================================================================================================================*/
    /// <summary>
    /// 构建交易状态查询xml
    /// </summary>
    public class BuildTransactionStatusInquiryXML
    {
        public static string BuildXMLForTransactionStatusInquiryByLinq(TransactionStatusInquiryMsg TransactionStatusInquiryMsg)
        {
            XDocument xdocment = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("bocb2e",
               new XAttribute("version", "100"),
               new XAttribute("security", "true"),
               new XAttribute("lang", "chs"),
               BuildCommonXML.BuildHeadElement(TransactionStatusInquiryMsg.HeaderMessage),
               new XElement("trans",
                   new XElement("trn-b2e0007-rq",
                       new XElement("b2e0007-rq",
                           new XElement("insid", TransactionStatusInquiryMsg.Trans.Insid),
                           new XElement("obssid", TransactionStatusInquiryMsg.Trans.Obssid))))));
            return xdocment.Declaration + xdocment.ToString();
        }
    }
}
