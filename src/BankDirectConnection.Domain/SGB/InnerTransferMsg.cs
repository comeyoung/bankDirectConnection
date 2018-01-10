using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.SGB
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 13:51:23
	===============================================================================================================================*/
    /// <summary>
    /// 行内转账
    /// </summary>
    public class InnerTransferMsg
    {
        /// <summary>
        /// 付款账号
        /// </summary>
        public string DbAccNo { get; set; }
        /// <summary>
        /// 付款方账户名
        /// </summary>
        public string DbAccName { get; set; }

        /// <summary>
        /// 付款币种
        /// </summary>
        public string DbCur { get; set; }

        /// <summary>
        /// 收款账号
        /// </summary>
        public string CrAccNo { get; set; }
        /// <summary>
        /// 收款人账户名
        /// </summary>
        public string CrAccName { get; set; }
        /// <summary>
        /// 收款人省市代码
        /// </summary>
        public string CrProv { get; set; }
        /// <summary>
        /// 收款人账户类型
        /// </summary>
        public string CrCifType { get; set; }
        /// <summary>
        /// 转账币种
        /// </summary>
        public string CrCur { get; set; }


        /// <summary>
        /// 交易金额
        /// </summary>
        public string TransAmt { get; set; }

        /// <summary>
        /// 用途
        /// </summary>
        public string WhyUse { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Docket { get; set; }

        /// <summary>
        /// 交易触发方式
        /// </summary>
        public string TranType { get; set; }

        /// <summary>
        /// 开始时间
        /// </summary>
        public string StartTime { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        public string StartDate { get; set; }
    }
}
