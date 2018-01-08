using BankDirectConnection.Domain.BOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace BankDirectConnection.PushBankment.BuildXml
{
    /*===============================================================================================================================
	*	Create by Fancy at 2017/12/24 18:10:06
	===============================================================================================================================*/
    /// <summary>
    /// 构建余额查询xml
    /// </summary>
    public class BuildBalanceInquiryXML
    {
        public static string BuildXMLForBalanceInquiry(BalanceInquiryMsg Message)
        {
            XmlDocument temp = new XmlDocument();
            if(Message.Trans.BalanceType == emBalanceType.emCurrentDate)
            {
                // 构建当前余额查询xml
                temp.Load(AppDomain.CurrentDomain.BaseDirectory + "\\XMLTemplate\\CurrentBalanceInquiry.xml");
                var HeaderNodeString = temp.SelectSingleNode("//head").OuterXml;
                temp.SelectSingleNode("//head").RemoveAll();
                var header = new XmlDocument();
                header.LoadXml(HeaderNodeString);
                header.SelectSingleNode("//termid").InnerText = Message.HeaderMessage.Termid;
                header.SelectSingleNode("//trnid").InnerText = Message.HeaderMessage.Trnid;
                header.SelectSingleNode("//custid").InnerText = Message.HeaderMessage.Custid;
                header.SelectSingleNode("//cusopr").InnerText = Message.HeaderMessage.Cusopr;
                header.SelectSingleNode("//trncod").InnerText = Message.HeaderMessage.Trncod;
                var NewHeaderNode = temp.SelectSingleNode("//bocb2e").OwnerDocument.ImportNode(header.LastChild, true);
                temp.SelectSingleNode("//head").AppendChild(NewHeaderNode);

                var TransNodeString = temp.SelectSingleNode("//trans").OuterXml;
                temp.SelectSingleNode("//b2e0005-rq").RemoveAll();
                var trans = new XmlDocument();
                trans.LoadXml(TransNodeString);
                trans.SelectSingleNode("//custdt").InnerText = Message.Trans.Actacn;
                trans.SelectSingleNode("//oprpwd").InnerText = Message.Trans.Idknum;
                // trans.SelectSingleNode("//ceitinfo").InnerText = SignInMsg.Trans.Ceitinfo;
                var NewTransNode = temp.SelectSingleNode("//bocb2e").OwnerDocument.ImportNode(header.LastChild, true);
                temp.SelectSingleNode("//b2e0005-rq").AppendChild(NewTransNode);
                return temp.OuterXml;
            }
            else
            {
                temp.Load(AppDomain.CurrentDomain.BaseDirectory + "\\XMLTemplate\\HistoryBalanceInquir.xml");
                var HeaderNodeString = temp.SelectSingleNode("//head").OuterXml;
                temp.SelectSingleNode("//head").RemoveAll();
                var header = new XmlDocument();
                header.LoadXml(HeaderNodeString);
                header.SelectSingleNode("//termid").InnerText = Message.HeaderMessage.Termid;
                header.SelectSingleNode("//trnid").InnerText = Message.HeaderMessage.Trnid;
                header.SelectSingleNode("//custid").InnerText = Message.HeaderMessage.Custid;
                header.SelectSingleNode("//cusopr").InnerText = Message.HeaderMessage.Cusopr;
                header.SelectSingleNode("//trncod").InnerText = Message.HeaderMessage.Trncod;
                var NewHeaderNode = temp.SelectSingleNode("//bocb2e").OwnerDocument.ImportNode(header.LastChild, true);
                temp.SelectSingleNode("//head").AppendChild(NewHeaderNode);

                var TransNodeString = temp.SelectSingleNode("//trans").OuterXml;
                temp.SelectSingleNode("//b2e0012-rq").RemoveAll();
                var trans = new XmlDocument();
                trans.LoadXml(TransNodeString);
                trans.SelectSingleNode("//custdt").InnerText = Message.Trans.Actacn;
                trans.SelectSingleNode("//oprpwd").InnerText = Message.Trans.Idknum;
                // trans.SelectSingleNode("//ceitinfo").InnerText = SignInMsg.Trans.Ceitinfo;
                var NewTransNode = temp.SelectSingleNode("//bocb2e").OwnerDocument.ImportNode(header.LastChild, true);
                temp.SelectSingleNode("//b2e0012-rq").AppendChild(NewTransNode);
                return temp.OuterXml;
            }
           
        }

        public static string BuildXMLForBalanceInquiryByLinq(BalanceInquiryMsg BalanceInquiryMsg)
        {
            XDocument xdocment = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("bocb2e",
               new XAttribute("version", "100"),
               new XAttribute("security", "true"),
               new XAttribute("lang", "chs"),
               BuildCommonXML.BuildHeadElement(BalanceInquiryMsg.HeaderMessage),
               new XElement("trans",
                   new XElement("trn-b2e0005-rq",
                       new XElement("b2e0005-rq",
                           new XElement("account", BalanceInquiryMsg.Trans.Actacn,
                           new XElement("ibknum",BalanceInquiryMsg.Trans.Idknum),
                           new XElement("actacn", BalanceInquiryMsg.Trans.Actacn)))))));
            return xdocment.Declaration + xdocment.ToString();
        }
    }
}
