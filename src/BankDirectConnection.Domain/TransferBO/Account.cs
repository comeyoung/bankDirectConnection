using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.TransferBO
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 11:34:19
	===============================================================================================================================*/
    public class Account: IAccount
    {
        /// <summary>
        /// 收款行联行号
        /// </summary>
        public string BankId { get; set; }
        /// <summary>
        /// 收款行名称
        /// </summary>
        public string BankName { get; set; }
        /// <summary>
        /// 收款方账户号
        /// </summary>
        public string AcctId { get; set; }
        /// <summary>
        /// 收款方账户名称
        /// </summary>
        public string AcctName { get; set; }
        /// <summary>
        /// 收款人账户类型
        /// </summary>
        public string AcctType { get; set; }
    }
}
