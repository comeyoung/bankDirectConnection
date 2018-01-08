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
	*	Create by Fancy at 2017/12/25 21:05:43
	===============================================================================================================================*/
    /// <summary>
    /// 构建工资 报销XML
    /// </summary>
    public class BuildWageAndReimbursementXML
    {
        public static string BuildXMLForWageAndReimbursementByLinq(WageAndReimbursementMsg WageAndReimbursementMsg)
        {
            XDocument xdocment = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("bocb2e",
               new XAttribute("version", "100"),
               new XAttribute("security", "true"),
               new XAttribute("lang", "chs"),
               BuildCommonXML.BuildHeadElement(WageAndReimbursementMsg.HeaderMessage),
               new XElement("trans",
                   new XElement("trn-b2e0078-rq",
                       new XElement("b2e0078-rq",
                           new XElement("insid", WageAndReimbursementMsg.Trans.Insid),
                           new XElement("telephone", WageAndReimbursementMsg.Trans.Telephone),
                           new XElement("pybcur", WageAndReimbursementMsg.Trans.Pybcur),
                           new XElement("pybamt", WageAndReimbursementMsg.Trans.Pybamt),
                           new XElement("pybnum", WageAndReimbursementMsg.Trans.Pybnum),
                           new XElement("crdtyp", WageAndReimbursementMsg.Trans.Crdtyp),
                           new XElement("furinfo", WageAndReimbursementMsg.Trans.Furinfo),
                           new XElement("useinf", WageAndReimbursementMsg.Trans.Useinf),
                           new XElement("trfdate", WageAndReimbursementMsg.Trans.Trfdate),
                           new XElement("detail", new XElement("toibkn", WageAndReimbursementMsg.Trans.DetailMessage.Toibkn),
                                                  new XElement("tobank", WageAndReimbursementMsg.Trans.DetailMessage.Tobank),
                                                  new XElement("toactn", WageAndReimbursementMsg.Trans.DetailMessage.Toactn),
                                                  new XElement("pydcur", WageAndReimbursementMsg.Trans.DetailMessage.Pydcur),
                                                  new XElement("pydamt", WageAndReimbursementMsg.Trans.DetailMessage.Pydamt),
                                                  new XElement("toname", WageAndReimbursementMsg.Trans.DetailMessage.Toidet),
                                                  new XElement("toidtp", WageAndReimbursementMsg.Trans.DetailMessage.Toidtp),
                                                  new XElement("toidet", WageAndReimbursementMsg.Trans.DetailMessage.Toidet),
                                                  new XElement("furinfo", WageAndReimbursementMsg.Trans.DetailMessage.Furinfo),
                                                  new XElement("purpose", WageAndReimbursementMsg.Trans.DetailMessage.Purpose),
                                                  new XElement("reserve1", WageAndReimbursementMsg.Trans.DetailMessage.Reserve1),
                                                  new XElement("reserve2", WageAndReimbursementMsg.Trans.DetailMessage.Reserve2),
                                                  new XElement("reserve3", WageAndReimbursementMsg.Trans.DetailMessage.Reserve3),
                                                  new XElement("reserve4", WageAndReimbursementMsg.Trans.DetailMessage.Reserve4)),
                          BuildCommonXML.BuildFractnElement(WageAndReimbursementMsg.Trans.FractnMessage))))));
            return xdocment.Declaration + xdocment.ToString();
        }
    }
}
