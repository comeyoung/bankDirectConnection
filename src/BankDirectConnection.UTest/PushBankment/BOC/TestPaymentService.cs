
using BankDirectConnection.Application.BaseTranscation;
using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.Domain.TransferBO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.UTest.PushBankment.BOC
{
    [TestClass]
    class TestPaymentService
    {
        #region 构建测试数据
        private ITranscations Transcations() {
            ITranscations Transcations = new Transcations();
            ITranscation Transcation = new Transcation();
            IAccount FromAcct = new Account();
            ITransDetail TransDetail = new TransDetail();
            TransDetail.ReceipterType = "";
            TransDetail.ReciepterIdCode = "";
            TransDetail.ReciepterIdType = "";
            TransDetail.SWIFTCode = "";
            TransDetail.ToAcct = null;
            TransDetail.TransAmount = 10000;
            TransDetail.TransCur = "RMB";

            FromAcct.AcctId = "6212236969989366658";
            FromAcct.AcctName = "张三";
            FromAcct.AcctType = "0";
            FromAcct.BankId = "01040000";
            FromAcct.BankName = "中国银行";
            Transcations.BusinessType = "02";
            Transcations.TransWay = "网银";
            Transcation.AgentSign = "qqq";
            Transcation.ClientId = "136137138139";
            Transcation.Comments = "薪水";
            Transcation.FeeAcct = "6212236969989366658";
            Transcation.FeeType = "1";
            Transcation.FromAcct.AcctId = "8936665872122369699";
            Transcation.FromAcct.AcctName = "李四";
            Transcation.FromAcct.AcctType = "0";
            Transcation.FromAcct.BankId = "02060000";
            Transcation.FromAcct.BankName = "中国建设银行某某支行";
            Transcation.PaymentCur = "RMB";
            Transcation.PaymentType = "1";
            Transcation.Priority = "是";
            Transcation.Purpose = "薪水";
            Transcation.TransDate = "20160708";
            Transcation.TransDetail = null;
            Transcation.TransTime = "142020";
            Transcation.TransWay= "网银";





            Transcations.Transcations.Add();           
            return Transcations;
        }
        #endregion



        #region 分类测试用例

        #endregion
    }
}
