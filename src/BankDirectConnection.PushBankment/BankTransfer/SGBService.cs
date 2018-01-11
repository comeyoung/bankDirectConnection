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
    public class SGBService : IBankService
    {
      

        public void PaymentTransfer(ITranscation Transcation)
        {
            throw new NotImplementedException();
        }

      
        public IResResult QueryTransStatus(ITransferQueryData ITransferQueryData)
        {
            throw new NotImplementedException();
        }
    }
}
