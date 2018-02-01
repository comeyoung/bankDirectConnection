using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.BaseApplication.BaseTranscation
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/12 14:21:45
	===============================================================================================================================*/
    /// <summary>
    /// 账户信息
    /// </summary>
    public interface IAccount:ICheckAble
    {
        /// <summary>
        /// 银行号
        /// </summary>
        string BankId { get; set; }
        /// <summary>
        /// 开户行名称
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

        string Province { get; set; }


    }
}
