using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.Domain.SGB;
using BankDirectConnection.Domain.TransferBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.PushBankment.SGBService.Service
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/12 16:36:24
	===============================================================================================================================*/
    /// <summary>
    /// 内部转账
    /// </summary>
    public class InnerTransferService
    {
        /// <summary>
        /// 调用法兴内部转账接口
        /// </summary>
        /// <returns></returns>
        public IResResult PushInnerTranscationInfo(InnerTransferMsg Msg)
        {
            if (null == Msg)
                throw new InnerException("", "");
            IResResult result = new ResResult();

            // TODO 调用法兴转账接口
            // 处理返回结果

            return result;
        }
    }
}
