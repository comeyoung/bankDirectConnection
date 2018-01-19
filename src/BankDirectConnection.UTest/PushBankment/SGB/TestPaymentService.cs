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

namespace BankDirectConnection.UTest.PushBankment.SGB
{
    [TestClass]
    public class TestPaymentService
    {
        /// <summary>
        /// 获取失败结果
        /// </summary>
        /// <returns></returns>
        private IResResult GetFailedResResult()
        {
            return new ResResult()
            {
                Status = new Status() { RspCod = "100", RspMsg = "faild" },
                Response = new List<IResponse>() {
                new Response(){ Status =  new Status() { RspCod = "0",RspMsg = "successful"},ClientId = "2018011900112321",InsId = Guid.NewGuid().ToString(),ObssId = "1000001"},
                new Response(){ Status =  new Status() { RspCod = "0",RspMsg = "successful"},ClientId = "2018011900112321",InsId = Guid.NewGuid().ToString(),ObssId = "1000001"},
                new Response(){ Status =  new Status() { RspCod = "100",RspMsg = "error"}}
                }
            };
        }

        /// <summary>
        /// 获取成功结果
        /// </summary>
        /// <returns></returns>
        private IResResult GetSuccessfulResResult()
        {
            return new ResResult()
            {
                Status = new Status() { RspCod = "0", RspMsg = "Successful" },
                Response = new List<IResponse>() {
                new Response(){ Status =  new Status() { RspCod = "0",RspMsg = "successful"},ClientId = "2018012000112321",InsId = Guid.NewGuid().ToString(),ObssId = "1000001"},
                new Response(){ Status =  new Status() { RspCod = "0",RspMsg = "successful"},ClientId = "2018012000112321",InsId = Guid.NewGuid().ToString(),ObssId = "1000001"},
                new Response(){ Status =  new Status() { RspCod = "0",RspMsg = "successful"},ClientId = "2018012000112321",InsId = Guid.NewGuid().ToString(),ObssId = "1000001"}
                }
            };
        }

        private ITranscations GetSGBTrans()
        {
            return new Transcations()
            {
                TransWay = "02",
                BusinessType = "02",
                Transcations = new List<ITranscation>()
                {
                    new Transcation(){
                        ClientId = "2018012000112321",
                        TransDetail = new List<ITransDetail>()
                        {
                            //行内转账
                            new TransDetail()
                            {

                            },
                            //人名币付款
                            new TransDetail()
                            {

                            },
                            //外币付款
                            new TransDetail()
                            {

                            }
                        }
                    }

                }
            };
        }

        [TestMethod]
        public void TestMethod1()
        {
        }

        [TestMethod]
        public void TestForeignCurryPayment()
        {
            //mock外币转账服务
            var mockForeignService = new Mock<IForeignCurryPaymentService>();
            // mock外币转账服务的结果
            mockForeignService.Setup(x => x.PushPaymentTranscationInfo(null)).Returns(GetFailedResResult());

            //mock人民币转账服务
            var mockRMBService = new Mock<IRMBPaymentService>();
            // mock人民币转账服务的结果
            mockRMBService.Setup(x => x.PushPaymentTranscationInfo(null)).Returns(GetSuccessfulResResult());

            //mock行内转账服务
            var mockInnerService = new Mock<IInnerPaymentService>();
            // mock行内转账服务的结果
            mockInnerService.Setup(x => x.PushPaymentTranscationInfo(null)).Returns(GetSuccessfulResResult());

            var SGBService = new SGBService(mockForeignService.Object, mockInnerService.Object, mockRMBService.Object);

            var rt = SGBService.PaymentTransfer(GetSGBTrans());
            Assert.IsNotNull(rt);
            Assert.AreEqual(0, rt.Status.RspCod);
            
        }
    }
}
