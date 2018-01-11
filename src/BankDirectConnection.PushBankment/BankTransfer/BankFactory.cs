using BankDirectConnection.Application.Transfer;
using BankDirectConnection.Domain.DataHandle;
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
        public static IBankService CreateBank(emBankService BankService)
        {
            IBankService bankService;
            switch (BankService)
            {
                case emBankService.emBOCService: bankService = new BOCService();break;
                case emBankService.emSGBService: bankService = new SGBService();break;
                default:throw new Exception("inner error,bad bank service.");
            }
            return bankService;
        }
    }
}
