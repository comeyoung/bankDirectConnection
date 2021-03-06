﻿using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.Domain.SGB;
using BankDirectConnection.Domain.SGB.PaymentMsg;
using BankDirectConnection.Domain.TransferBO;
using BankDirectConnection.IPushBankment.Service.SGB;
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
    public class RMBTransferService : IRMBPaymentService
    {
        /// <summary>
        /// 调用法兴人民币付款接口
        /// </summary>
        /// <param name="Msg"></param>
        /// <returns></returns>
        public IResResult PushPaymentTranscationInfo(IRMBPaymentMsg Msg)
        {
            if (null == Msg)
                throw new InnerException("2022002", "RMB trading information can not be empty ");
            //构建xml
            var transXML = Serialization.BuildXMLForRMBPayment(Msg);
            //调用接口
            var res = SGBHttp.PostRequest(transXML);
            var rt = Deserialization.ParseResonseMsg(res);
            //返回结果
            return ResResult.Create<IRMBPaymentMsg>(Msg,rt);
        }
    }
}
