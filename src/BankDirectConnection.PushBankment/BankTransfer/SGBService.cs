using System;
using BankDirectConnection.Application.Transfer;
using BankDirectConnection.Domain.QueryBO;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.Domain.TransferBO;
using System.Collections.Generic;
using BankDirectConnection.BaseApplication.ExceptionMsg;

namespace BankDirectConnection.PushBankment.BankTransfer
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 10:16:33
	===============================================================================================================================*/
    /// <summary>
    /// 法兴银行服务
    /// </summary>
    public class SGBService : IBankService<ITranscations,ITranscation, ITransferQueryData, ITransferQueryDataList, IResResult>
    {
        public IResResult PaymentTransfer(ITranscations Transcation)
        {
            IResResult result = new ResResult();
            IResponse rt;
            foreach (var item in Transcation.Transcations)
            {
                rt = new Response();
                try
                {
                    // 明细只能一行
                    if (item.TransDetail.Count != 1)
                        throw new BusinessException("", "");
                    #region 处理接口调用
                    // 如果收款人账号是我行（法兴）走行内转账

                    // 如果收款人账号是他行（非法兴）
                    // 收款币种是RMB 走人名币付款接口

                    // 收款币种是非RMB 走外币付款接口
                    #endregion

                    // 处理结果
                    if (null == result)
                    {
                        //TODO 结果赋值
                       // result =
                    }
                    else
                    {
                        //TODO 合并结果
                    }
                }
                catch (BusinessException ex)
                {
                    rt.Status.RspCod = ex.Code;
                    rt.Status.RspMsg = ex.Message;
                    result.Response.Add(rt);
                } 
            }
            return result;
        }

        public IResResult QueryTransStatus(ITransferQueryDataList TransferQueryData)
        {
            IResResult result = new ResResult();
            //
            return result;
        }

    }
}
