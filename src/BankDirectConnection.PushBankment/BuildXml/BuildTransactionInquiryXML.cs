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
	*	Create by Fancy at 2017/12/25 20:28:53
	===============================================================================================================================*/
    /// <summary>
    /// 构建交易查询xml
    /// </summary>
    public class BuildTransactionInquiryXML
    {
        public static string BuildXMLForTransactionInquiryByLinq(TransactionInquiryMsg TransactionInquiryMsg)
        {
            XDocument xdocment = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("bocb2e",
               new XAttribute("version", "100"),
               new XAttribute("security", "true"),
               new XAttribute("lang", "chs"),
               BuildCommonXML.BuildHeadElement(TransactionInquiryMsg.HeaderMessage),
               new XElement("trans",
                   new XElement("trn-b2e0035-rq",
                       new XElement("b2e0035-rq",
                           new XElement("ibknum", TransactionInquiryMsg.Trans.Ibknum),
                           new XElement("actacn", TransactionInquiryMsg.Trans.Actacn),
                           new XElement("type", TransactionInquiryMsg.Trans.Type),
                           new XElement("begnum", TransactionInquiryMsg.Trans.Begnum),
                           new XElement("recnum", TransactionInquiryMsg.Trans.Recnum),
                           new XElement("direction", TransactionInquiryMsg.Trans.Direction),
                           new XElement("datescope", new XElement("from", TransactionInquiryMsg.Trans.DateScope.From),
                                                     new XElement("to", TransactionInquiryMsg.Trans.DateScope.To)),
                           new XElement("amountscope", new XElement("from", TransactionInquiryMsg.Trans.AmountScope.From),
                                                     new XElement("to", TransactionInquiryMsg.Trans.AmountScope.To)))))));
            return xdocment.Declaration + xdocment.ToString();
        }
    }
}
