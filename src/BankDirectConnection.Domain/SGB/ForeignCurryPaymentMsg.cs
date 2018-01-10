using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.SGB
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 13:41:38
	===============================================================================================================================*/
    /// <summary>
    /// 外币付款信息
    /// </summary>
    public class ForeignCurryPaymentMsg
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
        /// 收款人账户类型
        /// </summary>
        public string CrCifType { get; set; }
        /// <summary>
        /// 收款人类型
        /// </summary>
        public string ForeignPayee { get; set; }

        public string BeneSwifCode { get; set; }

        /// <summary>
        /// 收款人开户行名称
        /// </summary>
        public string CrBankName { get; set; }

        /// <summary>
        /// 收费方式
        /// </summary>
        public string Fees { get; set; }

        /// <summary>
        /// 参考汇率
        /// </summary>
        public string Rate { get; set; }

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
