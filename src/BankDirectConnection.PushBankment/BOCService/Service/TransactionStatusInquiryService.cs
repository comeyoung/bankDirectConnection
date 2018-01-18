using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.BOC;
using BankDirectConnection.Domain.Service;
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
    public class TransactionStatusInquiryService
    {
        public IResResult PushTransactionStatusInquiry(TransactionStatusInquiryMsg Msg) {
            if (null == Msg)
                throw new InnerException("2022002", "Transaction status query information can not be empty ");
            var tranxXML = Serialization.BuildXMLForTransactionStatusInquiryByLinq(Msg);
            var res = BOCHttp.PostRequest(tranxXML);
            var rt = Deserialization.ParseResponseMsg(res, "b2e0007");
            return ResResult.Create(rt);
        }
    }
}
