using BankDirectConnection.Domain.SGB;
using BankDirectConnection.PushBankment.SGBService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.UTest.PushBankment
{
    [TestClass]
    public class TestSGTrans
    {
        public RMBPaymentMsg SetIn() {
            RMBPaymentMsg rpm = new RMBPaymentMsg();
            rpm.CrAccName = "张三";
            rpm.CrAccNo = "123456789";
            rpm.CrBankName = "法兴银行分行";
            rpm.CrCifType = "借记卡";
            rpm.CrCur = "人民币";
            rpm.DbAccName = "李四";
            rpm.DbCur = "人民币";
            rpm.Docket = "记得还钱";
            rpm.ForeignPayee = "身份证";
            rpm.Head.AuthNo = "3102";
            rpm.Head.CCTransCode = "123456";
            rpm.Head.ChannelType = "类型";
            rpm.Head.CorpNo = "123456789";
            rpm.Head.OpNo = "123666";
            rpm.Head.PassWord = "666666";
            rpm.Head.ProductID = "12";
            rpm.Head.ReqDate = "20170203";
            rpm.Head.ReqSeqNo = "20161213";
            rpm.Head.ReqTime = "161215";
            rpm.Head.Sign = "13";
            rpm.Priority = "加急";
            rpm.StartDate = "20160809";
            rpm.StartTime = "121625";
            rpm.TransAmt = 10000;
            rpm.TranType = "ATM";
            rpm.UnionDeptId = "987654321";
            rpm.WhyUse = "借钱";
            return rpm;
        }

        public ForeignCurryPaymentMsg FreignSetIn() {
            ForeignCurryPaymentMsg fcpm = new ForeignCurryPaymentMsg();
            fcpm.BeneSwifCode = "123456";
            fcpm.CrAccName = "张三";
            fcpm.CrAccNo = "123456789";
            fcpm.CrBankName = "法兴银行某某支行";
            fcpm.CrCifType = "借记卡";
            fcpm.CrCur = "美元";
            fcpm.DbAccName = "李四";
            fcpm.DbAccNo = "987654321";
            fcpm.DbCur = "美元";
            fcpm.Docket = "薪水";
            fcpm.Fees = "网上支付";
            fcpm.ForeignPayee = "身份证";
            fcpm.Head.AuthNo = "3102";
            fcpm.Head.CCTransCode = "1133";
            fcpm.Head.ChannelType = "某某";
            fcpm.Head.CorpNo = "C123456";
            fcpm.Head.OpNo = "em123456";
            fcpm.Head.PassWord = "654321";
            fcpm.Head.ProductID = "d12";
            fcpm.Head.ReqDate = "20170809";
            fcpm.Head.ReqSeqNo = "d201708";
            fcpm.Head.ReqTime = "16253232";
            fcpm.Head.Sign = "d123";
            fcpm.Rate = "1";
            fcpm.StartDate = "20170809";
            fcpm.StartTime = "121625";
            fcpm.TransAmt = 10000;
            fcpm.TranType = "网银";
            fcpm.UnionDeptId = "d336677";
            fcpm.WhyUse = "薪水";
            return fcpm;
        }

        public InnerTransferMsg InnerSetIn() {
            InnerTransferMsg itm = new InnerTransferMsg();
            itm.CrAccName = "张三";
            itm.CrAccNo = "123456789";
            itm.CrBankName = "法兴银行某某支行";
            itm.CrCifType = "借记卡";
            itm.CrCur = "美元";
            itm.DbAccName = "李四";
            itm.DbAccNo = "987654321";
            itm.DbCur = "美元";
            itm.Docket = "薪水";
            itm.CrProv = "06";
            itm.Head.AuthNo = "3102";
            itm.Head.CCTransCode = "1133";
            itm.Head.ChannelType = "某某";
            itm.Head.CorpNo = "C123456";
            itm.Head.OpNo = "em123456";
            itm.Head.PassWord = "654321";
            itm.Head.ProductID = "d12";
            itm.Head.ReqDate = "20170809";
            itm.Head.ReqSeqNo = "d201708";
            itm.Head.ReqTime = "16253232";
            itm.Head.Sign = "d123";
            itm.StartDate = "20170809";
            itm.StartTime = "20170809";
            itm.TransAmt = 10000;
            itm.TranType = "网银";
            itm.UnionDeptId = "d336677";
            itm.WhyUse = "薪水";
            return itm;

        }

        [TestMethod]
        public void TestXMLForRMBPayment()
        {
            
            var transXML = Serialization.BuildXMLForRMBPayment(SetIn());
            Console.WriteLine(transXML);

        }


        [TestMethod]
        public void TestXMLForFreignCurryPayment()
        {

            var transXML = Serialization.BuildXMLForFreignCurryPayment(FreignSetIn());
            Console.WriteLine(transXML);

        }


        [TestMethod]
        public void TestXMLForInnerTransfer() {
            var transXML = Serialization.BuildXMLForInnerTransfer(InnerSetIn());
            Console.WriteLine(transXML);

        }

       
    }
}
