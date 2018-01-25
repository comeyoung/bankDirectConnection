using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankDirectConnection.PushBankment.BankTransfer;
using BankDirectConnection.Domain.TransferBO;
using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.Application.BaseTranscation;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
using BankDirectConnection.Domain.QueryBO;
=======
using BankDirectConnection.BaseApplication.DataHandle;
>>>>>>> edi/master

namespace BankDirectConnection.UTest.PushBankment.BankServiceTest
{
    [TestClass]
    public class UnitBankService
    {
        private IAccount GetForAccoutBOC()
        {
            return new Account()
            {
                BankId = "40142568949556",
                BankName = "中国某某支行",
                AcctId = "327256085181",
                AcctName = "李四",
                AcctType = "1"
            };
        }
        private IAccount GetForAccountSGB()
        {
            return new Account()
            {
                BankId = "309691581000",
                BankName = "法国兴业银行某某支行",
                AcctId = "126364369963123",
                AcctName = "Jerry",
                AcctType = "1"
               
            };
        }

        private IAccount GetForAccountFromSGB()
        {
            return new Account()
            {
                BankId = "309691581000",
                BankName = "法兴银行某某支行",
                AcctId = "7759261010870017",
                AcctName = "Jack",
                AcctType = "0"

            };
        }

        private IAccount GetForAccountFromCNY()
        {
            return new Account()
            {
                BankId = "265691581000",
                BankName = "中国银行某某支行",
                AcctId = "6610108700592617 ",
                AcctName = "李白",
                AcctType = "0"

            };
        }
        private IAccount GetForAccountFromUSD()
        {
            return new Account()
            {
                BankId = "309691581000",
                BankName = "美国银行某某支行",
                AcctId = "6610111800612227",
                AcctName = "Lucy",
                AcctType = "0"

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
                TransWay = "02",
                BusinessType = "02",
            };
            var item = new TransDetail()
            {
                ToAcct = GetForAccoutBOC(),
                ReciepterIdType = "0",
                ReciepterIdCode = "111222333666555",
                ReceipterType = "1",
                TransAmount = 10000.35M,
                TransCur = "USD",
<<<<<<< HEAD
                SWIFTCode = "DHFGTNBJ",
                Rate = "1"
=======
                SWIFTCode = "qwe123456",
                Rate = 1
>>>>>>> edi/master
            };
            for (int i = 0; i < 10; i++)
            {
               
                
                var transcations = new Transcation()
                {
                    ClientId = "332de889949",
                    PaymentCur = "USD",                   
                    PaymentType = "1",
                    TransWay = "02",
                    BusinessType = "02",
                    Purpose = "转账",
                    Priority = emPriolv.Urgent,
                    TransDate = "20160708",
                    TransTime = "162323236",
                    FeeType = "1",
                    FeeAcct = "13696858585",
                    AgentSign = "b1362",
                    Comments = "转",
                    FromAcct = GetForAccountFromUSD(),
                };
                transcations.TransDetail.Add(item);
                trans.Transcations.Add(transcations);
            }
           
            return trans;
        }

        private ITransferQueryData QueryData() {
            return new TransferQueryData(){
                ClientId = "161fsdf4sf984f98df",
                EDIId = "320320163363339897",
                ObssId = "2016336333",
                StartDate = "20180607",
                StartTime = "16243666"
            };
        }
        private ITransferQueryDataList GetQueryTrans() {
            return new TransferQueryDataList() {
                TransferQueryDatas = new List<ITransferQueryData>() {
                    QueryData()
                }

            };
            
        }

        [TestMethod]
        public void TestBankServicePay()
<<<<<<< HEAD
        {          
=======
        {
>>>>>>> edi/master
            BankService bankService = new BankService();
            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(GetTrans()));
            var trans =  GetTrans();
            bankService.PaymentTransfer(trans);
            trans.Transcations.ToList().ForEach(c => { Console.WriteLine(c.EDIId); });
<<<<<<< HEAD
            bankService.PaymentTransfer(GetTrans());
           
        }

        [TestMethod]
        public void TestBankServiceQuery()
        {
            SGBService bankService = new SGBService();
            //BankService bankService = new BankService();
            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(GetTrans()));
            var trans = GetTrans();
            trans.InitData();
            trans.Check();
            trans.Transcations.ToList().ForEach(c => c.NewEDIId());
            trans.Transcations.ToList().ForEach(c => { Console.WriteLine(c.EDIId); });
            // bankService.PaymentTransfer(GetTrans());
            bankService.QueryTransStatus(GetQueryTrans());
=======
>>>>>>> edi/master
        }


        [TestMethod]
        public void TestBankServiceForerignPay()
        {
            BankService bankService = new BankService();
            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(GetTrans()));
            var trans = GetTrans();
            trans.InitData();
            trans.Check();
            trans.Transcations.ToList().ForEach(c => c.NewEDIId());
            trans.Transcations.ToList().ForEach(c => { Console.WriteLine(c.EDIId); });
            bankService.PaymentTransfer(GetTrans());

        }
        [TestMethod]
        public void TestBankServiceRMBPay()
        {
            BankService bankService = new BankService();
            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(GetTrans()));
            var trans = GetTrans();
            trans.InitData();
            trans.Check();
            trans.Transcations.ToList().ForEach(c => c.NewEDIId());
            trans.Transcations.ToList().ForEach(c => { Console.WriteLine(c.EDIId); });
            bankService.PaymentTransfer(GetTrans());
        }
            [TestMethod]
        public void TestBankServiceInnerPay()
        {
            BankService bankService = new BankService();
            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(GetTrans()));
            var trans = GetTrans();
            trans.InitData();
            trans.Check();
            trans.Transcations.ToList().ForEach(c => c.NewEDIId());
            trans.Transcations.ToList().ForEach(c => { Console.WriteLine(c.EDIId); });
            bankService.PaymentTransfer(GetTrans());

        }
    }
    }

