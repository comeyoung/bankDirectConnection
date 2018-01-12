using BankDirectConnection.BaseApplication.BaseTranscation;
using System.Collections.Generic;

namespace BankDirectConnection.Domain.TransferBO
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 11:15:39
	===============================================================================================================================*/
    /// <summary>
    /// 交易信息
    /// </summary>
    public interface ITranscation:IBaseTranscation
    {
        /// <summary>
        /// 客户端流水号
        /// </summary>
        string ClientId { get; set; }
        
        /// <summary>
        /// 付款币种
        /// </summary>
        string PaymentCur { get; set; }
        /// <summary>
        /// 支付类型
        /// </summary>
        string PaymentType { get; set; }
        /// <summary>
        /// 用途
        /// </summary>
        string Purpose { get; set; }
        /// <summary>
        /// 是否加急
        /// </summary>
        string Priority { get; set; }
        /// <summary>
        /// 交易日期
        /// </summary>
        string TransDate { get; set; }
        /// <summary>
        /// 交易时间
        /// </summary>
        string TransTime { get; set; }
        /// <summary>
        /// 收费类型
        /// </summary>
        string FeeType { get; set; }
        /// <summary>
        /// 手续费账号
        /// </summary>
        string FeeAcct { get; set; }
        /// <summary>
        /// 代收代付标志
        /// </summary>
        string AgentSign { get; set; }
        /// <summary>
        /// 备注/附言
        /// </summary>
        string Comments { get; set; }
        
        /// <summary>
        /// 交易明细
        /// </summary>
        IList<ITransDetail> TransDetail { get; set; }
    }
}
