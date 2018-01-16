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
	*	Create by Fancy at 2018/1/12 16:37:09
	===============================================================================================================================*/
    /// <summary>
    /// 外币转账 收款账户不是人民币且不是法兴银行
    /// </summary>
    public class ForeignCurryTransferService
    {
        /// <summary>
        /// 调用法兴外币转账接口
        /// </summary>
        /// <returns></returns>
        public IResResult PushForeignCurryTranscationInfo(ForeignCurryPaymentMsg Msg)
        {
            if (null == Msg)
                throw new InnerException("2022002", "外币交易信息不能为空");
           
            // TODO 调用法兴转账接口
            var transXML = Serialization.BuildXMLForFreignCurryPayment(Msg);
            var res = SGBHttp.PostRequest(transXML);
            var rt = Deserialization.ParseResonseMsg(res);

            // 处理返回结果
            return ResResult.Create(rt);
        }
    }
}
