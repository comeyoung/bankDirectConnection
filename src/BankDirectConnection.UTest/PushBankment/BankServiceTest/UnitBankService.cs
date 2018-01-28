using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankDirectConnection.PushBankment.BankTransfer;
using BankDirectConnection.Domain.TransferBO;
using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.Application.BaseTranscation;
using System.Collections.Generic;
using System.Linq;

using BankDirectConnection.Domain.QueryBO;
using BankDirectConnection.BaseApplication.DataHandle;
using Newtonsoft.Json;
using BankDirectConnection.Domain.DataHandle;
using BankDirectConnection.Domain.BOC;

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

                BankName = "法国兴业银行北京站支行",
                AcctId = "6610111800612227",
                AcctName = "小马",

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
                AcctType = "0"

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
                BankId = "432691581000",
                BankName = "美国银行支行",
                AcctId = "6610111800612227",
                AcctName = "Lucy",
                AcctType = "0"

            };
        }

        private IAccount GetForAccountToUSD()
        {
            return new Account()
            {
                BankId = "679691581000",
                BankName = "美国银行支行",
                AcctId = "7366561800612227",
                AcctName = "Danny",
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

                TransAmount = 0.01M,
                TransCur = "USD",
                SWIFTCode = "DHFGTNBJ",
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
                    TransDate = DateTime.Now.ToString("yyyyMMdd"),
                    TransTime = DateTime.Now.ToShortTimeString() + DateTime.Now.Millisecond,
                    FeeType = "1",
                    FeeAcct = "13696858585",
                    Comments = "转",
                    FromAcct = GetForeignAccountSGB(),
                };
                transcations.TransDetail.Add(item);
                trans.TranscationItems.Add(transcations);
            }
            return trans;
        }

        private ITransferQueryData QueryData()
        {
            return new TransferQueryData()
            {

                ClientId = "161fsdf4sf984f98df",
                EDIId = "320320163363339897",
                ObssId = "2016336333",
                StartDate = "20180607",
                StartTime = "36200"
            };
        }

        private ITransferQueryDataList GetQueryTrans()
        {
            return new TransferQueryDataList()
            {

                TransferQueryDatas = new List<ITransferQueryData>() {
                    QueryData()
                }

            };


        }


        [TestMethod]
        public void TestBankServiceQuery()
        {
            SGBService bankService = new SGBService();

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
                SWIFTCode = "CHFGTYU",
            };
            for (int i = 0; i < 6; i++)
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
                trans.TranscationItems.Add(transcations);
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
                TransCur = "CNY",
                SWIFTCode = "",
            };
            for (int i = 0; i < 6; i++)
            {
                var transcations = new Transcation()
                {
                    ClientId = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.Millisecond + "001",
                    PaymentCur = "CNY",
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
                trans.TranscationItems.Add(transcations);
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
                ToAcct = GetForAccountToUSD(),
                ReciepterIdType = "0",
                ReciepterIdCode = "111222333666555",
                ReceipterType = "1",
                TransAmount = 0.01M,
                TransCur = "USD",
                SWIFTCode = "BKCHCNBJ",
                Rate = 6
            };
            for (int i = 0; i < 6; i++)
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
                trans.TranscationItems.Add(transcations);
            }
            return trans;
        }

       
        


        /// <summary>
        /// 获取中行接口对公转账
        /// </summary>
        /// <returns></returns>
        private IAccount getFromAcct()
        {
            IAccount FromAcct = new Account();
            FromAcct.AcctId = "40142";
            FromAcct.AcctName = "李飞";
            FromAcct.AcctType = "0";
            FromAcct.BankId = "104100000004";
            FromAcct.BankName = "中国银行总行";
            return FromAcct;
        }

        /// <summary>
        /// 获取中行对公转账明细
        /// </summary>
        /// <returns></returns>
        private ITranscation getWageTranscation()
        {
            SerialNumberDapperRepository repository = new SerialNumberDapperRepository();
            return new Transcation()
            {
                AgentSign = "Y",
                ClientId = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.Millisecond + "001",
                EDIId = "",
                Comments = "薪水",
                FeeAcct = "327256085181",
                FeeType = "1",
                FromAcct = getFromAcct(),
                PaymentCur = "RMB",
                BusinessType = "01",
                PaymentType = "1",
                Priority = emPriolv.Urgent,
                Purpose = "薪水",
                TransDate = DateTime.Now.ToString("yyyyMMdd"),
                TransTime = DateTime.Now.ToString("HHmmss") + DateTime.Now.Millisecond,
                TransWay = "01",
                TransDetail = new List<ITransDetail>() {
                new TransDetail(){
                    ReceipterType = "1",
                    ReciepterIdCode = "130666996689890306",
                    ReciepterIdType = "1",
                    SWIFTCode = "BKCHCNBJ",
                    ToAcct = new Account() {
                        AcctId = "342856085028",
                        AcctName = "张宇",
                        AcctType = "1",
                        BankId = "40142",
                        BankName = "中国银行股份有限公司北京人大支行",
                    },
                    TransAmount = 0.01M,
                    TransCur = "RMB",
                    Rate = 1
                }
                }

            };
}
        private ITranscation getPublicTranscation()
        {
            SerialNumberDapperRepository repository = new SerialNumberDapperRepository();
            return new Transcation()
            {
                AgentSign = "Y",
                ClientId = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.Millisecond + "001",
                EDIId ="",
                Comments = "薪水",
                FeeAcct = "327256085181",
                FeeType = "1",
                FromAcct = getFromAcct(),
                PaymentCur = "RMB",
                BusinessType = "02",
                PaymentType = "1",
                Priority = emPriolv.Urgent,
                Purpose = "薪水",
                TransDate = DateTime.Now.ToString("yyyyMMdd"),
                TransTime = DateTime.Now.ToString("HHmmss") + DateTime.Now.Millisecond,
                TransWay = "01",
                TransDetail = new List<ITransDetail>() {
                new TransDetail(){
                    ReceipterType = "1",
                    ReciepterIdCode = "130666996689890306",
                    ReciepterIdType = "1",
                    SWIFTCode = "BKCHCNBJ",
                    ToAcct = new Account() {
                        AcctId = "342856085028",
                        AcctName = "张宇",
                        AcctType = "1",
                        BankId = "40142",
                        BankName = "中国银行股份有限公司北京人大支行",
                    },
                    TransAmount = 0.01M,
                    TransCur = "RMB",
                    Rate = 1
                },new TransDetail(){
                    ReceipterType = "1",
                    ReciepterIdCode = "130666996689890306",
                    ReciepterIdType = "1",
                    SWIFTCode = "BKCHCNBJ",
                    ToAcct = new Account() {
                        AcctId = "342856085028",
                        AcctName = "张宇",
                        AcctType = "1",
                        BankId = "40142",
                        BankName = "中国银行股份有限公司北京人大支行",
                    },
                    TransAmount = 0.01M,
                    TransCur = "RMB",
                    Rate = 1
                },new TransDetail(){
                    ReceipterType = "1",
                    ReciepterIdCode = "130666996689890306",
                    ReciepterIdType = "1",
                    SWIFTCode = "BKCHCNBJ",
                    ToAcct = new Account() {
                        AcctId = "342856085028",
                        AcctName = "张宇",
                        AcctType = "1",
                        BankId = "40142",
                        BankName = "中国银行股份有限公司北京人大支行",
                    },
                    TransAmount = 0.01M,
                    TransCur = "RMB",
                    Rate = 1
                },new TransDetail(){
                    ReceipterType = "1",
                    ReciepterIdCode = "130666996689890306",
                    ReciepterIdType = "1",
                    SWIFTCode = "BKCHCNBJ",
                    ToAcct = new Account() {
                        AcctId = "342856085028",
                        AcctName = "张宇",
                        AcctType = "1",
                        BankId = "40142",
                        BankName = "中国银行股份有限公司北京人大支行",
                    },
                    TransAmount = 0.01M,
                    TransCur = "RMB",
                    Rate = 1
                },new TransDetail(){
                    ReceipterType = "1",
                    ReciepterIdCode = "130666996689890306",
                    ReciepterIdType = "1",
                    SWIFTCode = "BKCHCNBJ",
                    ToAcct = new Account() {
                        AcctId = "342856085028",
                        AcctName = "张宇",
                        AcctType = "1",
                        BankId = "40142",
                        BankName = "中国银行股份有限公司北京人大支行",
                    },
                    TransAmount = 0.01M,
                    TransCur = "RMB",
                    Rate = 1
                },new TransDetail(){
                    ReceipterType = "1",
                    ReciepterIdCode = "130666996689890306",
                    ReciepterIdType = "1",
                    SWIFTCode = "BKCHCNBJ",
                    ToAcct = new Account() {
                        AcctId = "342856085028",
                        AcctName = "张宇",
                        AcctType = "1",
                        BankId = "40142",
                        BankName = "中国银行股份有限公司北京人大支行",
                    },
                    TransAmount = 0.01M,
                    TransCur = "RMB",
                    Rate = 1
                },new TransDetail(){
                    ReceipterType = "1",
                    ReciepterIdCode = "130666996689890306",
                    ReciepterIdType = "1",
                    SWIFTCode = "BKCHCNBJ",
                    ToAcct = new Account() {
                        AcctId = "342856085028",
                        AcctName = "张宇",
                        AcctType = "1",
                        BankId = "40142",
                        BankName = "中国银行股份有限公司北京人大支行",
                    },
                    TransAmount = 0.01M,
                    TransCur = "RMB",
                    Rate = 1
                }

                }


            };
        }
        /// <summary>
        /// 获取中行接口对公转账
        /// </summary>
        /// <returns></returns>
        private ITranscations GetBOCPubllicToPaymentTrans()
        {
            //交易信息集合
            return new Transcations()
            {
                TransWay = "01",
                BusinessType = "02",

                TranscationItems = new List<ITranscation>() {
                getPublicTranscation(),
                getPublicTranscation(),
                getPublicTranscation()


            }
            };
        }

            private ITranscations GetBOCWagePaymentTrans()
        {
            //交易信息集合
            return new Transcations()
            {
                TransWay = "01",
                BusinessType = "01",

                TranscationItems = new List<ITranscation>() {
                getWageTranscation(),
                getWageTranscation(),
                getWageTranscation()



            }
            };
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

        /// <summary>
        /// BOC构建查询交易请求
        /// </summary>
        /// <returns></returns>
        private ITransferQueryData GetBOCQueryInfo() {
            SerialNumberDapperRepository repository = new SerialNumberDapperRepository();
            return new TransferQueryData()
            {
                ClientId = DateTime.Now.ToString("yyyyMMdd") + DateTime.Now.Millisecond + "001",  
                //ClientId = "",
                EDIId = Instruction.NewInsSid("01") + repository.GetSeqNumber(),
                ObssId = "2016336333",
                StartDate = DateTime.Now.ToString("yyyyMMdd"),
                StartTime = DateTime.Now.ToString("HHmmss") + DateTime.Now.Millisecond
            };
        }




        private ITransferQueryDataList GetBOCQueryInfos() {
            var queryList = new TransferQueryDataList();
            queryList.TransferQueryDatas.Add(GetBOCQueryInfo());
            return queryList;

        }
        /*************************单元测试用例****************************/



        /// <summary>
        /// 测试法兴人民币付款
        /// </summary>
        [TestMethod]
        public void TestSGBRMBPayBankService()
        {
            try
            {
                BankService bankService = new BankService();
                var trans = this.GetSGBRMBTrans();
                var tranJson = Newtonsoft.Json.JsonConvert.SerializeObject(trans);
                //bankService.PaymentTransfer(trans);
                 Console.WriteLine(tranJson);
            }
            catch (Exception ex)
            {

            }

            //bankService.PaymentTransfer(trans);
        }




        /// <summary>
        /// 测试法兴外币付款
        /// </summary>
        [TestMethod]
        public void TestSGBForerignPayBankService()
        {

            BankService bankService = new BankService();
            var trans = this.GetSGBForeignTrans();
            var tranJson = Newtonsoft.Json.JsonConvert.SerializeObject(trans);        
          //  bankService.PaymentTransfer(trans);           
            Console.WriteLine(tranJson);

        }
        
        /// <summary>
        /// 测试法兴行内转账
        /// </summary>
        [TestMethod]
        public void TestSGBInnerPayBankService()
        {
          
            BankService bankService = new BankService();
            var trans = this.GetSGBInnerTrans();
            var tranJson = Newtonsoft.Json.JsonConvert.SerializeObject(trans);
         // bankService.PaymentTransfer(trans);           
            Console.WriteLine(tranJson);
        }

        /// <summary>
        /// 测试中行对公转账
        /// </summary>
        [TestMethod]
        public void TestBOCPublicPaymentBankService()
        {
           

            BankService bankService = new BankService();
            var trans = this.GetBOCPubllicToPaymentTrans();
           var tranJson = Newtonsoft.Json.JsonConvert.SerializeObject(trans);
            //bankService.PaymentTransfer(trans);           
            Console.WriteLine(tranJson);

        }

        /// <summary>
        /// 测试中行工资报销业务
        /// </summary>
        [TestMethod]
        public void TestBOCWageBankService()
        {
            
            BankService bankService = new BankService();
            var trans = this.GetBOCWagePaymentTrans();
            var tranJson = Newtonsoft.Json.JsonConvert.SerializeObject(trans);
            //bankService.PaymentTransfer(trans);           
            Console.WriteLine(tranJson);
        }

        /// <summary>
        /// 测试法兴查询交易结果接口
        /// </summary>
        [TestMethod]
        public void TestSGBQueryBankService()
        {
            BankService service = new BankService();
            // SGBService bankService = new SGBService();
            var trans = GetSGBQueryInfos();
            Console.WriteLine(JsonConvert.SerializeObject(trans));
            //bankService.QueryTransStatus(GetSGBQueryInfos());         
            //service.QueryTransStatus(trans);
        }

        /// <summary>
        /// 测试中行查询交易状态
        /// </summary>
        [TestMethod]
        public void TestBOCQueryBankService()
        {
            BankService service = new BankService();           
            var trans = GetBOCQueryInfos();
            Console.WriteLine(JsonConvert.SerializeObject(trans));
            //bankService.QueryTransStatus(GetSGBQueryInfos());         
            //service.QueryTransStatus(trans);
        }

    }
}

