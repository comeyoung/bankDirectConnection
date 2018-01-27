using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.SGB
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/26 16:39:05
	===============================================================================================================================*/
    public interface ISGBTranscation
    {
        /// <summary>
        /// 
        /// </summary>
        string DbAccNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        string CrAccNo { get; set; }
        /// <summary>
        /// 付款方账户名
        /// </summary>
        string DbAccName { get; set; }
        /// <summary>
        /// 付款币种
        /// </summary>
        string DbCur { get; set; }
        /// <summary>
        /// 收款人账户名
        /// </summary>
        string CrAccName { get; set; }
        /// <summary>
        /// 收款人账户类型 0公司 1个人
        /// </summary>
        string CrCifType { get; set; }
        /// <summary>
        /// 收款人类型 0居民 1：非居民
        /// </summary>
        string ForeignPayee { get; set; }
        /// <summary>
        /// 收款人开户行行号
        /// </summary>
        string UnionDeptId { get; set; }
        /// <summary>
        /// 收款人开户行名称
        /// </summary>
        string CrBankName { get; set; }
        /// <summary>
        /// 收费方式
        /// </summary>
        string Fees { get; set; }
        /// <summary>
        /// 转账币种
        /// </summary>
        string CrCur { get; set; }
        /// <summary>
        /// 交易金额
        /// </summary>
        decimal TransAmt { get; set; }

        /// <summary>
        /// 用途
        /// </summary>
        string WhyUse { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        string Docket { get; set; }

        /// <summary>
        /// 交易触发方式
        /// </summary>
        string TranType { get; set; }
        /// <summary>
        /// 开始时间
        /// </summary>
        string StartTime { get; set; }
        /// <summary>
        /// 开始日期
        /// </summary>
        string StartDate { get; set; }
    }
}
