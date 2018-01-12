using BankDirectConnection.Domain.TransferBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.PushBankment.SGBService.Service
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/12 16:36:46
	===============================================================================================================================*/
    /// <summary>
    /// 人民币付款  收款账户是人民币且不是法兴银行
    /// </summary>
    public class RMBTransferService
    {
        /// <summary>
        /// 调用法兴人民币付款接口
        /// </summary>
        /// <returns></returns>
        public static string PushRMBTranscation(ITranscation Transcation)
        {

            return "";
        }
            
    }
}
