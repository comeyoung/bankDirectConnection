using BankDirectConnection.BaseApplication.BaseTranscation;

namespace BankDirectConnection.Domain.TransferBO
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 11:15:51
	===============================================================================================================================*/
    /// <summary>
    /// 交易明细
    /// </summary>
    public interface ITransDetail:ICheckAble
    {
        /// <summary>
        /// 收款账户信息
        /// </summary>
        IAccount ToAcct { get; set; }
        /// <summary>
        /// 收款人证件类型
        /// </summary>
        string ReciepterIdType { get; set; }
        /// <summary>
        /// 收款人证件号
        /// </summary>
        string ReciepterIdCode { get; set; }
        /// <summary>
        /// 收款人类型
        /// </summary>
        string ReceipterType { get; set; }
        /// <summary>
        /// 收款金额
        /// </summary>
        decimal TransAmount { get; set; }
        /// <summary>
        /// 收款币种
        /// </summary>
        string TransCur { get; set; }
        /// <summary>
        /// 收款行SWIFT编码
        /// </summary>
        string SWIFTCode { get; set; }
        /// <summary>
        /// 参考汇率
        /// </summary>
        string Rate { get; set; }
    }
}
