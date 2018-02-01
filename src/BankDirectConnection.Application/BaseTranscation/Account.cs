using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.BaseApplication.DataHandle;
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
        /// 账户类型 0公司；1个人
        /// </summary>
        public string AcctType { get; set; }

        /// <summary>
        /// 省市代码
        /// </summary>
        public string Province
        {
            get;set;
        }

        public emBankType BankType
        {
            get;set;
        }

        public bool Check()
        {
            if (string.IsNullOrEmpty(this.BankId))
                throw new BusinessException("2022002", "Transaction information of BankId can not be empty");
            if (string.IsNullOrEmpty(this.AcctId))
                throw new BusinessException("2022002", "Transaction information of AcctId can not be empty");
            return true;
        }

        /// <summary>
        /// 根据银行行号判断是否为法兴银行
        /// </summary>
        /// <param name="AccountNo"></param>
        /// <returns></returns>
        public static bool IsSG(string BankId)
        {
            var SGBankNo = (emBankNo)Enum.Parse(typeof(emBankNo), emBankNo.SG.ToString());
            // TODO 收款人账号为兴业银行
            if (BankId.Length == 12 && BankId.Substring(0, 3) == SGBankNo.GetHashCode().ToString())
                return true;
            else
                return false;
        }

    }
}
