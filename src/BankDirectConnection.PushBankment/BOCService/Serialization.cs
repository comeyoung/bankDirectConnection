using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.BOC;
using BankDirectConnection.Domain.BOC.Message;
using System;
using System.Linq;
using System.Xml.Linq;

namespace BankDirectConnection.PushBankment.BOCService
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 15:16:24
	===============================================================================================================================*/
    public class Serialization
    {
        /// <summary>
        /// 余额查询
        /// </summary>
        /// <param name="BalanceInquiryMsg"></param>
        /// <returns></returns>
        public static string BuildXMLForBalanceInquiryByLinq(BalanceInquiryMsg BalanceInquiryMsg)
        {
            XDocument xdocment = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("bocb2e",
               new XAttribute("version", "100"),
               new XAttribute("security", "true"),
               new XAttribute("lang", "chs"),
               BuildHeadElement(BalanceInquiryMsg.HeaderMessage),
               new XElement("trans",
                   new XElement("trn-b2e0005-rq",
                       new XElement("b2e0005-rq",
                           new XElement("account", BalanceInquiryMsg.Trans.Actacn,
                           new XElement("ibknum", BalanceInquiryMsg.Trans.Idknum),
                           new XElement("actacn", BalanceInquiryMsg.Trans.Actacn)))))));
            return xdocment.Declaration + xdocment.ToString();
        }

        /// <summary>
        /// 代发工资、报销
        /// </summary>
        /// <param name="WageAndReimbursementMsg"></param>
        /// <returns></returns>
        public static string BuildXMLForWageAndReimbursementByLinq(WageAndReimbursementMsg WageAndReimbursementMsg)
        {
            XDocument xdocment = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("bocb2e",
               new XAttribute("version", "100"),
               new XAttribute("security", "true"),
               new XAttribute("lang", "chs"),
               BuildHeadElement(WageAndReimbursementMsg.HeaderMessage),
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
                           
                           from item in WageAndReimbursementMsg.Trans.DetailMessage
                           select
                           new XElement("detail",
                           new XElement("toibkn", item.Toibkn),
                                                  new XElement("tobank", item.Tobank),
                                                  new XElement("toactn", item.Toactn),
                                                  new XElement("pydcur", item.Pydcur),
                                                  new XElement("pydamt", item.Pydamt),
                                                  new XElement("toname", item.Toidet),
                                                  new XElement("toidtp", item.Toidtp),
                                                  new XElement("toidet", item.Toidet),
                                                  new XElement("furinfo", item.Furinfo),
                                                  new XElement("purpose", item.Purpose),
                                                  new XElement("reserve1", item.Reserve1),
                                                  new XElement("reserve2", item.Reserve2),
                                                  new XElement("reserve3", item.Reserve3),
                                                  new XElement("reserve4", item.Reserve4)),
                          BuildFractnElement(WageAndReimbursementMsg.Trans.FractnMessage))))));
            return xdocment.Declaration + xdocment.ToString();
        }

        /// <summary>
        /// 对公转账
        /// </summary>
        /// <param name="PaymentsToPublicMsg"></param>
        /// <returns></returns>
        public static string BuildXMLForPaymentsToPublicByLinq(PaymentsToPublicMsg PaymentsToPublicMsg)
        {
            if (null == PaymentsToPublicMsg)
                throw new InnerException("", "");
            XDocument xdocment = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("bocb2e",
               new XAttribute("version", "100"),
               new XAttribute("security", "true"),
               new XAttribute("lang", "chs"),
               BuildHeadElement(PaymentsToPublicMsg.HeaderMessage),
               new XElement("trans",
                   new XElement("trn-b2e0009-rq",
                   from item in PaymentsToPublicMsg.Trans
                   select
                  new XElement("b2e0009-rq",
                           BuildFractnElement(item.Fractn),
                           BuildToactnElement(item.Toactn),
                           new XElement("insid", item.Insid),
                           new XElement("obssid", item.Obssid),
                           new XElement("trnamt", item.Trnamt),
                           new XElement("trncur", item.Trncur),
                           new XElement("priolv", item.Priolv),
                           new XElement("furinfo", item.Furinfo),
                           new XElement("trfdate", item.TrfDate),
                           new XElement("trftime", item.TrfTime),
                           new XElement("comacn", item.Comacn))))));
            return xdocment.Declaration + xdocment.ToString();
        }


        /// <summary>
        /// 签出
        /// </summary>
        /// <param name="SignOutMsg"></param>
        /// <returns></returns>
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

        /// <summary>
        /// 签到
        /// </summary>
        /// <param name="SignInMsg"></param>
        /// <returns></returns>
        public static string BuildXMLStrForSignInByLinq(SignInMsg SignInMsg)
        {
            XDocument xdocment = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("bocb2e",
                new XAttribute("version", "100"),
                new XAttribute("security", "true"),
                new XAttribute("lang", "chs"),
                BuildSignInHeadElement(SignInMsg.HeaderMessage),
                new XElement("trans",
                    new XElement("trn-b2e0001-rq",
                        new XElement("b2e0001-rq",
                            new XElement("custdt", SignInMsg.Trans.Custdt),
                            new XElement("oprpwd", SignInMsg.Trans.Oprpwd),
                            new XElement("ceitinfo", SignInMsg.Trans.Ceitinfo))))));
            return xdocment.Declaration + xdocment.ToString();
        }

        /// <summary>
        /// 交易状态查询
        /// </summary>
        /// <param name="TransactionStatusInquiryMsg"></param>
        /// <returns></returns>
        public static string BuildXMLForTransactionStatusInquiryByLinq(TransactionStatusInquiryMsg TransactionStatusInquiryMsg)
        {
            XDocument xdocment = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("bocb2e",
               new XAttribute("version", "100"),
               new XAttribute("security", "true"),
               new XAttribute("lang", "chs"),
               BuildHeadElement(TransactionStatusInquiryMsg.HeaderMessage),
               new XElement("trans",
                   new XElement("trn-b2e0007-rq",
                       new XElement("b2e0007-rq",
                           new XElement("insid", TransactionStatusInquiryMsg.Trans.Insid),
                           new XElement("obssid", TransactionStatusInquiryMsg.Trans.Obssid))))));
            return xdocment.Declaration + xdocment.ToString();
        }

        /// <summary>
        /// 交易查询
        /// </summary>
        /// <param name="TransactionInquiryMsg"></param>
        /// <returns></returns>
        public static string BuildXMLForTransactionInquiryByLinq(TransactionInquiryMsg TransactionInquiryMsg)
        {
            XDocument xdocment = new XDocument(new XDeclaration("1.0", "utf-8", "yes"), new XElement("bocb2e",
               new XAttribute("version", "100"),
               new XAttribute("security", "true"),
               new XAttribute("lang", "chs"),
               BuildHeadElement(TransactionInquiryMsg.HeaderMessage),
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

        /// <summary>
        /// 构建header消息
        /// </summary>
        /// <param name="Header"></param>
        /// <returns></returns>
        public static XElement BuildHeadElement(Header Header)
        {
            if (null == Header)
                throw new Exception("头部消息为空");
            XElement xHeader = new XElement("head",
                new XElement("termid", Header.Termid),
                new XElement("trnid", Header.Trnid),
                new XElement("custid", Header.Custid),
                new XElement("cusopr", Header.Cusopr),
                new XElement("trncod", Header.Trncod),
                new XElement("token", Header.Token));
            return xHeader;
        }

        public static XElement BuildSignInHeadElement(Header Header)
        {
            if (null == Header)
                throw new Exception("头部消息为空");
            XElement xHeader = new XElement("head",
                new XElement("termid", Header.Termid),
                new XElement("trnid", Header.Trnid),
                new XElement("custid", Header.Custid),
                new XElement("cusopr", Header.Cusopr),
                new XElement("trncod", Header.Trncod));
            return xHeader;
        }

        /// <summary>
        /// 构建付款人元素信息
        /// </summary>
        /// <param name="FractnMsg"></param>
        /// <returns></returns>
        public static XElement BuildFractnElement(Fractn FractnMsg)
        {
            if (null == FractnMsg)
                throw new Exception("付款人信息为空");
            XElement xFractn = new XElement("fractn", new XElement("fribkn", FractnMsg.Fribkn),
                                                 new XElement("actacn", FractnMsg.Actacn),
                                                 new XElement("actnam", FractnMsg.Actnam));
            return xFractn;
        }

        /// <summary>
        /// 构建收款人元素信息
        /// </summary>
        /// <param name="ToactnMsg"></param>
        /// <returns></returns>
        public static XElement BuildToactnElement(Toactn ToactnMsg)
        {
            if (null == ToactnMsg)
                throw new Exception("收款人信息为空");
            XElement xToactn = new XElement("toactn", new XElement("toibkn", ToactnMsg.ToiBkn),
                                                 new XElement("actacn", ToactnMsg.Actacn),
                                                 new XElement("toname", ToactnMsg.Toname),
                                                 new XElement("toaddr", ToactnMsg.Toaddr),
                                                 new XElement("tobknm", ToactnMsg.Tobknm));
            return xToactn;
        }
    }
}
