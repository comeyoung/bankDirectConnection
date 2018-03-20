using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [DefaultValue("01"), Description("中国银行接口")]
        emBOCService,
        [DefaultValue("02"), Description("法兴银行接口")]
        emSGBService
    }
   
    /// <summary>
    /// 银行号
    /// </summary>
    public enum emBankNo
    {
        [DefaultValue("104"), Description("中国银行")]
        emBOC,
        SG = 691,
        [DefaultValue("691"), Description("兴业银行")]
        emSG,
    }

    [DefaultValue(emEmpty)]
    public enum emBankType
    {
        [DefaultValue("00"), Description("--无--")]
        emEmpty,
        [DefaultValue("01"), Description("中国银行")]
        emBOC,
        [DefaultValue("02"), Description("兴业银行")]
        emSG,
        [DefaultValue("03"), Description("其他银行")]
        emOthers
    }

    public enum emPriolv
    {
        [DefaultValue("0"), Description("普通")]
        emNormal = 0,
        [DefaultValue("1"), Description("加急")]
        emUrgent = 1
    }
}
