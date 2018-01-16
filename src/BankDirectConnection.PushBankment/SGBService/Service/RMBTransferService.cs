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
        public static IResResult PushRMBTranscation(RMBPaymentMsg Msg)
        {
            if (null == Msg)
                throw new InnerException("", "");//TODO
            IResResult result = new ResResult();

            //构建xml
            var transXML = Serialization.BuildXMLForRMBPayment(Msg);
            ////调用接口
            var res = SGBHttp.PostRequest(transXML);
            
            // 将法兴银行返回结果转换为EDI结果
            //TODO
            return result;
        }
            
    }
}
