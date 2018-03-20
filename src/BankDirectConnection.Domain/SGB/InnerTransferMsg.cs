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
	*	Create by Fancy at 2018/1/10 13:51:23
	===============================================================================================================================*/
    /// <summary>
    /// 行内转账
    /// </summary>
    public class InnerTransferMsg: AbstractSGBTranscation,IInnerTransferMsg
    {
        public InnerTransferMsg()
        {
            this.Head = new CommonHeader();
        }

        public InnerTransferMsg(ITranscation Transcations)
        {
            this.Head = new CommonHeader();
            this.Create(Transcations);
            this.Check();
        }

        #region property
       


        /// <summary>
        /// 收款人省市代码
        /// </summary>
        public string CrProv { get; set; }
       

        #endregion

        public override bool Check()
        {
            base.Check();
            // TODO 收款人账号为兴业银行
            if (!Account.IsSG(this.UnionDeptId))
                throw new InnerException("2021003", "the bank number of receipter is bad.");
            return true;
        }

        private InnerTransferMsg Create(ITranscation Transcation)
        {
            //保证交易明细中只有一笔
            if (Transcation.TransDetail.Count != 1)
                throw new BusinessException("the lines of transfer detail info should be one") { Code = "1021011" };
            this.Head.CCTransCode = "SGT003";
            this.Head.ReqSeqNo = Transcation.EDIId;
            this.Head.ReqDate = Transcation.TransDate;
            this.Head.ReqTime = Transcation.TransTime + "000";
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
                this.UnionDeptId = item.ToAcct.BankId;
                this.CrBankName = item.ToAcct.BankName;
                this.CrAccNo = item.ToAcct.AcctId;
                this.CrAccName = item.ToAcct.AcctName;
                this.CrCifType = item.ToAcct.AcctType;
                this.TranType = "0";//实时
                this.WhyUse = Transcation.Purpose;
                this.CrCur = item.TransCur;
                this.TransAmt = item.TransAmount;
            }
            return this;
        }

        public List<InnerTransferMsg> CreatePayments(ITranscations Transcations)
        {
            List<InnerTransferMsg> msgList = new List<InnerTransferMsg>();
            foreach (var item in Transcations.TranscationItems)
            {
                
                foreach (var line in item.TransDetail)
                {
                    InnerTransferMsg msg = new InnerTransferMsg();
                    msg.Head.CCTransCode = "SGT001";
                    msg.Head.ReqSeqNo = item.EDIId;
                    msg.Head.ReqDate = item.TransDate;
                    msg.Head.ReqTime = item.TransTime;
                    //msg.Head.CorpNo = "";
                    //msg.Head.OpNo = "";
                    //msg.Head.PassWord = "";
                    
                    msg.DbAccNo = item.FromAcct.AcctId;
                    msg.DbAccName = item.FromAcct.AcctName;
                    msg.DbCur = item.PaymentCur;
                    msg.CrAccNo = line.ToAcct.AcctId;
                    msg.CrAccName = line.ToAcct.AcctName;
                    msg.UnionDeptId = line.ToAcct.BankId;
                    msg.CrBankName = line.ToAcct.BankName;
                    msg.CrCifType = line.ToAcct.AcctType;
                    msg.TranType = "0";//实时
                    msg.WhyUse = item.Purpose;
                    msg.CrCur = line.TransCur;
                    msg.TransAmt = line.TransAmount;
                    msg.Check();
                    msgList.Add(msg);
                }
            }
            return msgList;
        }
    }
}
