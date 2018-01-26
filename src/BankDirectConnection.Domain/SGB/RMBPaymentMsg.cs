using BankDirectConnection.Application.BaseTranscation;
using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.BaseApplication.DataHandle;
using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.DataHandle;
using BankDirectConnection.Domain.SGB.PaymentMsg;
using BankDirectConnection.Domain.TransferBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.SGB
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 13:34:15
	===============================================================================================================================*/
    /// <summary>
    /// 人名币付款账单
    /// </summary>
    public class RMBPaymentMsg: AbstractSGBTranscation ,IRMBPaymentMsg
    {
        public RMBPaymentMsg()
        {
            this.Head = new CommonHeader();
        }

        public RMBPaymentMsg(ITranscation Transcation)
        {
            this.Head = new CommonHeader();
            this.Create(Transcation);
            this.Check();
        }

        #region property

       

        

        /// <summary>
        /// 加急标志
        /// </summary>
        public emPriolv Priority { get; set; }

        

        #endregion

        public override bool Check()
        {
            base.Check();
            // TODO 收款人账号不为兴业银行，并且收款币种为人民币
            if (Account.IsSG(this.UnionDeptId))
                throw new InnerException("2021003", "the bank number or bank name of receipter is bad.");
            if ( this.CrCur != "CNY" && this.CrCur != "RMB")
                throw new InnerException("2021008", "the value of transcur can not be right");
            return true;
        }

        public  RMBPaymentMsg Create(ITranscation Transcation)
        {

            if (Transcation.TransDetail.Count != 1)
                throw new BusinessException("the lines of transfer detail info should be one") { Code = "1021011" };
            this.Head.CCTransCode = "SGT002";
            this.Head.ReqSeqNo = Transcation.ClientId;
            this.Head.ReqDate = Transcation.TransDate;
            this.Head.ReqTime = Transcation.TransTime;       
            this.Priority = Transcation.Priority;
            this.WhyUse = Transcation.Purpose;
            this.ClientId = Transcation.ClientId;
            this.EDIId = Transcation.EDIId;
            
            //msg.Head.CorpNo = "";
            //msg.Head.OpNo = "";
            //msg.Head.PassWord = "";
            this.DbAccNo = Transcation.FromAcct.AcctId;
            
            this.DbAccName = Transcation.FromAcct.AcctName;
            this.DbCur = Transcation.PaymentCur;
            foreach (var item in Transcation.TransDetail)
            {
                this.CrAccNo = item.ToAcct.AcctId;
                this.CrAccName = item.ToAcct.AcctName;
                this.CrCifType = item.ToAcct.AcctType;
                this.TranType = "0";//实时
                this.ForeignPayee = item.ReceipterType;
                this.CrBankName = item.ToAcct.BankName;
                this.UnionDeptId = item.ToAcct.BankId;
                this.CrCur = item.TransCur;           
                this.TransAmt = item.TransAmount;
                
                //this.StartDate = Transcation.TransDate;
                //this.StartTime = Transcation.TransTime;
            }
            return this;
        }

        public List<RMBPaymentMsg> CreatePayments(ITranscations Transcations)
        {
            List<RMBPaymentMsg> msgList = new List<RMBPaymentMsg>();
            foreach (var item in Transcations.TranscationItems)
            {
                // 以明细为标准 转换为人民币付款
                foreach (var line in item.TransDetail)
                {
                    RMBPaymentMsg msg = new RMBPaymentMsg();
                    msg.Head.CCTransCode = "SGT002";
                    msg.Head.ReqSeqNo = item.ClientId;
                    msg.Head.ReqDate = item.TransDate;
                    //msg.Head.CorpNo = "";
                    //msg.Head.OpNo = "";
                    //msg.Head.PassWord = "";
                    msg.DbAccNo = item.FromAcct.AcctId;
                    msg.DbAccName = item.FromAcct.AcctName;
                    msg.DbCur = item.PaymentCur;
                    msg.CrAccNo = line.ToAcct.AcctId;
                    msg.CrAccName = line.ToAcct.AcctName;
                    msg.CrCifType = line.ToAcct.AcctType;
                    msg.TranType = "0";//实时
                    msg.ForeignPayee = line.ReceipterType;
                    msg.CrBankName = line.ToAcct.BankName;
                    msg.UnionDeptId = line.ToAcct.BankId;
                    msg.Priority = item.Priority;
                    msg.WhyUse = item.Purpose;
                    msg.CrCur = line.TransCur;
                    msg.TransAmt = line.TransAmount;
                    msg.Check();//数据校验成功
                    msgList.Add(msg);
                }
            }
            return msgList;
        }
    }
}
