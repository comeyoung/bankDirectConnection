using BankDirectConnection.IPushBankment.Service.BOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankDirectConnection.Domain.BOC;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.BaseApplication.ExceptionMsg;

namespace BankDirectConnection.PushBankment.BOCService.Service
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/31 19:06:51
	===============================================================================================================================*/
    public class PaymentsToPrivateService : IPaymentsToPrivateService
    {
        public IResResult PushPaymentTransferInfo(IPaymentsToPrivateMsg Msg)
        {
            if (null == Msg)
                throw new InnerException("2022002", "the value of transfer inquiry is empty");
            //序列化
            var transXML = Serialization.BuildXMLForPaymentsToPrivateByLinq(Msg);
            //调用对公转账接口
            var res = BOCHttp.PostRequest(transXML);
            //处理结果
            var rt = Deserialization.ParseResponseMsg(res, "b2e0061");
            return ResResult.Create<IPaymentsToPrivateMsg>(Msg, rt);
        }
    }
}
