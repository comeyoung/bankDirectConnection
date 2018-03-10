using System;
using BankDirectConnection.Application.Transfer;
using BankDirectConnection.Domain.QueryBO;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.Domain.TransferBO;
using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.SGB;
using System.Linq;
using BankDirectConnection.IPushBankment.Service.SGB;
using BankDirectConnection.BaseApplication.DataHandle;
using BankDirectConnection.PushBankment.SGBService.Service;
using BankDirectConnection.Application.BaseTranscation;

namespace BankDirectConnection.PushBankment.BankTransfer
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 10:16:33
	===============================================================================================================================*/
    /// <summary>
    /// 法兴银行服务
    /// </summary>
    public class SGBService: IBankService<ITranscations, ITranscation, ITransferQueryData, ITransferQueryDataList, IResResult>
    {
        private readonly IForeignCurryPaymentService foreignCurryService;
        private readonly IInnerPaymentService innerPaymentService;
        private readonly IRMBPaymentService rmbPaymentServie;
        private readonly ISGBQueryTransferService queryTranactionService;
        public SGBService(IForeignCurryPaymentService ForeignCurryService,
            IInnerPaymentService InnerPaymentService,
            IRMBPaymentService RMBPaymentService,
            ISGBQueryTransferService SGBQueryTransferService)
        {
            this.foreignCurryService = ForeignCurryService;
            this.innerPaymentService = InnerPaymentService;
            this.rmbPaymentServie = RMBPaymentService;
            this.queryTranactionService = SGBQueryTransferService;
        }
        public SGBService()
        {
            this.foreignCurryService = new ForeignCurryTransferService();
            this.innerPaymentService = new InnerTransferService();
            this.rmbPaymentServie = new RMBTransferService();
            this.queryTranactionService = new QueryTranactionStatusService();
        }
        public IResResult PaymentTransfer(ITranscations Transcation)
        {
            IResResult result = new ResResult();
            IResResult rt;
            IResponse res;
            foreach (var item in Transcation.TranscationItems)
            {
                rt = new ResResult();
                res = new Response();
                try
                {
                    // 明细只能一行
                    if (item.TransDetail.Count != 1)
                        throw new BusinessException("2021001", "the transaction will not be more than one");
                    #region 处理接口调用
                    var detail = item.TransDetail.FirstOrDefault();
                    // 如果收款人账号是我行（法兴）走行内转账.
                    if (Account.IsSG(detail.ToAcct.BankId)||(!string.IsNullOrEmpty(detail.ToAcct.BankName)&&detail.ToAcct.BankName.Contains("兴业银行")))
                    {
                        rt = this.innerPaymentService.PushPaymentTranscationInfo(new InnerTransferMsg(item));
                    }
                    else
                    {
                        // 如果收款人币种是人民币，走人民币付款
                        if (!string.IsNullOrEmpty(detail.TransCur) && (detail.TransCur.Equals("CNY")))
                        {
                            rt = this.rmbPaymentServie.PushPaymentTranscationInfo(new RMBPaymentMsg(item));
                        }
                        // 如果收款人币种是外币，走外币付款
                        else
                        {
                             rt = this.foreignCurryService.PushPaymentTranscationInfo(new ForeignCurryPaymentMsg(item));
                        }
                    }
                    // 处理结果
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
                    res.Status.RspCod = "2022006";
                    res.Status.RspMsg = ex.Message;
                    result.MergeResResult(res);
                }
            }
            return result;
        }

        public IResResult QueryTransStatus(ITransferQueryDataList TransferQueryData)
        {
            IResResult result = new ResResult();
            TransactionResultsMsg msg;
            SerialNumberDapperRepository serialrepository = new SerialNumberDapperRepository();
            foreach (var item in TransferQueryData.TransferQueryDatas)
            {
                msg = new TransactionResultsMsg(item);
                msg.Head.ReqSeqNo = msg.Head.ReqSeqNo + serialrepository.GetSeqNumber();
                var rt = this.queryTranactionService.PushQueryTranactionService(msg);
                result.MergeResResult(rt);
            }
            return result;
            #endregion
        }

    }
}