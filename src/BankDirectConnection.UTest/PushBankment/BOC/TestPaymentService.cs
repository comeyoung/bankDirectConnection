
using BankDirectConnection.Application.BaseTranscation;
using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.BaseApplication.DataHandle;
using BankDirectConnection.Domain.TransferBO;
using BankDirectConnection.PushBankment.BankTransfer;
using BankDirectConnection.PushBankment.BOCService.Service;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.UTest.PushBankment.BOC
{
    [TestClass]
    public class TestPaymentService
    {
        #region 构建测试数据
        /// <summary>
        /// 付款人信息
        /// </summary>
        /// <returns></returns>
        private IAccount getFromAcct() {
            IAccount FromAcct = new Account();
            FromAcct.AcctId = "6212236969989366658";
            FromAcct.AcctName = "张三";
            FromAcct.AcctType = "0";
            FromAcct.BankId = "01040000";
            FromAcct.BankName = "中国银行";
            return FromAcct;
        }

        /// <summary>
        /// 单条交易信息
        /// </summary>
        /// <returns></returns>
        private ITranscation getTranscation() {
            return new Transcation()
            {
                AgentSign = "qqq",
                ClientId = "136137138139",
                EDIId = "18012466667777888899",
                Comments = "薪水",
                FeeAcct = "6212236969989366658",
                FeeType = "1",
                FromAcct = getFromAcct(),
                PaymentCur = "RMB",
                BusinessType = "02",
                PaymentType = "1",
                Priority = emPriolv.Urgent,
                Purpose = "薪水",
                TransDate = "20160708",
                TransTime = "142020",
                TransWay = "网银",
                TransDetail = new List<ITransDetail>() {
                new TransDetail(){
                    ReceipterType = "1",
                    ReciepterIdCode = "130666996689890306",
                    ReciepterIdType = "1",
                    SWIFTCode = "BKCHCNBJ",
                    ToAcct = new Account() {
                        AcctId = "7621223967989366658",
                        AcctName = "王六",
                        AcctType = "0",
                        BankId = "01020000",
                        BankName = "中国银行",
                    },
                    TransAmount = 10000.00M,
                    TransCur = "RMB",
                    Rate = 1
                }, new TransDetail(){
                    ReceipterType = "1",
                    ReciepterIdCode = "130666996689890306",
                    ReciepterIdType = "1",
                    SWIFTCode = "BKCHCNBJ",
                    ToAcct = new Account() {
                        AcctId = "7621223967989366658",
                        AcctName = "王六",
                        AcctType = "0",
                        BankId = "01020000",
                        BankName = "中国银行",
                    },
                    TransAmount = 10000.00M,
                    TransCur = "RMB",
                    Rate = 1
                }, new TransDetail(){
                    ReceipterType = "1",
                    ReciepterIdCode = "130666996689890306",
                    ReciepterIdType = "1",
                    SWIFTCode = "BKCHCNBJ",
                    ToAcct = new Account() {
                        AcctId = "7621223967989366658",
                        AcctName = "王六",
                        AcctType = "0",
                        BankId = "01020000",
                        BankName = "中国银行",
                    },
                    TransAmount = 10000.00M,
                    TransCur = "RMB",
                    Rate = 1
                }

        }
            };
        }
        private ITranscations PublicTranscations() {
            //交易信息集合
            return new Transcations()
            {          
                TransWay = "01",
                BusinessType = "02",               
                Transcations = new List<ITranscation>() {
                getTranscation(),
                getTranscation()
            }
            };                   
        }

        private ITranscations WageAndReimbursementTranscations()
        {
            return new Transcations()
            {
                BusinessType = "01",
                TransWay = "网银",
                Transcations = new List<ITranscation>() {
                getTranscation()
            }
            };

        }


        /// <summary>
        /// 对公转账测试
        /// </summary>
        [TestMethod]
        public void TestPaymentsToPublicService()
        {
            PaymentsToPublicService service = new PaymentsToPublicService();
            BOCService BOCservice = new BOCService(null, service, null);
            var rt = BOCservice.PaymentTransfer(PublicTranscations());
            Assert.IsNotNull(rt);
            Console.WriteLine(rt.Status.RspMsg);
            Assert.AreEqual("0", rt.Status.RspCod);

        }

        /// <summary>
        /// 工资代发测试
        /// </summary>
        [TestMethod]      
        public void TestWageAndReimbursementService()
        {

            WageAndReimbursementService service = new WageAndReimbursementService();
            BOCService BOCservice = new BOCService(service, null, null);
            var rt = BOCservice.PaymentTransfer(WageAndReimbursementTranscations());
            Assert.IsNotNull(rt);
            Console.WriteLine(rt.Status.RspCod);
            Assert.AreEqual("0", rt.Status.RspCod);
        }
        #endregion
    }
}
