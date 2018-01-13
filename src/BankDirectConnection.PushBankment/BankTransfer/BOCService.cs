using System;
using BankDirectConnection.Application.Transfer;
using BankDirectConnection.BaseApplication.BaseTranscation;
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
    public class BOCService : IBankService<ITranscations,ITranscation, ITransferQueryData, ITransferQueryDataList, IResResult>
    {
    

        public IResResult PaymentTransfer(ITranscations Transcations)
        {
            // 分析走转账还是代发业务
            if (Transcations.BusinessType == "01")
            {
                //获取代发业务

            }
            else
            {
                //获取转账业务

            }
            //请求报文转换为BOC请求报文

            //请求结果转换为对外结果
            
            throw new NotImplementedException();
        }

        public IResResult QueryTransStatus(ITransferQueryDataList TransferQueryData)
        {
            throw new NotImplementedException();
        }
    }
}
