using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.DataHandle
{
    /*===============================================================================================================================
	*	Create by Fancy at 2017/12/24 17:55:10
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
        BOC=104,
        /// <summary>
        /// 兴业银行
        /// </summary>
        SG=309,
    }
}
