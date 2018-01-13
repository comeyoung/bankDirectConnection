﻿using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.BaseApplication.ExceptionMsg;
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
    public class RMBPaymentMsg: AbstractSGBTranscation
    {
        public RMBPaymentMsg()
        {
            this.Head = new CommonHeader();
        }

        public RMBPaymentMsg(ITranscations Transcations)
        {
            this.Create(Transcations);
            this.Check();
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
        /// <summary>
        /// 收款人开户行名称
        /// </summary>
        public string CrBankName { get; set; }

        /// <summary>
        /// 收款人开户行行号
        /// </summary>
        public string UnionDeptId { get; set; }
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
        /// 加急标志
        /// </summary>
        public string Priority { get; set; }

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
            return base.Check();
        }

        public RMBPaymentMsg Create(ITranscations Transcations)
        {
            if (Transcations.Transcations.Count != 1)
                throw new BusinessException("the lines of transfer info should be one") { Code = "1021011" };
            if (Transcations.Transcations.FirstOrDefault().TransDetail.Count != 1)
                throw new BusinessException("the lines of transfer detail info should be one") { Code = "1021011" };
            RMBPaymentMsg msg = new RMBPaymentMsg();
            foreach (var item in Transcations.Transcations)
            {
                msg.Head.CCTransCode = "SGT002";
                msg.Head.ReqSeqNo = item.ClientId;
                msg.Head.ReqDate = item.TransDate;
                //msg.Head.CorpNo = "";
                //msg.Head.OpNo = "";
                //msg.Head.PassWord = "";
                msg.DbAccNo = item.FromAcct.AcctId;
                msg.DbAccName = item.FromAcct.AcctName;
                msg.DbCur = item.PaymentCur;
                foreach (var line in item.TransDetail)
                {
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
                }
            }
            return msg;
        }
    }
}
