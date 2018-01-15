using System;
using BankDirectConnection.Application.Transfer;
using BankDirectConnection.Domain.QueryBO;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.Domain.TransferBO;

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
            // 如果收款人账号是我行（法兴）走行内转账
            
            // 如果收款人账号是他行（非法兴）
                // 收款币种是RMB 走人名币付款接口

                // 收款币种是非RMB 走外币付款接口

            throw new NotImplementedException();
        }

        public IResResult QueryTransStatus(ITransferQueryDataList TransferQueryData)
        {
            IResResult result = new ResResult();
            //
            return result;
        }

    }
}
