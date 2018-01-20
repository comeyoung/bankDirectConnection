using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.BOC;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.IPushBankment.Service.BOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.PushBankment.BOCService.Service
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/12 11:19:03
	===============================================================================================================================*/
    /// <summary>
    /// 交易状态查询业务
    /// </summary>
    public class TransactionStatusInquiryService : ITransactionStatusInquiryService
    {
        public IResResult PushTransactionStatusInquiry(ITransactionStatusInquiryMsg Msg)
        {
            if (null == Msg)
                throw new InnerException("2022002", "the value of transfer inquiry is empty ");
            var transXML = Serialization.BuildXMLForTransactionStatusInquiryByLinq(Msg);
            var res = BOCHttp.PostRequest(transXML);
            var rt = Deserialization.ParseResponseMsg(res, "b2e0007");
            return ResResult.Create(rt);
        }
    }
}
