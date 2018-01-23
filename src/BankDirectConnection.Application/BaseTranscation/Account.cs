using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.BaseApplication.ExceptionMsg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Application.BaseTranscation
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/12 14:22:19
	===============================================================================================================================*/
    public class Account : IAccount
    {
        /// <summary>
        /// 行联行号
        /// </summary>
        public string BankId { get; set; }
        /// <summary>
        /// 行名称
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// 账户号
        /// </summary>
        public string AcctId { get; set; }
        /// <summary>
        /// 账户名称
        /// </summary>
        public string AcctName { get; set; }
        /// <summary>
        /// 账户类型
        /// </summary>
        public string AcctType { get; set; }
        public bool Check()
        {
            if (string.IsNullOrEmpty(this.BankId))
                throw new BusinessException("2022002", "Transaction information of BankId can not be empty");
            if (string.IsNullOrEmpty(this.AcctId))
                throw new BusinessException("2022002", "Transaction information of AcctId can not be empty");
            return true;
        }

    }
}
