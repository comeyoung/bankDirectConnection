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
                throw new InnerException("2022002", "人民币交易信息不能为空");
           

            //构建xml
            var transXML = Serialization.BuildXMLForRMBPayment(Msg);
            //调用接口
            var res = SGBHttp.PostRequest(transXML);
            var rt = Deserialization.ParseResonseMsg(res);
            //返回结果
            return ResResult.Create(rt);
          
        
            


            
        }
            
    }
}
