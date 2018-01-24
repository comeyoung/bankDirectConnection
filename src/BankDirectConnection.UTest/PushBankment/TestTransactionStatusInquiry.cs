using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankDirectConnection.PushBankment.BOCService;
using BankDirectConnection.Domain.BOC;
using BankDirectConnection.Domain.QueryBO;
using BankDirectConnection.PushBankment.BankTransfer;

namespace BankDirectConnection.UTest.PushBankment
{
    [TestClass]
    public class TestTransactionStatusInquiry
    {
        public TransactionStatusInquiryMsg StatusSetIn()
        {
            TransactionStatusInquiryMsg tsim = new TransactionStatusInquiryMsg();
            tsim.HeaderMessage.Cusopr = "em123456";
            tsim.HeaderMessage.Custid = "03";
            tsim.HeaderMessage.Obssmsgid = "d123456";
            tsim.HeaderMessage.Termid = "前置机";
            tsim.HeaderMessage.Token = "qwe1366";
            tsim.HeaderMessage.Trncod = "asdf1234";
            tsim.HeaderMessage.Trnid = "qqq123456";
            tsim.HeaderMessage.TrnTyp = "状态查询";
            tsim.Trans.Add(new TransactionStatusInquiry() { EDIId = "cust123", Obssid = "wa1316" });

            return tsim;
        }
        //中行交易状态查询请求报文
        [TestMethod]
        public void TestXMLForTransactionStatusInquiryByLinq()
        {
            var transXML = Serialization.BuildXMLForTransactionStatusInquiryByLinq(StatusSetIn());
            Console.WriteLine(transXML);

        }

        [TestMethod]
        public void TestSplitTransferQueryData()
        {
            var testBO = new TransferQueryDataList();
            int i = 0;
            do {
                i++;
                var data = new TransferQueryData();
                data.ClientId = "i";
                data.ObssId = i.ToString() + i;
                testBO.TransferQueryDatas.Add(data);
            }
            while ( i < 400);
            BOCService service = new BOCService();
            var rt = service.SplitTransferData(testBO);
            Assert.AreEqual(4, rt.Count);
            foreach (var item in rt) {
                Console.WriteLine(item);
            }
        }
    }
}
