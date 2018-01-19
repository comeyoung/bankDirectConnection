using BankDirectConnection.Domain.SGB;
using BankDirectConnection.Domain.SGB.PaymentMsg;
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
            XElement xdocment = new XElement("ap", new XElement("CCTransCode", "SGT002"),
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
            XElement xdocment = new XElement("ap", new XElement("CCTransCode", "SGT003"),
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
        public static string BuildXMLForInnerTransfer(List<IInnerTransferMsg> InnerTransferMsgs)
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

        public static List<XElement> BuildXMLForCommonHeader(CommonHeader Head)
        {
            List<XElement> xElement = new List<XElement>();
            xElement.Add(new XElement("ReqSeqNo", Head.ReqSeqNo));
            xElement.Add(new XElement("ReqDate", Head.ReqDate));
            xElement.Add(new XElement("ReqTime", Head.ReqTime));
            return xElement;

        }

        /// <summary>
        /// 人民币付款
        /// </summary>
        /// <param name="RMBPaymentMsgs"></param>
        /// <returns></returns>
        public static string BuildXMLForRMBPayment(IRMBPaymentMsg RMBPaymentMsg)
        {
            XElement xdocment = new XElement("ap", new XElement("CCTransCode", "SGT002"),
                BuildXMLForCommonHeader(RMBPaymentMsg.Head),
                new XElement("Cmp", new XElement("DbAccNo", RMBPaymentMsg.DbAccNo),
                                           new XElement("DbAccName", RMBPaymentMsg.DbAccName),
                                           new XElement("DbCur", RMBPaymentMsg.DbCur),
                                           new XElement("CrAccNo", RMBPaymentMsg.CrAccNo),
                                           new XElement("CrAccName", RMBPaymentMsg.CrAccName),
                                           new XElement("CrCifType", RMBPaymentMsg.CrCifType),
                                           new XElement("ForeignPayee", RMBPaymentMsg.ForeignPayee),
                                           new XElement("UnionDeptId", RMBPaymentMsg.UnionDeptId),
                                           new XElement("CrBankName", RMBPaymentMsg.CrBankName),
                                           new XElement("CrCur", RMBPaymentMsg.CrCur),
                                           new XElement("TransAmt", RMBPaymentMsg.TransAmt),
                                           new XElement("WhyUse", RMBPaymentMsg.WhyUse),
                                           new XElement("Docket", RMBPaymentMsg.Docket),
                                           new XElement("TranType", RMBPaymentMsg.TranType),
                                           new XElement("Priority", RMBPaymentMsg.Priority),
                                           new XElement("StartTime", RMBPaymentMsg.StartTime),
                                           new XElement("StartDate", RMBPaymentMsg.StartDate)));
            return xdocment.ToString();
        }

        /// <summary>
        /// 外币付款
        /// </summary>
        /// <param name="ForeignCurryPaymentMsgs"></param>
        /// <returns></returns>
        public static string BuildXMLForFreignCurryPayment(IForeignCurryPaymentMsg ForeignCurryPaymentMsg)
        {
            XElement xdocment = new XElement("ap", new XElement("CCTransCode", "SGT003"),
                BuildXMLForCommonHeader(ForeignCurryPaymentMsg.Head),
                new XElement("Cmp", new XElement("DbAccNo", ForeignCurryPaymentMsg.DbAccNo),
                                           new XElement("DbCur", ForeignCurryPaymentMsg.DbCur),
                                           new XElement("CrAccNo", ForeignCurryPaymentMsg.CrAccNo),
                                           new XElement("CrAccName", ForeignCurryPaymentMsg.CrAccName),
                                           new XElement("CrCifType", ForeignCurryPaymentMsg.CrCifType),
                                           new XElement("ForeignPayee", ForeignCurryPaymentMsg.ForeignPayee),
                                           new XElement("BeneSwifCode", ForeignCurryPaymentMsg.BeneSwifCode),
                                           new XElement("CrBankName", ForeignCurryPaymentMsg.CrBankName),
                                           new XElement("Fees", ForeignCurryPaymentMsg.Fees),
                                           new XElement("Rate", ForeignCurryPaymentMsg.Rate),
                                           new XElement("CrCur", ForeignCurryPaymentMsg.CrCur),
                                           new XElement("TransAmt", ForeignCurryPaymentMsg.TransAmt),
                                           new XElement("WhyUse", ForeignCurryPaymentMsg.WhyUse),
                                           new XElement("Docket", ForeignCurryPaymentMsg.Docket),
                                           new XElement("TranType", ForeignCurryPaymentMsg.TranType),
                                           new XElement("StartTime", ForeignCurryPaymentMsg.StartTime),
                                           new XElement("StartDate", ForeignCurryPaymentMsg.StartDate)));
            return xdocment.ToString();
        }

        /// <summary>
        /// 行内转账
        /// </summary>
        /// <returns></returns>
        public static string BuildXMLForInnerTransfer(IInnerTransferMsg InnerTransferMsg)
        {
            XElement xdocment = new XElement("ap", new XElement("CCTransCode", "SGT001"),
                BuildXMLForCommonHeader(InnerTransferMsg.Head),
                new XElement("Cmp", new XElement("DbAccNo", InnerTransferMsg.DbAccNo),
                                           new XElement("DbAccName", InnerTransferMsg.DbAccName),
                                           new XElement("DbCur", InnerTransferMsg.DbCur),
                                           new XElement("CrAccNo", InnerTransferMsg.CrAccNo),
                                           new XElement("CrAccName", InnerTransferMsg.CrAccName),
                                           new XElement("CrProv", InnerTransferMsg.CrProv),
                                           new XElement("CrCifType", InnerTransferMsg.CrCifType),
                                           new XElement("CrCur", InnerTransferMsg.CrCur),
                                           new XElement("TransAmt", InnerTransferMsg.TransAmt),
                                           new XElement("WhyUse", InnerTransferMsg.WhyUse),
                                           new XElement("Docket", InnerTransferMsg.Docket),
                                           new XElement("TranType", InnerTransferMsg.TranType),
                                           new XElement("StartTime", InnerTransferMsg.StartTime),
                                           new XElement("StartDate", InnerTransferMsg.StartDate)));

            return xdocment.ToString();

        }

        /// <summary>
        /// 查询交易结果
        /// </summary>
        /// <returns></returns>
        public static string BuildXMLForQueryTransactionResults(TransactionResultsMsg TransactionResultsMsg)
        {
            XElement xdocment = new XElement("ap", new XElement("CCTransCode", "SGQ010"),
                BuildXMLForCommonHeader(TransactionResultsMsg.Head),
                new XElement(
                    "Cmp", new XElement("CmeSeqNo", TransactionResultsMsg.Trans.CmeSeqNo),
                          new XElement("StartDate", TransactionResultsMsg.Trans.StartDate)));
            return xdocment.ToString();


        }


    }


}


