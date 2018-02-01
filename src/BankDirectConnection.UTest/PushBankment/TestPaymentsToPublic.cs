using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankDirectConnection.Domain.TransferBO;
using BankDirectConnection.Application.BaseTranscation;
using System.Collections.Generic;
using BankDirectConnection.PushBankment.BOCService.Service;
using BankDirectConnection.Domain.BOC;
using BankDirectConnection.PushBankment.BOCService;
using BankDirectConnection.BaseApplication.DataHandle;

namespace BankDirectConnection.UTest.PushBankment
{
    [TestClass]
    public class TestPaymentsToPublic
    {
        public ITranscations GetTrans()
        {
            ITranscations trans = new Transcations();
            trans.TransWay = "01";
            trans.BusinessType = "02";
            trans.TranscationItems.Add(new Transcation() 
            {
                ClientId = Guid.NewGuid().ToString(),
                FromAcct = new Account() { AcctId = "327256085181", AcctName = "EDF", BankId = "40142", BankName = "BOC" },
                PaymentCur = "CNY",
                Purpose = "01",
                Priority = emPriolv.emUrgent,
                TransDate = "20180115",
                TransDetail = new List<ITransDetail>() {
                    new TransDetail() { TransCur = "CNY",TransAmount = 100000.00M ,ToAcct = new Account() { AcctId = "342856085028", AcctName = "FX", BankId = "100052", BankName = "BOC" }},
                    new TransDetail() { TransCur = "CNY",TransAmount = 600000.00M,ToAcct = new Account() { AcctId = "258245854235", AcctName = "Fancy", BankId = "100052", BankName = "BOC" }}
                }

            });
            trans.TranscationItems.Add(new Transcation()
            {
                ClientId = Guid.NewGuid().ToString(),
                FromAcct = new Account() { AcctId = "658245854235", AcctName = "EDF", BankId = "40142", BankName = "BOC" },
                PaymentCur = "CNY",
                Purpose = "01",
                Priority = emPriolv.emUrgent,
                TransDate = "20180115",
                TransDetail = new List<ITransDetail>() {
                    new TransDetail() { TransCur = "CNY",TransAmount = 100000.00M ,ToAcct = new Account() { AcctId = "158245854235", AcctName = "FX", BankId = "100052", BankName = "BOC" }},
                    new TransDetail() { TransCur = "CNY",TransAmount = 600000.00M,ToAcct = new Account() { AcctId = "258245854235", AcctName = "Fancy", BankId = "100052", BankName = "BOC" }}
                }

            });
            return trans;
        }
        [TestMethod]
        public void TestPaymentsToPublicService()
        {
            //PaymentsToPublicService service = new PaymentsToPublicService();
            //var rt = service.PushPaymentsToPublic(GetTrans());
        }
        [TestMethod]
        public void TestBOCreate()
        {
            var transBO = new PaymentsToPublicMsg(GetTrans());
            // Assert.AreEqual(trans.Transcations, transBO.Trans.Count);
        }
        [TestMethod]
        public void TestSerialization()
        {
            var transBO = new PaymentsToPublicMsg(GetTrans());
            //序列化
            var transXML = Serialization.BuildXMLForPaymentsToPublicByLinq(transBO);
            Console.WriteLine("PaymentToPublic:" + transXML);
        }
        [TestMethod]
        public void TestDeserialization()
        {
            string res = @"<?xml version = ""1.0"" encoding = ""GB2312""?><bocb2e version=""100"" security=""true"" lang=""chs""><head><termid>E127000000001</termid><trnid>20060704001</trnid><custid>12345678</custid><cusopr>BOC</cusopr><trncod>b2e0009</trncod><token>9TTQALYGH1</token></head><trans><trn-b2e0009-rs><status><rspcod>B001</rspcod><errmsg>OK</errmsg></status><b2e0009-rs><status><rspcod>B001</rspcod><errmsg>OK</errmsg></status><insid>100001</insid><obssid>88886</obssid></b2e0009-rs><b2e0009-rs><status><rspcod>B001</rspcod><errmsg>OK</errmsg></status><insid>100002</insid><obssid>88887</obssid></b2e0009-rs></trn-b2e0009-rs></trans></bocb2e>";
            var rt = Deserialization.ParseResponseMsg(res, "b2e0009");
            Assert.AreEqual("B001", rt.Status.RspCod);
            Assert.AreEqual(2, rt.DetailResponses.Count);
        }
    }
}
