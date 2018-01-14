using BankDirectConnection.Domain.BOC;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.Domain.TransferBO;
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
    public class PaymentsToPublicService
    {
        public IResResult PushPaymentsToPublic(ITranscations Transcation)
        {
            IResResult result = new ResResult();
            SignService signService = new SignService();
            //获取token
            var response = signService.PushSignIn();

            //获取对象
            var transBO = new PaymentsToPublicMsg(Transcation);
            transBO.HeaderMessage.Token = response.Token;
            //序列化
            var transXML = Serialization.BuildXMLForPaymentsToPublicByLinq(transBO);
            //调用对公转账接口
            var res = BOCHttp.PostRequest(transXML);
            //处理结果
            var rt = Deserialization.ParseResponseMsg(res, "b2e0009");
            return result;
        }
    }
}
