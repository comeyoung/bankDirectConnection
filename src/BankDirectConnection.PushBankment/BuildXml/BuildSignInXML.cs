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
	*	Create by Fancy at 2017/12/24 14:28:39
	===============================================================================================================================*/
    public class BuildSignInXML
    {
        public static string BuildXMLStrForSignIn(SignInMsg SignInMsg)
        {
            XmlDocument temp = new XmlDocument();
            temp.Load(AppDomain.CurrentDomain.BaseDirectory + "\\XMLTemplate\\SignIn.xml");
            var HeaderNodeString = temp.SelectSingleNode("//head").OuterXml;
            temp.SelectSingleNode("//head").RemoveAll();
            var header = new XmlDocument();
            header.LoadXml(HeaderNodeString);
            header.SelectSingleNode("//termid").InnerText = SignInMsg.HeaderMessage.Termid;
            header.SelectSingleNode("//trnid").InnerText = SignInMsg.HeaderMessage.Trnid;
            header.SelectSingleNode("//custid").InnerText = SignInMsg.HeaderMessage.Custid;
            header.SelectSingleNode("//cusopr").InnerText = SignInMsg.HeaderMessage.Cusopr;
            header.SelectSingleNode("//trncod").InnerText = SignInMsg.HeaderMessage.Trncod;
            var NewHeaderNode = temp.SelectSingleNode("//bocb2e").OwnerDocument.ImportNode(header.LastChild, true);
            temp.SelectSingleNode("//head").AppendChild(NewHeaderNode);

            var TransNodeString = temp.SelectSingleNode("//trans").OuterXml;
            temp.SelectSingleNode("//b2e0001-rq").RemoveAll();
            var trans = new XmlDocument();
            trans.LoadXml(TransNodeString);
            trans.SelectSingleNode("//custdt").InnerText = SignInMsg.Trans.Custdt;
            trans.SelectSingleNode("//oprpwd").InnerText = SignInMsg.Trans.Oprpwd;
            trans.SelectSingleNode("//ceitinfo").InnerText = SignInMsg.Trans.Ceitinfo;
            var NewTransNode = temp.SelectSingleNode("//bocb2e").OwnerDocument.ImportNode(header.LastChild, true);
            temp.SelectSingleNode("//b2e0001-rq").AppendChild(NewTransNode);
            return temp.OuterXml;
        }

        public static string BuildXMLStrForSignInByLinq(SignInMsg SignInMsg)
        {
            XDocument xdocment = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("bocb2e",
                new XAttribute("version", "100"),
                new XAttribute("security", "true"),
                new XAttribute("lang", "chs"),
                BuildCommonXML.BuildSignInHeadElement(SignInMsg.HeaderMessage),
                new XElement("trans",
                    new XElement("trn-b2e0001-rq",
                        new XElement("b2e0001-rq",
                            new XElement("custdt", SignInMsg.Trans.Custdt),
                            new XElement("oprpwd", SignInMsg.Trans.Oprpwd),
                            new XElement("ceitinfo", SignInMsg.Trans.Ceitinfo))))));
            return xdocment.Declaration + xdocment.ToString();
        }
    }
}
