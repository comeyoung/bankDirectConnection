using BankDirectConnection.Application.Transfer;
using BankDirectConnection.Domain.TransferBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.PushBankment.BankTransfer
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 12:45:19
	===============================================================================================================================*/
    public class BankFactory
    {
        public IBankService CreateBank(ITranscation transcation)
        {
            IBankService bankService;
            switch (transcation.BusinessType)
            {
                case "0": bankService = new BOCService();break;
                case "1":bankService = new SGBService();break;
                default:throw new Exception("业务代码错误");
            }
            return bankService;
        }
    }
}
