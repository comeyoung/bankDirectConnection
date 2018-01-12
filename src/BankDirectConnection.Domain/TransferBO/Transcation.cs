using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.BaseApplication.ExceptionMsg;
using System.Collections.Generic;

namespace BankDirectConnection.Domain.TransferBO
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 11:34:34
	===============================================================================================================================*/
    public class Transcation: BaseTranscation,ITranscation
    {
        /// <summary>
        /// 检查数据格式是否符合要求
        /// </summary>
        /// <returns></returns>
        public override bool Check()
        {
            base.Check();
            if (string.IsNullOrEmpty(this.ClientId))
                throw new BusinessException("the value of clientid is null.") { Code = "1001005" };
            if (string.IsNullOrEmpty(this.TransWay))
                throw new BusinessException("the value of transway is null.") { Code = "1001006" };
            if (string.IsNullOrEmpty(this.BusinessType))
                throw new BusinessException("the value of businesstype is null.") { Code = "1001007" };
            if (string.IsNullOrEmpty(this.PaymentCur))
                throw new BusinessException("the value of paymentcur is null.") { Code = "1001008" };
            return true;
        }

        /// <summary>
        /// 客户端流水号
        /// </summary>
        public string ClientId { get; set; }
        /// <summary>
        /// 转账方式
        /// </summary>
        public string TransWay { get; set; }
        /// <summary>
        /// 转账业务类型
        /// </summary>
        public string BusinessType { get; set; }
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
        public string Priority { get; set; }
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
        /// FromAcct
        /// </summary>
        public IAccount FromAcct { get; set; }
        /// <summary>
        /// TransDetail
        /// </summary>
        public IList<ITransDetail> TransDetail { get; set; }


    }
}
