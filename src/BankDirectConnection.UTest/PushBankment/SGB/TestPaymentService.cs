using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using BankDirectConnection.PushBankment.SGBService.Service;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.BaseApplication.BaseTranscation;
using System.Collections.Generic;
using BankDirectConnection.PushBankment.BankTransfer;
using BankDirectConnection.IPushBankment.Service.SGB;
using BankDirectConnection.Domain.TransferBO;
using BankDirectConnection.Application.BaseTranscation;
using BankDirectConnection.Domain.SGB;
using BankDirectConnection.PushBankment.SGBService;

namespace BankDirectConnection.UTest.PushBankment.SGB
{
    [TestClass]
    public class TestPaymentService
    {
        #region 构建测试数据
        #region 构建账户数据
        /// <summary>
        /// 中行人民币收款账户
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// 中行外币收款账户
        /// </summary>
        private IAccount GetForeignToAccout()
        {
            return new Account()
            {
                BankId = "104112341234",
                BankName = "中国银行某某支行",
                AcctId = "6212230306070826699",
                AcctName = "李博",
                AcctType = "0"
            };
        }
        /// <summary>
        /// 法兴银行收款账户
        /// </summary>
        private IAccount GetInnerToAccout()
        {
            return new Account()
            {
                BankId = "309366667777",
                BankName = "兴业银行某某支行",
                AcctId = "66633982569866532121",
                AcctName = "Jack",
                AcctType = "1"
            };
        }
        /// <summary>
        /// 法兴银行付款人
        /// </summary>
        private IAccount GetOnlyForeignAccount()
        {
            return new Account()
            {
                BankId = "309691581000",
                BankName = "法兴银行",
                AcctId = "3633360308092736677",
                AcctName = "Jerry",
                AcctType = "1"
            };
        }


        #endregion
        #region 构建交易信息
        /// <summary>
        /// 外币交易信息
        /// </summary>
        /// <returns></returns>
        private ITranscations GetForeignSGBTrans()
        {

            return new Transcations()
            {
                TransWay = "02",
                BusinessType = "01",
                Transcations = new List<ITranscation>()
                {
                    new Transcation(){
                        ClientId = "332de889949",
                        TransWay = "1",
                        BusinessType = "0",
                        PaymentCur = "USD",
                        PaymentType = "1",
                        Purpose = "转账",
                        Priority = "是",
                        TransDate = "20160708",
                        TransTime = "162323",
                        FeeType = "1",
                        FeeAcct = "13696858585",
                        AgentSign = "b1362",
                        Comments = "转",
                        FromAcct = GetOnlyForeignAccount(),
                        TransDetail = new List<ITransDetail>()
                        {
                            //外币付款
                            new TransDetail()
                            {
                                ToAcct= GetForeignToAccout(),
                                ReciepterIdType = "0",
                                ReciepterIdCode = "111222333666555",
                                ReceipterType = "1",
                                TransAmount = 10000,
                                TransCur = "USD",
                                SWIFTCode = "qwe123456",
                                Rate = "1"
                            }

                        }

                     }

                }
            };
        }

        /// <summary>
        /// 人民币交易信息
        /// </summary>
        private ITranscations GetRMBSGBTrans()
        {
            return new Transcations()
            {
                TransWay = "02",
                BusinessType = "02",
                Transcations = new List<ITranscation>()
                {
                    new Transcation(){
                        ClientId = "2018012000112321",
                        TransWay = "1",
                        BusinessType = "0",
                        PaymentCur = "CNY",
                        PaymentType = "1",
                        Purpose = "转账",
                        Priority = "是",
                        TransDate = "20160708",
                        TransTime = "162323",
                        FeeType = "1",
                        FeeAcct = "13696858585",
                        AgentSign = "b1362",
                        Comments = "转账",
                        FromAcct = GetOnlyForeignAccount(),
                        TransDetail = new List<ITransDetail>()
                        {
                            
                            //人名币付款
                            new TransDetail()
                            {
                                ToAcct= GetRMBToAccout(),
                                ReciepterIdType = "0",
                                ReciepterIdCode = "111222333666555",
                                ReceipterType = "1",
                                TransAmount = 10000,
                                TransCur = "RMB",
                                SWIFTCode = "qwe123456",
                                Rate = "1"
                            }

                        }

                     }

                }
            };

        }

        /// <summary>
        /// 行内转账交易信息
        /// </summary>
        private ITranscations GetInnerSGBTrans()
        {
            return new Transcations()
            {
                TransWay = "02",
                BusinessType = "02",
                Transcations = new List<ITranscation>()
                {
                    new Transcation(){
                        ClientId = "2018012000112321",
                        TransWay = "1",
                        BusinessType = "0",
                        PaymentCur = "CNY",
                        PaymentType = "1",
                        Purpose = "转账",
                        Priority = "是",
                        TransDate = "20160708",
                        TransTime = "162323",
                        FeeType = "1",
                        FeeAcct = "13696858585",
                        AgentSign = "b1362",
                        Comments = "转账",
                        FromAcct = GetOnlyForeignAccount(),
                        TransDetail = new List<ITransDetail>()
                        {
                            
                            //行内转账
                            new TransDetail()
                            {
                                ToAcct= GetInnerToAccout(),
                                ReciepterIdType = "0",
                                ReciepterIdCode = "111222333666555",
                                ReceipterType = "1",
                                TransAmount = 10000,
                                TransCur = "RMB",
                                SWIFTCode = "qwe123456",
                                Rate = "1"
                            }

                        }

                     }

                }
            };
        }

        /// <summary>
        /// 批量明细交易信息
        /// </summary>
        private ITranscations GetBatchSGBTrans()
        {
            return new Transcations()
            {
                TransWay = "02",
                BusinessType = "02",
                Transcations = new List<ITranscation>()
                {
                    new Transcation(){
                        ClientId = "2018012000112321",
                        TransWay = "1",
                        BusinessType = "0",
                        PaymentCur = "CNY",
                        PaymentType = "1",
                        Purpose = "转账",
                        Priority = "是",
                        TransDate = "20160708",
                        TransTime = "162323",
                        FeeType = "1",
                        FeeAcct = "13696858585",
                        AgentSign = "b1362",
                        Comments = "转账",
                        FromAcct = GetOnlyForeignAccount(),
                        TransDetail = new List<ITransDetail>()
                        {
                            
                            //行内转账
                            new TransDetail()
                            {
                                ToAcct= GetInnerToAccout(),
                                ReciepterIdType = "0",
                                ReciepterIdCode = "111222333666555",
                                ReceipterType = "1",
                                TransAmount = 5000,
                                TransCur = "RMB",
                                SWIFTCode = "SGCLCNBJ",
                                Rate = "1"
                            },
                            new TransDetail()
                            {
                                ToAcct= GetInnerToAccout(),
                                ReciepterIdType = "0",
                                ReciepterIdCode = "111222333666555",
                                ReceipterType = "1",
                                TransAmount = 9000,
                                TransCur = "RMB",
                                SWIFTCode = "SGCLCNBJ",
                                Rate = "1"
                            },
                            new TransDetail()
                            {
                                ToAcct= GetInnerToAccout(),
                                ReciepterIdType = "0",
                                ReciepterIdCode = "111222333666555",
                                ReceipterType = "1",
                                TransAmount = 10000,
                                TransCur = "RMB",
                                SWIFTCode = "SGCLCNBJ",
                                Rate = "1"
                            }

                        }

                     }

                }
            };
        }

        /// <summary>
        /// 批量付款交易信息
        /// </summary>
        private ITranscations GetBatchPaymentSGBTrans()
        {
            return new Transcations()
            {
                TransWay = "02",
                BusinessType = "02",
                Transcations = new List<ITranscation>()
                {
                    new Transcation(){
                        ClientId = "2018012000112321",
                        TransWay = "1",
                        BusinessType = "0",
                        PaymentCur = "CNY",
                        PaymentType = "1",
                        Purpose = "转账",
                        Priority = "是",
                        TransDate = "20160708",
                        TransTime = "162323",
                        FeeType = "1",
                        FeeAcct = "13696858585",
                        AgentSign = "b1362",
                        Comments = "转账",
                        FromAcct = GetOnlyForeignAccount(),
                        TransDetail = new List<ITransDetail>()
                        {
                            
                            //行内转账
                            new TransDetail()
                            {
                                ToAcct= GetInnerToAccout(),
                                ReciepterIdType = "0",
                                ReciepterIdCode = "111222333666555",
                                ReceipterType = "1",
                                TransAmount = 5000,
                                TransCur = "RMB",
                                SWIFTCode = "SGCLCNBJ",
                                Rate = "1"
                            }

                        }

                     },new Transcation(){
                        ClientId = "2018012000116661",
                        TransWay = "1",
                        BusinessType = "0",
                        PaymentCur = "CNY",
                        PaymentType = "1",
                        Purpose = "转账",
                        Priority = "是",
                        TransDate = "20160708",
                        TransTime = "162323",
                        FeeType = "1",
                        FeeAcct = "13696858585",
                        AgentSign = "b1362",
                        Comments = "转账",
                        FromAcct = GetOnlyForeignAccount(),
                        TransDetail = new List<ITransDetail>()
                        {
                            
                            //行内转账
                            new TransDetail()
                            {
                                ToAcct= GetInnerToAccout(),
                                ReciepterIdType = "0",
                                ReciepterIdCode = "111222333666555",
                                ReceipterType = "1",
                                TransAmount = 5000,
                                TransCur = "RMB",
                                SWIFTCode = "SGCLCNBJ",
                                Rate = "1"
                            }

                        }

                }, new Transcation(){
                        ClientId = "2018012000112321",
                        TransWay = "1",
                        BusinessType = "0",
                        PaymentCur = "CNY",
                        PaymentType = "1",
                        Purpose = "转账",
                        Priority = "是",
                        TransDate = "20160708",
                        TransTime = "162323",
                        FeeType = "1",
                        FeeAcct = "13696858585",
                        AgentSign = "b1362",
                        Comments = "转账",
                        FromAcct = GetOnlyForeignAccount(),
                        TransDetail = new List<ITransDetail>()
                        {
                            
                            //行内转账
                            new TransDetail()
                            {
                                ToAcct= GetInnerToAccout(),
                                ReciepterIdType = "0",
                                ReciepterIdCode = "111222333666555",
                                ReceipterType = "1",
                                TransAmount = 5000,
                                TransCur = "RMB",
                                SWIFTCode = "SGCLCNBJ",
                                Rate = "1"
                            }

                        }

                     }
            }

            };
        }

        /// <summary>
        /// 批量付款,明细交易信息
        /// </summary>
        private ITranscations GetBatchPaymentAndDetailSGBTrans()
        {
            return new Transcations()
            {
                TransWay = "02",
                BusinessType = "02",
                Transcations = new List<ITranscation>()
                {
                    new Transcation(){
                        ClientId = "2018012000112321",
                        TransWay = "1",
                        BusinessType = "0",
                        PaymentCur = "CNY",
                        PaymentType = "1",
                        Purpose = "转账",
                        Priority = "是",
                        TransDate = "20160708",
                        TransTime = "162323",
                        FeeType = "1",
                        FeeAcct = "13696858585",
                        AgentSign = "b1362",
                        Comments = "转账",
                        FromAcct = GetOnlyForeignAccount(),
                        TransDetail = new List<ITransDetail>()
                        {
                            
                            //行内转账
                            new TransDetail()
                            {
                                ToAcct= GetInnerToAccout(),
                                ReciepterIdType = "0",
                                ReciepterIdCode = "111222333666555",
                                ReceipterType = "1",
                                TransAmount = 5000,
                                TransCur = "RMB",
                                SWIFTCode = "SGCLCNBJ",
                                Rate = "1"
                            },new TransDetail()
                            {
                                ToAcct= GetInnerToAccout(),
                                ReciepterIdType = "0",
                                ReciepterIdCode = "111222333666555",
                                ReceipterType = "1",
                                TransAmount = 5000,
                                TransCur = "RMB",
                                SWIFTCode = "SGCLCNBJ",
                                Rate = "1"
                            }

                        }

                     },new Transcation(){
                        ClientId = "2018012000116661",
                        TransWay = "1",
                        BusinessType = "0",
                        PaymentCur = "CNY",
                        PaymentType = "1",
                        Purpose = "转账",
                        Priority = "是",
                        TransDate = "20160708",
                        TransTime = "162323",
                        FeeType = "1",
                        FeeAcct = "13696858585",
                        AgentSign = "b1362",
                        Comments = "转账",
                        FromAcct = GetOnlyForeignAccount(),
                        TransDetail = new List<ITransDetail>()
                        {
                            
                            //行内转账
                            new TransDetail()
                            {
                                ToAcct= GetInnerToAccout(),
                                ReciepterIdType = "0",
                                ReciepterIdCode = "111222333666555",
                                ReceipterType = "1",
                                TransAmount = 5000,
                                TransCur = "RMB",
                                SWIFTCode = "SGCLCNBJ",
                                Rate = "1"
                            },new TransDetail()
                            {
                                ToAcct= GetInnerToAccout(),
                                ReciepterIdType = "0",
                                ReciepterIdCode = "111222333666555",
                                ReceipterType = "1",
                                TransAmount = 5000,
                                TransCur = "RMB",
                                SWIFTCode = "SGCLCNBJ",
                                Rate = "1"
                            }

                        }

                }
            }

            };
        }
        #endregion
        #endregion
        #region 分类测试用例


        [TestMethod]
        /// <summary>
        /// 收款账户为中行，收款币种为外币
        /// 外币付款响应成功（单条通过）
        /// </summary>
        public void TestForeignCurryPayment()
        {
            //外币付款正确响应
            IForeignCurryPaymentService service = new ForeignCurryTransferService();           
            var SGBService = new SGBService(service, null, null,null);
            var rt = SGBService.PaymentTransfer(GetForeignSGBTrans());
            Assert.IsNotNull(rt);
            Console.WriteLine(rt.Status.RspMsg);
            Assert.AreEqual("0", rt.Status.RspCod);

        }

        [TestMethod]
        /// <summary>
        /// 收款账户为中行，收款币种为人民币
        /// 人民币付款响应成功（单条通过）
        /// </summary>
        public void TestRMBPayment()
        {
            IRMBPaymentService service = new RMBTransferService();
            var SGBService = new SGBService(null, null, service,null);
            var rt = SGBService.PaymentTransfer(GetRMBSGBTrans());
            Assert.IsNotNull(rt);
            Console.WriteLine(rt.Status.RspMsg);
            Assert.AreEqual("0", rt.Status.RspCod);
            
        }

        [TestMethod]
        /// <summary>
        /// 收款账户为法兴
        /// 行内转账响应成功（单条通过）
        /// </summary>
        public void TestInnerPayment()
        {
            IInnerPaymentService service = new InnerTransferService();         
            var SGBService = new SGBService(null,service, null,null);
            var rt = SGBService.PaymentTransfer(GetInnerSGBTrans());
            Assert.IsNotNull(rt);
            Console.WriteLine(rt.Status.RspMsg);
            Assert.AreEqual("0",rt.Status.RspCod);

        }

        [TestMethod]
        /// <summary>
        /// 批量明细，行内转账（TransDetail）
        /// 多个收款人，由于交易明细只能一行，因此会出现空指针异常
        /// </summary>
        public void TestBatchDetail()
        {
            IInnerPaymentService service = new InnerTransferService();
            var SGBService = new SGBService(null, service, null,null);
            var rt = SGBService.PaymentTransfer(GetBatchSGBTrans());
            Assert.IsNotNull(rt);
            Console.WriteLine(rt.Status.RspMsg);
            Assert.AreEqual("0", rt.Status.RspCod);

        }

        [TestMethod]
        /// <summary>
        /// 批量付款，行内转账（Transcation）
        /// 多个付款人，一个收款人，测试通过
        /// </summary>
        public void TestBatchPayment()
        {
            IInnerPaymentService service = new InnerTransferService();
            var SGBService = new SGBService(null, service, null);
            var rt = SGBService.PaymentTransfer(GetBatchPaymentSGBTrans());
            Assert.IsNotNull(rt);
            Console.WriteLine(rt.Status.RspMsg);
            Assert.AreEqual("0", rt.Status.RspCod);

        }

        [TestMethod]
        /// <summary>
        /// 批量付款，批量明细，行内转账（Transcation）
        /// 多个付款人，多个收款人
        /// </summary>
        public void TestBatchPaymentAndDetail()
        {
            IInnerPaymentService service = new InnerTransferService();
            var SGBService = new SGBService(null, service, null);
            var rt = SGBService.PaymentTransfer(GetBatchPaymentSGBTrans());
            Assert.IsNotNull(rt);
            Console.WriteLine(rt.Status.RspMsg);
            Assert.AreEqual("0", rt.Status.RspCod);

        }
        #endregion
    }
}
