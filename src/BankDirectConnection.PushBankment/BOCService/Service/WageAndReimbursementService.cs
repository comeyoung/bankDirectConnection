using BankDirectConnection.BaseApplication.ExceptionMsg;
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
	*	Create by Fancy at 2018/1/12 11:17:23
	===============================================================================================================================*/
    /// <summary>
    /// 工资、报销代发快捷支付业务
    /// </summary>
    public class WageAndReimbursementService
    {
        /// <summary>
        /// 推送工资、报销代发
        /// </summary>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public IResResult PushWageOrReimbursementInfo(WageAndReimbursementMsg Msg)
        {
            if (null == Msg)
                throw new InnerException("", "");
            var transXML = Serialization.BuildXMLForWageAndReimbursementByLinq(Msg);
            // 调用对公转账接口
            var res = BOCHttp.PostRequest(transXML);
            //处理结果
            var rt = Deserialization.ParseResponseMsg(res, "b2e0078");
            return ResResult.Create(rt, "01");
        }
    }
}
