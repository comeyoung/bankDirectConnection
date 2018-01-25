using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankDirectConnection.PushBankment.BankTransfer;
using BankDirectConnection.Domain.TransferBO;
using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.Application.BaseTranscation;
using System.Collections.Generic;
using System.Linq;
<<<<<<< HEAD
using BankDirectConnection.BaseApplication.DataHandle;
using BankDirectConnection.Domain.QueryBO;
=======
using BankDirectConnection.Domain.QueryBO;
using BankDirectConnection.BaseApplication.DataHandle;
>>>>>>> edi/master

namespace BankDirectConnection.UTest.PushBankment.BankServiceTest
{
    [TestClass]
    public class UnitBankService
    {
        #region 账户信息
        /// <summary>
        /// 获取中行账户信息
        /// </summary>
        /// <returns></returns>
        private IAccount GetAccoutBOC()
        {
            return new Account()
            {
                BankId = "40142568949556",
                BankName = "中国银行股份有限公司北京崇文门支行",
                AcctId = "327256085181",
                AcctName = "李明",
                AcctType = "1"
            };
        }
        /// <summary>
        /// 获取法兴外币账户信息
        /// </summary>
        /// <returns></returns>
        private IAccount GetForeignAccountSGB()
        {
            return new Account()
            {
                BankId = "309691581000",
<<<<<<< HEAD
                BankName = "法国兴业银行支行",
                AcctId = "126364369963123",
                AcctName = "Jerry",
=======
                BankName = "法国兴业银行北京站支行",
                AcctId = "6610111800612227",
                AcctName = "小马",
>>>>>>> edi/master
                AcctType = "1"
            };
        }
        /// <summary>
        /// 获取法兴人名币账户信息
        /// </summary>
        /// <returns></returns>
        private IAccount GetRMBAccountSGB()
        {
            return new Account()
            {
                BankId = "309691581000",
                BankName = "法国兴业银行北京站支行",
                AcctId = "6610108700592617",
                AcctName = "韩梅梅",
                AcctType = "1"

            };
        }

        #endregion
      
        private IAccount GetForAccountFromSGB()
        {
            return new Account()
            {
                BankId = "309691581000",
                BankName = "法国兴业银行支行",
                AcctId = "7759261010870017",
                AcctName = "Jack",
                AcctType = "0"

            };
        }
        private IAccount GetForAccountFromCNY()
        {
            return new Account()
            {
                BankId = "104100004048",
                BankName = "中国银行股份有限公司北京崇文门支行",
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
                BankName = "美国银行支行",
                AcctId = "6610111800612227",
                AcctName = "Lucy",
                AcctType = "0"

            };
        }
        private IAccount GetRMBToAccout()
        {
            return new Account()
            {
                BankId = "104100004048",
                BankName = "中国银行股份有限公司北京崇文门支行",
                AcctId = "6326630322660823633",
                AcctName = "张思思",
                AcctType = "1"

            };
        }
        private ITranscations GetForerignTrans()
        {
            var trans = new Transcations()
            {
                TransWay = "02",
                BusinessType = "02",
            };
            var item = new TransDetail()
            {
                ToAcct = GetAccoutBOC(),
                ReciepterIdType = "0",
                ReciepterIdCode = "111222333666555",
                ReceipterType = "1",
<<<<<<< HEAD
                TransAmount = 0.35M,
                TransCur = "USD",
                SWIFTCode = "GDJDKFKS",
                Rate = 1
=======
                TransAmount = 0.01M,
                TransCur = "USD",
                SWIFTCode = "DHFGTNBJ",
                Rate = 1

>>>>>>> edi/master
            };
            for (int i = 0; i < 2; i++)
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
                    TransDate = DateTime.Now.ToString("yyyyMMdd"),
                    TransTime = DateTime.Now.ToShortTimeString() + DateTime.Now.Millisecond,
                    FeeType = "1",
                    FeeAcct = "13696858585",
                    Comments = "转",
                    FromAcct = GetForeignAccountSGB(),
                };
                transcations.TransDetail.Add(item);
                trans.Transcations.Add(transcations);
            }
            return trans;
        }
<<<<<<< HEAD

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
                TransAmount = 0.35M,
                TransCur = "USD",
                SWIFTCode = "GDJDKFKS",
                Rate = 1
            };
            for (int i = 0; i < 2; i++)
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
                    TransTime = "16230",
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

        private ITranscations GetRMBTrans()
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
                TransAmount = 0.35M,
                TransCur = "CNY",
                SWIFTCode = "GDJDKFKS",
                Rate = 1
            };
            for (int i = 0; i < 2; i++)
            {
               
                
                var transcations = new Transcation()
                {
                    ClientId = "332de889949",
                    PaymentCur = "CNY",                   
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
                    FromAcct = GetForAccountFromCNY(),
                };
                transcations.TransDetail.Add(item);
                trans.Transcations.Add(transcations);
            }
           
            return trans;
        }

        private ITranscations GetInnerTrans()
        {

            var trans = new Transcations()
            {
                TransWay = "02",
                BusinessType = "02",
            };
            var item = new TransDetail()
            {
                ToAcct = GetForAccountSGB(),
                ReciepterIdType = "0",
                ReciepterIdCode = "111222333666555",
                ReceipterType = "1",
                TransAmount = 0.35M,
                TransCur = "USD",
                SWIFTCode = "GDJDKFKS",
                Rate = 1
            };
            for (int i = 0; i < 2; i++)
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
                    FromAcct = GetForAccountFromSGB(),
                };
                transcations.TransDetail.Add(item);
                trans.Transcations.Add(transcations);
            }

            return trans;
        }

        private ITransferQueryData QueryData() {
            return new TransferQueryData(){
=======
        private ITransferQueryData QueryData()
        {
            return new TransferQueryData()
            {
>>>>>>> edi/master
                ClientId = "161fsdf4sf984f98df",
                EDIId = "320320163363339897",
                ObssId = "2016336333",
                StartDate = "20180607",
                StartTime = "36200"
            };
        }
<<<<<<< HEAD
        /// <summary>
        /// 交易查询信息
        /// </summary>
        /// <returns></returns>
        private ITransferQueryDataList GetQueryTrans() {
            return new TransferQueryDataList() {
=======
        private ITransferQueryDataList GetQueryTrans()
        {
            return new TransferQueryDataList()
            {
>>>>>>> edi/master
                TransferQueryDatas = new List<ITransferQueryData>() {
                    QueryData()
                }

            };

<<<<<<< HEAD
        [TestMethod]
        public void TestBankServicePay()
        {
            BankService bankService = new BankService();
             //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(GetTrans()));
             // var trans =  GetTrans();
             //bankService.PaymentTransfer(trans);
            // trans.Transcations.ToList().ForEach(c => { Console.WriteLine(c.EDIId); });
            //bankService.PaymentTransfer(GetTrans());
           
        }

        /// <summary>
        /// 交易信息查询
        /// </summary>
        [TestMethod]
        public void TestBankServiceQuery()
        {
           //SGBService bankService = new SGBService();
            BankService bankService = new BankService();
            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(GetTrans()));
            //var trans = GetTrans();
            //trans.InitData();
            //trans.Check();
            //trans.Transcations.ToList().ForEach(c => c.NewEDIId());
            //trans.Transcations.ToList().ForEach(c => { Console.WriteLine(c.EDIId); });
=======
        }


        [TestMethod]
        public void TestBankServiceQuery()
        {
            SGBService bankService = new SGBService();
>>>>>>> edi/master
            bankService.QueryTransStatus(GetQueryTrans());
        }
        /*************************获取交易信息****************************/
        /// <summary>
        /// 获取法兴接口内部转账交易信息
        /// </summary>
        /// <returns></returns>
        private ITranscations GetSGBInnerTrans()
        {
            var trans = new Transcations()
            {
                TransWay = "02",
                BusinessType = "02",
            };
            var item = new TransDetail()
            {
                ToAcct = GetForeignAccountSGB(),
                ReciepterIdType = "0",
                ReciepterIdCode = "111222333666555",
                ReceipterType = "1",
                TransAmount = 0.01M,
                TransCur = "USD",
                SWIFTCode = "",
            };
            for (int i = 0; i < 10; i++)
            {
                var transcations = new Transcation()
                {
                    ClientId = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.Millisecond + "001",
                    PaymentCur = "USD",
                    PaymentType = "1",
                    Purpose = "转账",
                    Priority = emPriolv.Urgent,
                    TransDate = DateTime.Now.ToString("yyyyMMdd"),
                    TransTime = DateTime.Now.ToString("HHmmss") + DateTime.Now.Millisecond,
                    FeeType = "1",
                    FeeAcct = "",
                    AgentSign = "0",
                    Comments = "转",
                    FromAcct = GetRMBAccountSGB(),
                };
                transcations.TransDetail.Add(item);
                trans.Transcations.Add(transcations);
            }
            return trans;
        }
        /// <summary>
        /// 获取法兴人民币付款接口
        /// </summary>
        /// <returns></returns>
        private ITranscations GetSGBRMBTrans()
        {
            var trans = new Transcations()
            {
                TransWay = "02",
                BusinessType = "02",
            };
            var item = new TransDetail()
            {
                ToAcct = GetAccoutBOC(),
                ReciepterIdType = "0",
                ReciepterIdCode = "111222333666555",
                ReceipterType = "1",
                TransAmount = 0.01M,
                TransCur = "RMB",
                SWIFTCode = "",
            };
            for (int i = 0; i < 10; i++)
            {
                var transcations = new Transcation()
                {
                    ClientId = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.Millisecond + "001",
                    PaymentCur = "RMB",
                    PaymentType = "1",
                    Purpose = "转账",
                    Priority = emPriolv.Urgent,
                    TransDate = DateTime.Now.ToString("yyyyMMdd"),
                    TransTime = DateTime.Now.ToString("HHmmss") + DateTime.Now.Millisecond,
                    FeeType = "1",
                    FeeAcct = "",
                    AgentSign = "0",
                    Comments = "转",
                    FromAcct = GetRMBAccountSGB(),
                };
                transcations.TransDetail.Add(item);
                trans.Transcations.Add(transcations);
            }
            return trans;
        }

        /// <summary>
        /// 获取法兴接口外币转账
        /// </summary>
        /// <returns></returns>
        private ITranscations GetSGBForeignTrans()
        {
            var trans = new Transcations()
            {
                TransWay = "02",
                BusinessType = "02",
            };
            var item = new TransDetail()
            {
                ToAcct = GetAccoutBOC(),
                ReciepterIdType = "0",
                ReciepterIdCode = "111222333666555",
                ReceipterType = "1",
                TransAmount = 0.01M,
                TransCur = "USD",
                SWIFTCode = "BKCHCNBJ",
            };
            for (int i = 0; i < 10; i++)
            {
                var transcations = new Transcation()
                {
                    ClientId = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.Millisecond + "001",
                    PaymentCur = "USD",
                    PaymentType = "1",
                    Purpose = "转账",
                    Priority = emPriolv.Urgent,
                    TransDate = DateTime.Now.ToString("yyyyMMdd"),
                    TransTime = DateTime.Now.ToString("HHmmss") + DateTime.Now.Millisecond,
                    FeeType = "1",
                    FeeAcct = "",
                    AgentSign = "0",
                    Comments = "转",
                    FromAcct = GetRMBAccountSGB(),
                };
                transcations.TransDetail.Add(item);
                trans.Transcations.Add(transcations);
            }
            return trans;
        }

        /// <summary>
        /// 获取法兴银行查询交易结果信息
        /// </summary>
        /// <returns></returns>
        private ITransferQueryData GetSGBQueryInfo()
        {
            SerialNumberDapperRepository repository = new SerialNumberDapperRepository();
            return new TransferQueryData()
            {
                ClientId = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.Millisecond + "001",
                EDIId = Instruction.NewInsSid("02") + repository.GetSeqNumber(),
                ObssId = "2016336333",
                StartDate = DateTime.Now.ToString("yyyyMMdd"),
                StartTime = DateTime.Now.ToString("HHmmss") + DateTime.Now.Millisecond
            };
        }

        private ITransferQueryDataList GetSGBQueryInfos()
        {
            var queryList = new TransferQueryDataList();
            queryList.TransferQueryDatas.Add(GetSGBQueryInfo());
            return queryList;
        }
        /****************************************************************/


<<<<<<< HEAD
        /// <summary>
        /// 测试外币转账
=======
        /*************************单元测试用例****************************/
        /// <summary>
        /// 测试法兴外币付款
>>>>>>> edi/master
        /// </summary>
        [TestMethod]
        public void TestSGBForerignPayBankService()
        {
            BankService bankService = new BankService();
<<<<<<< HEAD
            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(GetTrans()));
            var trans = GetForerignTrans();
            trans.InitData();
            trans.Check();
            trans.Transcations.ToList().ForEach(c => c.NewEDIId());
            trans.Transcations.ToList().ForEach(c => { Console.WriteLine(c.EDIId); });
            bankService.PaymentTransfer(trans);

        }
        /// <summary>
        /// 人民币转账
=======
            var trans = this.GetSGBForeignTrans();
            bankService.PaymentTransfer(trans);
        }
        /// <summary>
        /// 测试法兴人民币付款
>>>>>>> edi/master
        /// </summary>
        [TestMethod]
        public void TestSGBRMBPayBankService()
        {
            BankService bankService = new BankService();
<<<<<<< HEAD
            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(GetTrans()));
            var trans = GetRMBTrans();
            trans.InitData();
            trans.Check();
            trans.Transcations.ToList().ForEach(c => c.NewEDIId());
            trans.Transcations.ToList().ForEach(c => { Console.WriteLine(c.EDIId); });
            bankService.PaymentTransfer(trans);
        }
        /// <summary>
        /// 行内转账
        /// </summary>
            [TestMethod]
        public void TestBankServiceInnerPay()
        {
            BankService bankService = new BankService();
            //Console.WriteLine(Newtonsoft.Json.JsonConvert.SerializeObject(GetTrans()));
            var trans = GetInnerTrans();
            trans.InitData();
            trans.Check();
            trans.Transcations.ToList().ForEach(c => c.NewEDIId());
            trans.Transcations.ToList().ForEach(c => { Console.WriteLine(c.EDIId); });
            bankService.PaymentTransfer(trans);
=======
            var trans = this.GetSGBRMBTrans();
            bankService.PaymentTransfer(trans);
        }
        /// <summary>
        /// 测试法兴行内转账
        /// </summary>
        [TestMethod]
        public void TestSGBInnerPayBankService()
        {
            BankService bankService = new BankService();
            var trans = this.GetSGBInnerTrans();
            bankService.PaymentTransfer(trans);
        }

        /// <summary>
        /// 测试中行对公转账
        /// </summary>
        [TestMethod]
        public void TestBOCPublicPaymentBankService()
        {
>>>>>>> edi/master

        }

        /// <summary>
        /// 测试中行工资报销业务
        /// </summary>
        [TestMethod]
        public void TestBOCWageBankService()
        {

        }

        /// <summary>
        /// 测试法兴查询交易结果接口
        /// </summary>
        [TestMethod]
        public void TestSGBQueryBankService()
        {
            SGBService bankService = new SGBService();
            bankService.QueryTransStatus(GetSGBQueryInfos());
        }

        /// <summary>
        /// 测试中行查询交易状态
        /// </summary>
        [TestMethod]
        public void TestBOCQueryBankService()
        {

        }
        /********************************************************************/
    }
}

