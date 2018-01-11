using System;
using BankDirectConnection.Application.Transfer;
using BankDirectConnection.Domain.QueryBO;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.Domain.TransferBO;

namespace BankDirectConnection.PushBankment.BankTransfer
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 10:14:42
	===============================================================================================================================*/
    /// <summary>
    /// 中国银行服务
    /// </summary>
    public class BOCService : IBankService
    {
        public void PaymentTransfer(ITranscation Transcation)
        {
            throw new NotImplementedException();
        }

        public IResResult QueryTransStatus(ITransferQueryData TransferQueryData)
        {
            throw new NotImplementedException();
        }
    }
}
