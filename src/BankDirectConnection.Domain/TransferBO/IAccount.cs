using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.TransferBO
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 11:05:43
	===============================================================================================================================*/
    /// <summary>
    /// 账户信息
    /// </summary>
    public interface IAccount
    {
        /// <summary>
        /// 银行号
        /// </summary>
        string BankId { get; set; }
        /// <summary>
        /// 银行名称
        /// </summary>
        string BankName { get; set; }
        /// <summary>
        /// 账户号
        /// </summary>
        string AcctId { get; set; }
        /// <summary>
        /// 账户名称
        /// </summary>

        string AcctName { get; set; }

        /// <summary>
        /// 账户类型
        /// </summary>
        string AcctType { get; set; }
    }
}
