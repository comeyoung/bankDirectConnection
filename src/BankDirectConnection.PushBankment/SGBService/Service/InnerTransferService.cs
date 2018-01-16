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
                throw new InnerException("2022002", "内部交易信息不能为空");
            

            // TODO 调用法兴转账接口
            var transXML = Serialization.BuildXMLForInnerTransfer(Msg);
            var res = SGBHttp.PostRequest(transXML);
            var rt = Deserialization.ParseResonseMsg(res);



            // 处理返回结果

            return ResResult.Create(rt);
        }
    }
}
