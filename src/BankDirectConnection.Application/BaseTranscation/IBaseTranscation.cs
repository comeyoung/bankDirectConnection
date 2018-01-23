using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.BaseApplication.BaseTranscation
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/12 14:21:35
	===============================================================================================================================*/
    public interface IBaseTranscation:ICheckAble
    {
        /// <summary>
        /// 客户端流水号
        /// </summary>
        string ClientId { get; set; }

        /// <summary>
        /// 平台生成的流水号
        /// </summary>
        string EDIId { get; set; }
        /// <summary>
        /// 转账方式 银行接口类型
        /// </summary>
        string TransWay { get; set; }
        /// <summary>
        /// 转账业务类型  工资/报销/转账
        /// </summary>
        string BusinessType { get; set; }
        /// <summary>
        /// 付款账号信息
        /// </summary>
        IAccount FromAcct { get; set; }

        void NewEDIId();

    }
}
