using BankDirectConnection.Application.Transfer;
using BankDirectConnection.Domain.QueryBO;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.Domain.TransferBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.PushBankment.BankTransfer
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 12:04:28
	===============================================================================================================================*/
    /// <summary>
    /// 银行服务
    /// </summary>
    public class BankService : IBankService
    {
        public void PaymentTransfer(ITranscation Transcation)
        {
           //获取银行信息，调用具体银行的服务
        }

        public IResResult QueryTransStatus(ITransferQueryData Transcation)
        {
            IResResult rt = new ResResult();

            //获取银行信息，调用具体银行的服务
            // IBankService bankService = BankFactory.CreateBank(Transcation);
            return rt;
        }
    }
}
