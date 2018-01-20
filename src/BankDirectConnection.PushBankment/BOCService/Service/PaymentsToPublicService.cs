using BankDirectConnection.Domain.BOC;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.Domain.TransferBO;
using BankDirectConnection.IPushBankment.Service.BOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.PushBankment.BOCService.Service
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/12 11:19:36
	===============================================================================================================================*/
    /// <summary>
    /// 对公转账业务
    /// </summary>
    public class PaymentsToPublicService: IPaymentsToPublicService
    {
       
        /// <summary>
        /// 推送对公转账
        /// </summary>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public IResResult PushPaymentTransferInfo(IPaymentsToPublicMsg Msg)
        {
            //序列化
            var transXML = Serialization.BuildXMLForPaymentsToPublicByLinq(Msg);
            //调用对公转账接口
            var res = BOCHttp.PostRequest(transXML);
            //处理结果
            var rt = Deserialization.ParseResponseMsg(res, "b2e0009");
            return ResResult.Create(rt);
        }
    }
}
