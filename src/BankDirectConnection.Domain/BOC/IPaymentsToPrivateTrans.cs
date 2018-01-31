using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.BaseApplication.DataHandle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/31 18:21:14
	===============================================================================================================================*/
    public interface IPaymentsToPrivateTrans: ICheckAble
    {
        string ClientId { get; set; }
        string EDIId { get; set; }
        /// <summary>
        /// 网银交易流水号
        /// </summary>
        string Obssid { get; set; }
        /// <summary>
        /// 转账金额
        /// </summary>
        decimal Trnamt { get; set; }
        /// <summary>
        /// 转账货币 只支持001或者CNY
        /// </summary>
        string Trncur { get; set; }
        /// <summary>
        /// 银行处理优先级(0-普通；1-加急)
        /// </summary>
        emPriolv Priolv { get; set; }
        /// <summary>
        /// 用途
        /// </summary>
        string Furinfo { get; set; }
        /// <summary>
        /// 要求的转账日期 （一个月内） YYYYMMDD

        /// </summary>
        string TrfDate { get; set; }
        /// <summary>
        /// 要求的转账时间
        /// </summary>
        string TrfTime { get; set; }
        /// <summary>
        /// 手续费账号
        /// </summary>
        string Comacn { get; set; }

        /// <summary>
        /// 付款人信息
        /// </summary>
        Fractn Fractn { get; set; }

        /// <summary>
        /// 收款人信息
        /// </summary>
        Toactn Toactn { get; set; }
        /// <summary>
        /// 收款人是否中行账号 非空枚举（1：中行0：他行）
        /// </summary>
        string Bocflag { get; set; }

        /// <summary>
        /// 非空枚举(0-普通；1-快速)
        /// </summary>
        string Cuspriolv { get; set; }
    }
}
