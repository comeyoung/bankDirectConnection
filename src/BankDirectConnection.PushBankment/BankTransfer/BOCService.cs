
using System;
using BankDirectConnection.Application.Transfer;
using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.Domain.QueryBO;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.Domain.TransferBO;
using BankDirectConnection.PushBankment.BOCService.Service;
using BankDirectConnection.Domain.BOC;
using System.Collections.Generic;
using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.DataHandle;

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

        private readonly WageAndReimbursementService wageAndReimbursementService;
        private readonly PaymentsToPublicService paymentsToPublicService;
        private readonly TransactionStatusInquiryService transactionStatusInquiryService;


        public BOCService()
        {
            this.wageAndReimbursementService = new WageAndReimbursementService();
            this.paymentsToPublicService = new PaymentsToPublicService();
            this.transactionStatusInquiryService = new TransactionStatusInquiryService();
        }
        public BOCService(WageAndReimbursementService WageAndReimbursementService, 
                          PaymentsToPublicService PaymentsToPublicService, 
                          TransactionStatusInquiryService TransactionStatusInquiryService){
            this.wageAndReimbursementService = WageAndReimbursementService;
            this.paymentsToPublicService = PaymentsToPublicService;
            this.transactionStatusInquiryService = TransactionStatusInquiryService;
        }
        public IResResult PaymentTransfer(ITranscations Transcations)
        {
            //签到 获取token
            SignService signService = new SignService();
            var response = signService.PushSignIn();
            // 分析走转账还是代发业务
            if (Transcations.BusinessType == "01")
            {
                IResResult result = new ResResult();
                IResponse res = new Response();
                foreach (var item in Transcations.Transcations)
                {
                    try
                    {
                        // 快捷支付业务一次只能走一笔
                        var transBO = new WageAndReimbursementMsg(item);
                        transBO.HeaderMessage.Token = response.Token;
                        //获取代发业务                  
                        var rt = this.wageAndReimbursementService.PushPaymentTransferInfo(transBO);
                        result.MergeResResult(rt);
                    }
                    catch (BusinessException ex)
                    {
                        res.Status.RspCod = ex.Code;
                        res.Status.RspMsg = ex.Message;
                        result.MergeResResult(res);
                    }
                    catch (InnerException ex)
                    {
                        res.Status.RspCod = ex.Code;
                        res.Status.RspMsg = ex.Message;
                        result.MergeResResult(res);
                    }
                    catch (Exception ex)
                    {
                        res.Status.RspCod = "";
                        res.Status.RspMsg = ex.Message;
                        result.MergeResResult(res);
                    }


                }
                return result;
                
            }
            else
            {
                var transBO = new PaymentsToPublicMsg(Transcations);
                transBO.HeaderMessage.Token = response.Token;
                //获取转账业务
                return this.paymentsToPublicService.PushPaymentTransferInfo(transBO);
            }
        }
        /// <summary>
        /// 查询交易状态
        /// </summary>
        /// <param name="TransferQueryData"></param>
        /// <returns></returns>
        public IResResult QueryTransStatus(ITransferQueryDataList TransferQueryData)
        {
            //签到 获取token
            SignService signService = new SignService();
            var response = signService.PushSignIn();
            IResResult result = new ResResult();
            //交易状态查询信息
            TransactionStatusInquiryMsg msg = null;
            if (TransferQueryData.TransferQueryDatas.Count <= Data.MAX_LINENUM_OF_BOC_QUERY_TRANSFERSTATUS)
            {
                msg = new TransactionStatusInquiryMsg(TransferQueryData);
                msg.HeaderMessage.Token = response.Token;
                result = this.transactionStatusInquiryService.PushTransactionStatusInquiry(msg);
            }
            else
            {
                var queryDataList = this.SplitTransferData(TransferQueryData);
                foreach (var item in queryDataList)
                {
                    msg = new TransactionStatusInquiryMsg(item);
                    msg.HeaderMessage.Token = response.Token;
                    var rt = this.transactionStatusInquiryService.PushTransactionStatusInquiry(msg);
                    result.MergeResResult(rt);
                }
            }
            return result;
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
                if (trans == null)
                {

                    trans = new TransferQueryDataList();
                    trans.TransferQueryDatas.Add(item);
                }
                else
                {       
                    if (trans.TransferQueryDatas.Count == Data.MAX_LINENUM_OF_BOC_QUERY_TRANSFERSTATUS)
                    {
                        transQueryList.Add(trans);
                        trans = new TransferQueryDataList();
                    }
                    trans.TransferQueryDatas.Add(item);
                }
            }
            transQueryList.Add(trans); 
            return transQueryList;
        }
    }
}
