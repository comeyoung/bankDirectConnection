using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.BaseApplication.DataHandle
{
    /*===============================================================================================================================
		Create by Fancy in 2018/1/23 17:36:57
	===============================================================================================================================*/
    /// <summary>
    /// 
    /// </summary>
    public enum emBalanceType
    {
        /// <summary>
        /// 今日余额查询
        /// </summary>
        emCurrentDate,
        /// <summary>
        /// 历史余额查询
        /// </summary>
        emHistory

    }
    /// <summary>
    /// 银行接口
    /// </summary>
    public enum emBankService
    {
        /// <summary>
        /// 中国银行接口
        /// </summary>
        emBOCService,
        /// <summary>
        /// 法兴银行借款
        /// </summary>
        emSGBService
    }
    /// <summary>
    /// 优先级
    /// </summary>
    public enum emPriority
    {
        /// <summary>
        /// 普通
        /// </summary>
        emNormal,
        /// <summary>
        /// 加急
        /// </summary>
        emUrgent
    }

    public enum emBankNo
    {
        /// <summary>
        /// 中国银行
        /// </summary>
        BOC = 104,
        /// <summary>
        /// 兴业银行
        /// </summary>
        SG = 309,
    }
}
