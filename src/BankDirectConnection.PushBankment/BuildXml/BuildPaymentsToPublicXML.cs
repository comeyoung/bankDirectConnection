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
	*	Create by Fancy at 2017/12/25 20:17:11
	===============================================================================================================================*/
    public class BuildPaymentsToPublicXML
    {
        public static string BuildXMLForPaymentsToPublic(PaymentsToPublicMsg Message)
        {
            XmlDocument temp = new XmlDocument();
            temp.Load(AppDomain.CurrentDomain.BaseDirectory + "\\XMLTemplate\\SignIn.xml");
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
            temp.SelectSingleNode("//b2e0001-rq").RemoveAll();
            var trans = new XmlDocument();
            trans.LoadXml(TransNodeString);
            //trans.SelectSingleNode("//custdt").InnerText = Message.Trans.c;
            //trans.SelectSingleNode("//oprpwd").InnerText = Message.Trans.Idknum;
            // trans.SelectSingleNode("//ceitinfo").InnerText = SignInMsg.Trans.Ceitinfo;
            var NewTransNode = temp.SelectSingleNode("//bocb2e").OwnerDocument.ImportNode(header.LastChild, true);
            temp.SelectSingleNode("//b2e0001-rq").AppendChild(NewTransNode);
            return temp.OuterXml;
        }

        public static string BuildXMLForPaymentsToPublicByLinq(PaymentsToPublicMsg PaymentsToPublicMsg)
        {
            XDocument xdocment = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("bocb2e",
               new XAttribute("version", "100"),
               new XAttribute("security", "true"),
               new XAttribute("lang", "chs"),
               BuildCommonXML.BuildHeadElement(PaymentsToPublicMsg.HeaderMessage),
               new XElement("trans",
                   new XElement("trn-b2e0009-rq",
                       new XElement("b2e0009-rq",
                           BuildCommonXML.BuildFractnElement(PaymentsToPublicMsg.Trans.Fractn),
                           new XElement("toactn", new XElement("toibkn", PaymentsToPublicMsg.Trans.Toactn.ToiBkn),
                                                  new XElement("actacn", PaymentsToPublicMsg.Trans.Toactn.Actacn),
                                                  new XElement("toname", PaymentsToPublicMsg.Trans.Toactn.Toname),
                                                  new XElement("toaddr", PaymentsToPublicMsg.Trans.Toactn.Toaddr),
                                                  new XElement("tobknm", PaymentsToPublicMsg.Trans.Toactn.Tobknm)),
                           new XElement("insid", PaymentsToPublicMsg.Trans.Insid),
                           new XElement("obssid", PaymentsToPublicMsg.Trans.Obssid),
                           new XElement("trnamt", PaymentsToPublicMsg.Trans.Trnamt),
                           new XElement("trncur", PaymentsToPublicMsg.Trans.Trncur),
                           new XElement("priolv", PaymentsToPublicMsg.Trans.Priolv),
                           new XElement("furinfo", PaymentsToPublicMsg.Trans.Furinfo),
                           new XElement("trfdate", PaymentsToPublicMsg.Trans.TrfDate),
                           new XElement("trftime", PaymentsToPublicMsg.Trans.TrfTime),
                           new XElement("comacn", PaymentsToPublicMsg.Trans.Comacn))))));
            return xdocment.Declaration + xdocment.ToString();
        }
    }
}
