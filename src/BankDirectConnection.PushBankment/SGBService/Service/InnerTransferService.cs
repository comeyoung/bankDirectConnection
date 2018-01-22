using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.Domain.SGB;
using BankDirectConnection.Domain.SGB.PaymentMsg;
using BankDirectConnection.IPushBankment.Service.SGB;

namespace BankDirectConnection.PushBankment.SGBService.Service
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/12 16:36:24
	===============================================================================================================================*/
    /// <summary>
    /// 内部转账
    /// </summary>
    public class InnerTransferService: IInnerPaymentService
    {
        /// <summary>
        /// 调用法兴内部转账接口
        /// </summary>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public IResResult PushPaymentTranscationInfo(IInnerTransferMsg Msg)
        {
            if (null == Msg)
                throw new InnerException("2022002", "Internal transaction information can not be empty ");
            // TODO 调用法兴转账接口
            var transXML = Serialization.BuildXMLForInnerTransfer(Msg);
            //var res = SGBHttp.PostRequest(transXML);
            var res = SGBHttp.PostRequest(null);
            var rt = Deserialization.ParseResonseMsg(res);
            // 处理返回结果
            return ResResult.Create(rt);
        }
    }
}
