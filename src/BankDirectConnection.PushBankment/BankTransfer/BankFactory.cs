using BankDirectConnection.Application.Transfer;
using BankDirectConnection.Domain.DataHandle;
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
	*	Create by Fancy at 2018/1/10 12:45:19
	===============================================================================================================================*/
    public class BankFactory
    {
        public static IBankService<ITranscations,ITranscation, ITransferQueryData, ITransferQueryDataList, IResResult> CreateBank(emBankService BankService)
        {
            IBankService<ITranscations,ITranscation, ITransferQueryData, ITransferQueryDataList, IResResult> bankService;
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
