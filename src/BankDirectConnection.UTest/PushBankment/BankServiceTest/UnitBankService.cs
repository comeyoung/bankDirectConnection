using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankDirectConnection.PushBankment.BankTransfer;
using BankDirectConnection.Domain.TransferBO;
using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.Application.BaseTranscation;
using System.Collections.Generic;
using System.Linq;

namespace BankDirectConnection.UTest.PushBankment.BankServiceTest
{
    [TestClass]
    public class UnitBankService
    {
        private IAccount GetForAccoutBOC()
        {
            return new Account()
            {
                BankId = "40142",
                BankName = "法兴银行",
                AcctId = "327256085181",
                AcctName = "Jerry",
                AcctType = "1"
            };
        }
        private IAccount GetForAccountSGB()
        {
            return new Account()
            {
                BankId = "309691581000",
                BankName = "法兴银行",
                AcctId = "6610108700592617",
                AcctName = "Jerry",
                AcctType = "1"
            };
        }
        private IAccount GetRMBToAccout()
        {
            return new Account()
            {
                BankId = "104112341234",
                BankName = "中国银行某某支行",
                AcctId = "6326630322660823633",
                AcctName = "张三",
                AcctType = "1"
            };
        }
        private ITranscations GetTrans()
        {
            
            var trans = new Transcations()
            {
                TransWay = "01",
                BusinessType = "01",
            };
            var item = new TransDetail()
            {
                ToAcct = GetRMBToAccout(),
                ReciepterIdType = "0",
                ReciepterIdCode = "111222333666555",
                ReceipterType = "1",
                TransAmount = 10000,
                TransCur = "USD",
                SWIFTCode = "qwe123456",
                Rate = "1"
            };
            for (int i = 0; i < 1000; i++)
            {
                //外币付款
                var transcations = new Transcation()
                {
                    ClientId = "332de889949",
                    PaymentCur = "USD",
                    PaymentType = "1",
                    TransWay = "01",
                    BusinessType = "01",
                    Purpose = "转账",
                    Priority = "是",
                    TransDate = "20160708",
                    TransTime = "162323",
                    FeeType = "1",
                    FeeAcct = "13696858585",
                    AgentSign = "b1362",
                    Comments = "转",
                    FromAcct = GetForAccoutBOC(),
                };
                transcations.TransDetail.Add(item);
                trans.Transcations.Add(transcations);
            }
           
            return trans;
        }

        [TestMethod]
        public void TestBankServicePay()
        {
            //
            BankService bankService = new BankService();
            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(GetTrans()));
            var trans =  GetTrans();
            trans.Check();
            trans.Transcations.ToList().ForEach(c => c.NewEDIId());
            trans.Transcations.ToList().ForEach(c => { Console.WriteLine(c.EDIId); });
            bankService.PaymentTransfer(GetTrans());
        }
    }
}
