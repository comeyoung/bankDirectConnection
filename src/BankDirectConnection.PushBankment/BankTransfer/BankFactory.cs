using BankDirectConnection.Application.Transfer;
using BankDirectConnection.BaseApplication.ExceptionMsg;
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
                default:throw new BusinessException("the value of transferway is bad.") { Code = "1001006" };
            }
            return bankService;
        }

        /// <summary>
        /// 根据转账方式（银行接口）创建银行服务
        /// </summary>
        /// <param name="TransWay"></param>
        /// <returns></returns>
        public static IBankService<ITranscations, ITranscation, ITransferQueryData, ITransferQueryDataList, IResResult> CreateBank(string TransWay)
        {
            IBankService<ITranscations, ITranscation, ITransferQueryData, ITransferQueryDataList, IResResult> bankService;
            switch (TransWay)
            {
                case "01": bankService = new BOCService(); break;
                case "02": bankService = new SGBService(); break;
                default: throw new BusinessException("the value of transferway is bad.") { Code = "1001006" };
            }
            return bankService;
        }
    }
}
