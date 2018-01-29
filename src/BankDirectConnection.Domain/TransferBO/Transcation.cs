using BankDirectConnection.Application.BaseTranscation;
using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.DataHandle;
using System.Collections.Generic;
using System.Linq;
using System;
using BankDirectConnection.BaseApplication.DataHandle;
using Newtonsoft.Json;

namespace BankDirectConnection.Domain.TransferBO
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 11:34:34
	===============================================================================================================================*/
    public class Transcation : BaseTranscation<ITranscations, ITranscation>, ITranscation
    {
        public Transcation()
        {
            this.FromAcct = new Account();
            this.TransDetail = new List<ITransDetail>();
        }
        public Transcation(Transcations Parent) : base(Parent)
        {
            this.FromAcct = new Account();
            this.TransDetail = new List<ITransDetail>();
            this.TransWay = Parent.TransWay;
            this.BusinessType = Parent.BusinessType;
        }

        /// <summary>
        /// 检查数据格式是否符合要求
        /// </summary>
        /// <returns></returns>
        public override bool Check()
        {
            base.Check();
            if (this.BusinessType == "02" && this.TransDetail.Count > 1)
                throw new BusinessException("Transfer transactions can not have multiple lines of detail") { Code = "2022009" };
            if (string.IsNullOrEmpty(this.ClientId))
                throw new BusinessException("the value of clientid is null.") { Code = "1001005" };
            if (!string.IsNullOrEmpty(this.EDIId))
                throw new BusinessException("the value of EDIId should be empty.") { Code = "1001009" };
            //if (string.IsNullOrEmpty(this.TransWay))
            //    throw new BusinessException("the value of transway is null.") { Code = "1001006" };
            //if (string.IsNullOrEmpty(this.BusinessType))
            //    throw new BusinessException("the value of businesstype is null.") { Code = "1001007" };
            if (string.IsNullOrEmpty(this.PaymentCur))
                throw new BusinessException("the value of paymentcur is null.") { Code = "1001008" };
            this.TransDetail.ToList().ForEach(c => c.Check());
            return true;
        }

        #region property


        /// <summary>
        /// 付款币种
        /// </summary>
        public string PaymentCur { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        public string PaymentType { get; set; }
        /// <summary>
        /// 用途
        /// </summary>
        public string Purpose { get; set; }
        /// <summary>
        /// 是否加急
        /// </summary>
        public emPriolv Priority { get; set; }
        /// <summary>
        /// 交易日期
        /// </summary>
        public string TransDate { get; set; }
        /// <summary>
        /// 交易时间
        /// </summary>
        public string TransTime { get; set; }
        /// <summary>
        /// 收费类型
        /// </summary>
        public string FeeType { get; set; }
        /// <summary>
        /// 手续费账号
        /// </summary>
        public string FeeAcct { get; set; }
        /// <summary>
        /// 代收代付标志
        /// </summary>
        public string AgentSign { get; set; }
        /// <summary>
        /// 备注/附言
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// TransDetail
        /// </summary>
        [JsonConverter(typeof(TransConverter<TransDetail, ITransDetail>))]
        public IList<ITransDetail> TransDetail { get; set; }


        #endregion

        /// <summary>
        /// 返回收款账户银行
        /// </summary>
        /// <returns></returns>
        public string GetBankByReceipter()
        {
            if (this.TransDetail.Count != 1)
                return string.Empty;
            var toAcct = this.TransDetail.FirstOrDefault().ToAcct;
            if (!string.IsNullOrEmpty(toAcct.BankName) && toAcct.BankName.Contains("中国银行"))
                return emBankNo.BOC.ToString();
            else if ((!string.IsNullOrEmpty(toAcct.BankName) && toAcct.BankName.Contains("兴业")))
                return emBankNo.SG.ToString();
            if (!string.IsNullOrEmpty(toAcct.BankId) && toAcct.BankId.Length == 12)
            {
                string bankType = toAcct.BankId.Substring(0, 3);
                if (bankType == emBankNo.BOC.ToString())
                    return emBankNo.BOC.ToString();
                if (bankType == emBankNo.SG.ToString())
                    return emBankNo.SG.ToString();
            }
            return string.Empty;
        }


    }

}
