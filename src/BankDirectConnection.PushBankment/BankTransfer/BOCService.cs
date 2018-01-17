using System;
using BankDirectConnection.Application.Transfer;
using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.Domain.QueryBO;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.Domain.TransferBO;
using BankDirectConnection.PushBankment.BOCService.Service;
using BankDirectConnection.Domain.BOC;
using System.Collections.Generic;

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
                    // 快捷支付业务一次只能走一笔
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
            //获取状态查询业务
            TransactionStatusInquiryService service = new TransactionStatusInquiryService();

            if (TransferQueryData.TransferQueryDatas.Count <= 100)
            {
                var tsim = new TransactionStatusInquiryMsg(TransferQueryData);
                return service.PushTransactionStatusInquiry(tsim);
            }
            else
            {
                var queryDataList = this.SplitTransferData(TransferQueryData);
                //
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// 将第三方传递的查询数据明细分割为每笔明细100行
        /// </summary>
        /// <param name="TransferQueryData"></param>
        /// <returns></returns>
        public List<ITransferQueryDataList> SplitTransferData(ITransferQueryDataList TransferQueryData)
        {
            List<ITransferQueryDataList> transQueryList = new List<ITransferQueryDataList>();
            TransferQueryDataList trans = null;
            foreach (var item in TransferQueryData.TransferQueryDatas)
            {
                if (null != trans)
                {
                    if (trans.TransferQueryDatas.Count == 100)
                    {
                        transQueryList.Add(trans);
                        trans = new TransferQueryDataList();
                    }
                    trans.TransferQueryDatas.Add(item);
                }
                else
                {
                    trans = new TransferQueryDataList();
                    trans.TransferQueryDatas.Add(item);
                }
            }
            transQueryList.Add(trans);
            return transQueryList;
        }
    }
}
