using System;
using BankDirectConnection.Application.Transfer;
using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.Domain.QueryBO;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.Domain.TransferBO;
using BankDirectConnection.PushBankment.BOCService.Service;
using BankDirectConnection.Domain.BOC;

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
            //签到 获取token
            SignService signService = new SignService();
            var response = signService.PushSignIn();
            // 分析走转账还是代发业务
            if (Transcations.BusinessType == "01")
            {
                IResResult result = new ResResult();
                foreach (var item in Transcations.Transcations)
                {
                    var transBO = new WageAndReimbursementMsg(item);
                    transBO.HeaderMessage.Token = response.Token;
                    //获取代发业务
                    WageAndReimbursementService service = new WageAndReimbursementService();
                    var rt = service.PushWageOrReimbursementInfo(transBO);
                    if(null == result)
                    {
                        result = rt;
                    }
                    else
                    {
                        result.MergeResResult(rt);
                    }
                }
                return result;
                
            }
            else
            {
                var transBO = new PaymentsToPublicMsg(Transcations);
                transBO.HeaderMessage.Token = response.Token;
                //获取转账业务
                PaymentsToPublicService service = new PaymentsToPublicService();
                return service.PushPaymentsToPublicInfo(transBO);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="TransferQueryData"></param>
        /// <returns></returns>
        public IResResult QueryTransStatus(ITransferQueryDataList TransferQueryData)
        {
            //EDI流水号都要以中行流水号开头
            //
            throw new NotImplementedException();
        }
    }
}
