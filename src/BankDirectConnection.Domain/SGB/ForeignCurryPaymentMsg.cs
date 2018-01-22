using BankDirectConnection.BaseApplication.BaseTranscation;
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
	*	Create by Fancy at 2018/1/10 13:41:38
	===============================================================================================================================*/
    /// <summary>
    /// 外币付款信息
    /// </summary>
    public class ForeignCurryPaymentMsg: AbstractSGBTranscation,IForeignCurryPaymentMsg
    {
        public ForeignCurryPaymentMsg()
        {
            this.Head = new CommonHeader();
        }
        public ForeignCurryPaymentMsg(ITranscation Transcation)
        {
            this.Head = new CommonHeader();
            Create(Transcation);
            this.Check();
        }

        #region property
      

        public string BeneSwifCode { get; set; }


       
        /// <summary>
        /// 参考汇率
        /// </summary>
        public string Rate { get; set; }

     
        #endregion

        public override bool Check()
        {
            base.Check();
            if (String.IsNullOrEmpty(this.Fees))
                throw new BusinessException("the value of feetype is null") { Code = "1021004" };
            // TODO 收款账号不为法兴 且收款币种不为人民币
            if ((!string.IsNullOrEmpty(this.UnionDeptId) && this.UnionDeptId.Length == 12 && this.UnionDeptId.Substring(0, 3) == emBankNo.SG.ToString())
                || (!string.IsNullOrEmpty(this.CrBankName) && this.CrBankName.Contains("兴业银行")))
                throw new InnerException("2021003", "the bank number or bank name of receipter is bad.");
            if (this.CrCur == "RMB")
                throw new InnerException("2021008", "the value of transcur can'not be RMB");
            return true;
        }

        private ForeignCurryPaymentMsg Create(ITranscation Transcation)
        {
            if(Transcation.TransDetail.Count != 1)
                throw new BusinessException("the lines of transfer detail info should be one") { Code = "1021011" };
            this.Head.CCTransCode = "SGT003";
            this.Head.ReqSeqNo = Transcation.ClientId;
            this.Head.ReqDate = Transcation.TransDate;
            this.WhyUse = Transcation.Purpose;
            this.Fees = Transcation.FeeType;
            //msg.Head.CorpNo = "";
            //msg.Head.OpNo = "";
            //msg.Head.PassWord = "";
            if (Transcation.FromAcct.AcctId != null)
            {
                this.DbAccNo = Transcation.FromAcct.AcctId;
            }
            else {
                throw new InnerException("2022002", "Foreign currency trading information can not be empty ");
            }
            this.DbCur = Transcation.PaymentCur;
            foreach (var item in Transcation.TransDetail)
            {
                this.CrAccNo = item.ToAcct.AcctId;
                this.CrAccName = item.ToAcct.AcctName;
                this.CrCifType = item.ToAcct.AcctType;
                this.ForeignPayee = item.ReceipterType;
                this.BeneSwifCode = item.SWIFTCode;
                this.UnionDeptId = item.ToAcct.BankId;
                this.CrBankName = item.ToAcct.BankName;
                this.Rate = item.Rate;
                this.CrCur = item.TransCur;
                this.TransAmt = item.TransAmount;
            }
            return this;
        }

        public List<ForeignCurryPaymentMsg> CreatePayments(ITranscations Transcations)
        {
            List<ForeignCurryPaymentMsg> msgList = new List<ForeignCurryPaymentMsg>();
            foreach (var item in Transcations.Transcations)
            {
                foreach (var line in item.TransDetail)
                {
                    ForeignCurryPaymentMsg msg = new ForeignCurryPaymentMsg();
                    msg.Head.CCTransCode = "SGT003";
                    msg.Head.ReqSeqNo = item.ClientId;
                    msg.Head.ReqDate = item.TransDate;
                    //msg.Head.CorpNo = "";
                    //msg.Head.OpNo = "";
                    //msg.Head.PassWord = "";
                    msg.DbAccNo = item.FromAcct.AcctId;
                    msg.DbCur = item.PaymentCur;
                    msg.CrAccNo = line.ToAcct.AcctId;
                    msg.CrAccName = line.ToAcct.AcctName;
                    msg.CrCifType = line.ToAcct.AcctType;
                    msg.ForeignPayee = line.ReceipterType;
                    msg.BeneSwifCode = line.SWIFTCode;
                    this.UnionDeptId = line.ToAcct.BankId;
                    msg.CrBankName = line.ToAcct.BankName;
                    msg.Fees = item.FeeType;
                    msg.Rate = line.Rate;
                    msg.CrCur = line.TransCur;
                    msg.WhyUse = item.Purpose;
                    msg.TransAmt = line.TransAmount;
                    msg.Check();
                    msgList.Add(msg);
                }
            }
            return msgList;
        }
    }
}
