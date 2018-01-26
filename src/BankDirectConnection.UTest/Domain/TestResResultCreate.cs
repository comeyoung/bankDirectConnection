using BankDirectConnection.Application.BaseTranscation;
using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.BaseApplication.DataHandle;
using BankDirectConnection.Domain.BOC;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.Domain.TransferBO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.UTest.Domain
{
    [TestClass]
    class TestResResultCreate
    {

        #region 构建数据


        private IAccount getFromAcct()
        {
            IAccount FromAcct = new Account();
            FromAcct.AcctId = "6212236969989366658";
            FromAcct.AcctName = "张三";
            FromAcct.AcctType = "0";
            FromAcct.BankId = "01040000";
            FromAcct.BankName = "中国银行";
            return FromAcct;
        }
        private ITranscation getTranscation()
        {
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
        private ResponseMsg resMsg() {
                          
            return new ResponseMsg() {
                Serverdt = "jiah1234",
                Token = "dsfd5f5d4f6ds",
                
                DetailResponses = new List<DetailResponse> {

                }
            };
        }

        private ITranscations WageAndReimbursementTranscations()
        {
            return new Transcations()
            {
                BusinessType = "01",
                TransWay = "网银",
                TranscationItems = new List<ITranscation>() {
                getTranscation()
            }
            };

        }
        #endregion
        /// <summary>
        /// 中行测试
        /// </summary>
        [TestMethod]
        public void TestBOCreate() {
         
            
        }

        /// <summary>
        /// 法兴测试
        /// </summary>
        [TestMethod]
        public void TestSGCreate()
        {
            ResResult result = new ResResult();

        }
    }
}
