using BankDirectConnection.Domain.BOC;
using BankDirectConnection.PushBankment.BOCService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.UTest.PushBankment
{
    [TestClass]
    public class TestBOCTrans
    {
        public WageAndReimbursementMsg SetIn() {
            WageAndReimbursementMsg warm = new WageAndReimbursementMsg();
            Detail d = new Detail();
            warm.HeaderMessage.Cusopr = "d123456";
            warm.HeaderMessage.Custid = "C123456";
            warm.HeaderMessage.Obssmsgid = "d123666";
            warm.HeaderMessage.Termid = "前置机";
            warm.HeaderMessage.Token = "qwe1336";
            warm.HeaderMessage.Trncod = "1133qwer";
            warm.HeaderMessage.Trnid = "qwe1336";
            warm.HeaderMessage.TrnTyp = "代发工资";
            warm.Trans.Ceitinfo = "某某";
            warm.Trans.Crdtyp = "5";
          

            d.Furinfo = "某某";
            d.Purpose = "代发";
            d.Pydamt =5000;
            d.Pydcur = "人民币";
            d.Reserve1 = "某某";
            d.Reserve2 = "某某";
            d.Reserve3 = "某某";
            d.Reserve4 = "某某";
            d.Toactn = "q456";
            d.Tobank = "中国银行";
            d.Toibkn = "06d366";
            d.Toidet = "某某";
            d.Toidtp = "身份证";
            d.Toname = "张三";

            warm.Trans.DetailMessage.Add(d);
            warm.Trans.FractnMessage.Actacn="123456789";
            warm.Trans.FractnMessage.Actnam= "李四";
            warm.Trans.FractnMessage.Fribkn = "qwe12345678";
         
            warm.Trans.Furinfo = "代发业务";
            warm.Trans.Insid = "123";
            warm.Trans.Pybamt = 5000;
            warm.Trans.Pybcur = "人民币";
            warm.Trans.Pybnum = 20;
            warm.Trans.Telephone = "18888888888";
            warm.Trans.Transtype = "某某";
            warm.Trans.Trfdate = "20180106";
            warm.Trans.Useinf = "某某";
            
            return warm;
        }

        public PaymentsToPublicMsg PublicSetIn() {
            PaymentsToPublicMsg ptpm = new PaymentsToPublicMsg();
            PaymentsToPublicTrans ptpt = new PaymentsToPublicTrans();
            ptpm.HeaderMessage.Cusopr = "d123456";
            ptpm.HeaderMessage.Custid = "C123456";
            ptpm.HeaderMessage.Obssmsgid = "qwe123666";
            ptpm.HeaderMessage.Termid = "前置机";
            ptpm.HeaderMessage.Token = "qqq123";
            ptpm.HeaderMessage.Trncod = "1233qwerty";
            ptpm.HeaderMessage.Trnid = "asd123456";
            ptpm.HeaderMessage.TrnTyp = "对公转账";
            ptpt.Comacn = "1236549";
            ptpt.Fractn.Actacn = "123456789";
            ptpt.Fractn.Actnam = "李四";
            ptpt.Fractn.Fribkn = "45d1236";
            ptpt.Furinfo = "转账";
            ptpt.Insid = "zxc123";
            ptpt.Obssid = "asd1236";
            ptpt.Priolv = "0";
            ptpt.Toactn.Actacn = "987654321";
            ptpt.Toactn.Toaddr = "北京";
            ptpt.Toactn.Tobknm = "中行某支行";
            ptpt.Toactn.ToiBkn = "123d456";
            ptpt.Toactn.Toname = "张三";

            ptpt.TrfDate = "20170809";
            ptpt.TrfTime = "170506";
            ptpt.Trnamt = 5000;
            ptpt.Trncur = "CNY";
            ptpm.Trans.Add(ptpt);


            return ptpm;
        }


        public TransactionStatusInquiryMsg StatusSetIn() {
            TransactionStatusInquiryMsg tsim = new TransactionStatusInquiryMsg();
            tsim.HeaderMessage.Cusopr = "em123456";
            tsim.HeaderMessage.Custid = "03";
            tsim.HeaderMessage.Obssmsgid = "d123456";
            tsim.HeaderMessage.Termid = "前置机";
            tsim.HeaderMessage.Token = "qwe1366";
            tsim.HeaderMessage.Trncod = "asdf1234";
            tsim.HeaderMessage.Trnid = "qqq123456";
            tsim.HeaderMessage.TrnTyp = "状态查询";
            tsim.Trans.Insid = "cust123";
            tsim.Trans.Obssid = "wa1316";
            return tsim;
        }


        [TestMethod]
        public void TestXMLForWageAndReimbursementByLinq() {
            var transXML = Serialization.BuildXMLForWageAndReimbursementByLinq(SetIn());
            Console.WriteLine(transXML);

        }


        [TestMethod]
        public void TestXMLForPaymentsToPublicByLinq()
        {
            var transXML = Serialization.BuildXMLForPaymentsToPublicByLinq(PublicSetIn());
            Console.WriteLine(transXML);

        }


        [TestMethod]
        public void TestXMLForTransactionStatusInquiryByLinq()
        {
            var transXML = Serialization.BuildXMLForTransactionStatusInquiryByLinq(StatusSetIn());
            Console.WriteLine(transXML);

        }
    }
}
