using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.DataHandle;
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
    public class ForeignCurryPaymentMsg: AbstractSGBTranscation
    {
        public ForeignCurryPaymentMsg()
        {
            this.Head = new CommonHeader();
        }
        
        /// <summary>
        /// 付款方账户名
        /// </summary>
        public string DbAccName { get; set; }

        /// <summary>
        /// 付款币种
        /// </summary>
        public string DbCur { get; set; }

        /// <summary>
        /// 收款人账户名
        /// </summary>
        public string CrAccName { get; set; }
        /// <summary>
        /// 收款人账户类型
        /// </summary>
        public string CrCifType { get; set; }
        /// <summary>
        /// 收款人类型
        /// </summary>
        public string ForeignPayee { get; set; }

        public string BeneSwifCode { get; set; }

        /// <summary>
        /// 收款人开户行名称
        /// </summary>
        public string CrBankName { get; set; }

        /// <summary>
        /// 收费方式
        /// </summary>
        public string Fees { get; set; }

        /// <summary>
        /// 参考汇率
        /// </summary>
        public string Rate { get; set; }

        /// <summary>
        /// 转账币种
        /// </summary>
        public string CrCur { get; set; }

        /// <summary>
        /// 交易金额
        /// </summary>
        public decimal TransAmt { get; set; }

        /// <summary>
        /// 用途
        /// </summary>
        public string WhyUse { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Docket { get; set; }

        /// <summary>
        /// 交易触发方式
        /// </summary>
        public string TranType { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        public string StartDate { get; set; }

        public override bool Check()
        {
            base.Check();
            if (String.IsNullOrEmpty(this.Fees))
                throw new BusinessException("the value of feetype is null") { Code = "1021004" };
            return true;
        }

        public ForeignCurryPaymentMsg Create(ITranscations Transcations)
        {
            if (Transcations.Transcations.Count != 1)
                throw new BusinessException("the lines of transfer info should be one") { Code = "1021011" };
            if(Transcations.Transcations.FirstOrDefault().TransDetail.Count != 1)
                throw new BusinessException("the lines of transfer detail info should be one") { Code = "1021011" };
            ForeignCurryPaymentMsg msg = new ForeignCurryPaymentMsg();
            foreach(var item in Transcations.Transcations)
            {
                msg.Head.CCTransCode = "SGT003";
                msg.Head.ReqSeqNo = item.ClientId;
                msg.Head.ReqDate = item.TransDate;
                //msg.Head.CorpNo = "";
                //msg.Head.OpNo = "";
                //msg.Head.PassWord = "";
                msg.DbAccNo = item.FromAcct.AcctId;
                msg.DbCur = item.PaymentCur;
                foreach (var line in item.TransDetail)
                {
                    msg.CrAccNo = line.ToAcct.AcctId;
                    msg.CrAccName = line.ToAcct.AcctName;
                    msg.CrCifType = line.ToAcct.AcctType;
                    msg.ForeignPayee = line.ReceipterType;
                    msg.BeneSwifCode = line.SWIFTCode;
                    msg.CrBankName = line.ToAcct.BankName;
                    msg.Fees = item.FeeType;
                    msg.Rate = line.Rate;
                    msg.CrCur = line.TransCur;
                    msg.WhyUse = item.Purpose;
                    msg.TransAmt = line.TransAmount;
                }
            }
            return msg;
        }
    }
}
