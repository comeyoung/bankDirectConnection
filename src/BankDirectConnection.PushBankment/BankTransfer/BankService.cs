using BankDirectConnection.Application.Transfer;
using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.DataHandle;
using BankDirectConnection.Domain.ExceptionMsg;
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
    public class BankService : IBankService<ITranscations,ITranscation, ITransferQueryData, ITransferQueryDataList, IResResult>
    {
        public IResResult PaymentTransfer(ITranscations Transcation)
        {
            //检查transcation消息
            try
            {
                //Transcation.Check();
                string insId = Instruction.NewInsSid(Transcation.TransWay);
                ////获取银行信息，调用具体银行的服务
                var bankService = BankFactory.CreateBank(Transcation.TransWay);
                return bankService.PaymentTransfer(Transcation);
                // throw new NotImplementedException();
            }
            catch (BusinessException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw new BusinessException(ex.Message) { Code = "2002001" };
            }
           
        }

        public IResResult QueryTransStatus(ITransferQueryDataList Transcation)
        {
            try
            {
                // 取出各个银行的数据

                //var bank = Instruction.ParseInsId(Transcation.InsId);
                ////获取银行信息，调用具体银行的服务
                //IBankService<ITranscations, ITranscation, ITransferQueryData, ITransferQueryDataList, IResResult> bankService = BankFactory.CreateBank(bank);
                //return bankService.QueryTransStatus(Transcation);
                throw new NotImplementedException();
            }
            catch(BusinessException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw new BusinessException(ex.Message) { Code = "2002001" };
            }
            
        }
    }
}
