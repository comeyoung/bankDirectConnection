﻿using BankDirectConnection.BaseApplication.BaseTranscation;
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
        /// 付款方账户名
        /// </summary>
        public string DbAccName { get; set; }

        /// <summary>
        /// 付款币种
        /// </summary>
        public string DbCur { get; set; }

        /// <summary>
        /// 收款人开户行行号
        /// </summary>
        public string UnionDeptId { get; set; }

        /// <summary>
        /// 收款人开户行名称
        /// </summary>
        public string CrBankName { get; set; }


        /// <summary>
        /// 收款人账户名
        /// </summary>
        public string CrAccName { get; set; }
        /// <summary>
        /// 收款人省市代码
        /// </summary>
        public string CrProv { get; set; }
        /// <summary>
        /// 收款人账户类型
        /// </summary>
        public string CrCifType { get; set; }
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

        #endregion

        public override bool Check()
        {
            base.Check();
            // TODO 收款人账号为兴业银行
            if (this.UnionDeptId.Length == 12 && this.UnionDeptId.Substring(0, 3) != emBankNo.SG.ToString())
                throw new InnerException("2021003", "the bank number of receipter is bad.");
            return true;
        }

        private InnerTransferMsg Create(ITranscation Transcation)
        {
            //保证交易明细中只有一笔
            if (Transcation.TransDetail.Count != 1)
                throw new BusinessException("the lines of transfer detail info should be one") { Code = "1021011" };
            this.Head.CCTransCode = "SGT003";
            this.Head.ReqSeqNo = Transcation.ClientId;
            this.Head.ReqDate = Transcation.TransDate;
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
            foreach (var item in Transcations.Transcations)
            {
                
                foreach (var line in item.TransDetail)
                {
                    InnerTransferMsg msg = new InnerTransferMsg();
                    msg.Head.CCTransCode = "SGT003";
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
