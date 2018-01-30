using System;
using BankDirectConnection.Application.BaseTranscation;
using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.BaseApplication.ExceptionMsg;

namespace BankDirectConnection.Domain.TransferBO
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 11:34:46
	===============================================================================================================================*/
    public class TransDetail : ITransDetail
    {
        public TransDetail()
        {
            this.ToAcct = new Account();
        }
        /// <summary>
        /// ToAcct
        /// </summary>
        public IAccount ToAcct { get; set; }
        /// <summary>
        /// 收款人证件类型
        /// </summary>
        public string ReciepterIdType { get; set; }
        /// <summary>
        /// 收款人证件号
        /// </summary>
        public string ReciepterIdCode { get; set; }
        /// <summary>
        /// 收款人类型
        /// </summary>
        public string ReceipterType { get; set; }
        /// <summary>
        /// 收款金额
        /// </summary>
        public decimal TransAmount { get; set; }
        /// <summary>
        /// 收款币种
        /// </summary>
        public string TransCur { get; set; }
        /// <summary>
        /// 收款行SWIFT编码
        /// </summary>
        public string SWIFTCode { get; set; }
        /// <summary>
        /// 参考汇率
        /// </summary>
        public decimal Rate { get; set; }

        public bool Check()
        {
            if (this.TransCur == "RMB")
            {
                this.TransCur = "CNY";
            }
            if (null == this.ToAcct)
                throw new BusinessException("2022002", "Transaction information  of ToAcct can not be empty ");
            this.ToAcct.Check();
            return true;
        }
    }
}
