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
	*	Create by Fancy at 2017/12/24 14:28:56
	===============================================================================================================================*/
    public class BuildSignOutXML
    {
        public static string BuildXMLStrForSignOut(SignOutMsg SignOutMsg)
        {
            XmlDocument temp = new XmlDocument();
            temp.Load(AppDomain.CurrentDomain.BaseDirectory + "\\XMLTemplate\\SignOut.xml");
            var HeaderNodeString = temp.SelectSingleNode("//head").OuterXml;
            temp.SelectSingleNode("//head").RemoveAll();
            var header = new XmlDocument();
            header.LoadXml(HeaderNodeString);
            header.SelectSingleNode("//termid").InnerText = SignOutMsg.HeaderMessage.Termid;
            header.SelectSingleNode("//trnid").InnerText = SignOutMsg.HeaderMessage.Trnid;
            header.SelectSingleNode("//custid").InnerText = SignOutMsg.HeaderMessage.Custid;
            header.SelectSingleNode("//cusopr").InnerText = SignOutMsg.HeaderMessage.Cusopr;
            header.SelectSingleNode("//trncod").InnerText = SignOutMsg.HeaderMessage.Trncod;
            header.SelectSingleNode("//token").InnerText = SignOutMsg.HeaderMessage.Token;
            var NewHeaderNode = temp.SelectSingleNode("//bocb2e").OwnerDocument.ImportNode(header.LastChild, true);
            temp.SelectSingleNode("//head").AppendChild(NewHeaderNode);

            var TransNodeString = temp.SelectSingleNode("//trans").OuterXml;
            temp.SelectSingleNode("//b2e0002-rq").RemoveAll();
            var trans = new XmlDocument();
            trans.LoadXml(TransNodeString);
            trans.SelectSingleNode("//custdt").InnerText = SignOutMsg.Trans.Custdt;
            var NewTransNode = temp.SelectSingleNode("//bocb2e").OwnerDocument.ImportNode(header.LastChild, true);
            temp.SelectSingleNode("//b2e0002-rq").AppendChild(NewTransNode);
            return temp.OuterXml;
        }

        public static string BuildXMLStrForSignOutByLinq(SignOutMsg SignOutMsg)
        {
            XDocument xdocment = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("bocb2e",
                new XAttribute("version", "100"),
                new XAttribute("security", "true"),
                new XAttribute("lang", "chs"),
                new XElement("head",
                 new XElement("termid", SignOutMsg.HeaderMessage.Termid),
                 new XElement("trnid", SignOutMsg.HeaderMessage.Trnid),
                 new XElement("custid", SignOutMsg.HeaderMessage.Custid),
                 new XElement("cusopr", SignOutMsg.HeaderMessage.Cusopr),
                 new XElement("trncod", SignOutMsg.HeaderMessage.Trncod)),
                new XElement("trans",
                    new XElement("trn-b2e0002-rq",
                        new XElement("b2e0002-rq",
                            new XElement("custdt", SignOutMsg.Trans.Custdt))))));
            return xdocment.Declaration + xdocment.ToString();
        }
    }
}
