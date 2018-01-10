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
	*	Create by Fancy at 2018/1/10 16:22:16
	===============================================================================================================================*/
    public class Serialization
    {
        /// <summary>
        /// 人民币付款
        /// </summary>
        /// <param name="RMBPaymentMsgs"></param>
        /// <returns></returns>
        public static string BuildXMLForRMBPayment(List<RMBPaymentMsg> RMBPaymentMsgs)
        {
            XElement xdocment = new XElement("ap", new XElement("CCTransCode", "SGT001"),
                from item in RMBPaymentMsgs
                select new XElement("Cmp", new XElement("DbAccNo", item.DbAccNo),
                                           new XElement("DbAccName", item.DbAccName),
                                           new XElement("DbCur", item.DbCur),
                                           new XElement("CrAccNo", item.CrAccNo),
                                           new XElement("CrAccName", item.CrAccName),
                                           new XElement("CrCifType", item.CrCifType),
                                           new XElement("ForeignPayee", item.ForeignPayee),
                                           new XElement("UnionDeptId", item.UnionDeptId),
                                           new XElement("CrBankName", item.CrBankName),
                                           new XElement("CrCur", item.CrCur),
                                           new XElement("TransAmt", item.TransAmt),
                                           new XElement("WhyUse", item.WhyUse),
                                           new XElement("Docket", item.Docket),
                                           new XElement("TranType", item.TranType),
                                           new XElement("Priority", item.Priority),
                                           new XElement("StartTime", item.StartTime),
                                           new XElement("StartDate", item.StartDate)));
            return xdocment.ToString();
        }

        /// <summary>
        /// 外币付款
        /// </summary>
        /// <param name="ForeignCurryPaymentMsgs"></param>
        /// <returns></returns>
        public static string BuildXMLForFreignCurryPayment(List<ForeignCurryPaymentMsg> ForeignCurryPaymentMsgs)
        {
            XElement xdocment = new XElement("ap", new XElement("CCTransCode", "SGT001"),
                from item in ForeignCurryPaymentMsgs
                select new XElement("Cmp", new XElement("DbAccNo", item.DbAccNo),
                                           new XElement("DbCur", item.DbCur),
                                           new XElement("CrAccNo", item.CrAccNo),
                                           new XElement("CrAccName", item.CrAccName),
                                           new XElement("CrCifType", item.CrCifType),
                                           new XElement("ForeignPayee", item.ForeignPayee),
                                           new XElement("BeneSwifCode", item.BeneSwifCode),
                                           new XElement("CrBankName", item.CrBankName),
                                           new XElement("Fees", item.Fees),
                                           new XElement("Rate", item.Rate),
                                           new XElement("CrCur", item.CrCur),
                                           new XElement("TransAmt", item.TransAmt),
                                           new XElement("WhyUse", item.WhyUse),
                                           new XElement("Docket", item.Docket),
                                           new XElement("TranType", item.TranType),
                                           new XElement("StartTime", item.StartTime),
                                           new XElement("StartDate", item.StartDate)));
            return xdocment.ToString();
        }

        /// <summary>
        /// 行内转账
        /// </summary>
        /// <returns></returns>
        public static string BuildXMLForInnerTransfer(List<InnerTransferMsg> InnerTransferMsgs)
        {
            XElement xdocment = new XElement("ap", new XElement("CCTransCode", "SGT001"),
                from item in InnerTransferMsgs
                select new XElement("Cmp", new XElement("DbAccNo", item.DbAccNo),
                                           new XElement("DbAccName", item.DbAccName),
                                           new XElement("DbCur", item.DbCur),
                                           new XElement("CrAccNo", item.CrAccNo),
                                           new XElement("CrAccName", item.CrAccName),
                                           new XElement("CrProv", item.CrProv),
                                           new XElement("CrCifType", item.CrCifType),
                                           new XElement("CrCur", item.CrCur),
                                           new XElement("TransAmt", item.TransAmt),
                                           new XElement("WhyUse", item.WhyUse),
                                           new XElement("Docket", item.Docket),
                                           new XElement("TranType", item.TranType),
                                           new XElement("StartTime", item.StartTime),
                                           new XElement("StartDate", item.StartDate)));

            return xdocment.ToString();

        }
    }
}
