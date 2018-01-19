using System;
using BankDirectConnection.Application.Transfer;
using BankDirectConnection.Domain.QueryBO;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.Domain.TransferBO;
using System.Collections.Generic;
using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.PushBankment.SGBService.Service;
using BankDirectConnection.Domain.SGB;
using BankDirectConnection.Domain.DataHandle;
using System.Linq;
using BankDirectConnection.IPushBankment.Service.SGB;
using BankDirectConnection.Domain.SGB.PaymentMsg;

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
       // private readonly IQueryTranactionStatusService queryTranactionStatusService;
        public SGBService(IForeignCurryPaymentService ForeignCurryService,
            IInnerPaymentService InnerPaymentService,
            IRMBPaymentService RMBPaymentService)
        {
            this.foreignCurryService = ForeignCurryService;
            this.innerPaymentService = InnerPaymentService;
            this.rmbPaymentServie = RMBPaymentService;
        }
        public SGBService()
        {

        }
        public IResResult PaymentTransfer(ITranscations Transcation)
        {
            IResResult result = new ResResult();
            IResResult Sresult = new ResResult();
            IResponse rt;
            

            foreach (var item in Transcation.Transcations)
            {
                rt = new Response();
                try
                {
                    // 明细只能一行
                    if (item.TransDetail.Count != 1)
                        throw new BusinessException("2021001", "the transaction will not be more than one");
                    #region 处理接口调用
                    var detail = item.TransDetail.FirstOrDefault();
                    // 如果收款人账号是我行（法兴）走行内转账
                    if ((!string.IsNullOrEmpty(detail.ToAcct.BankId) && detail.ToAcct.BankId.Length == 12 && detail.ToAcct.BankId.Substring(0, 3) == emBankNo.SG.ToString())
                                  || (!string.IsNullOrEmpty(detail.ToAcct.BankName) && detail.ToAcct.BankName.Contains("兴业银行")))
                    {
                        Sresult = this.innerPaymentService.PushPaymentTranscationInfo(new InnerTransferMsg(item));
                    }
                    else
                    {
                        // 如果收款人币种是人民币，走人民币付款
                        if (!string.IsNullOrEmpty(detail.TransCur) && (detail.TransCur.Equals("CNY") || detail.TransCur.Equals("RMB")))
                        {
                            Sresult = this.rmbPaymentServie.PushPaymentTranscationInfo(new RMBPaymentMsg(item));
                        }
                        // 如果收款人币种是外币，走外币付款
                        else
                        {
                            Sresult = this.foreignCurryService.PushPaymentTranscationInfo(new ForeignCurryPaymentMsg(item));
                        }

                    }

                    // 处理结果
                    if (null == result)
                    {
                        result = Sresult;
                    }
                    else
                    {
                        result.MergeResResult(result);
                    }
                }
                catch (BusinessException ex)
                {
                    rt.Status.RspCod = ex.Code;
                    rt.Status.RspMsg = ex.Message;
                    result.Response.Add(rt);
                }
            }
            return result;
        }

        public IResResult QueryTransStatus(ITransferQueryDataList TransferQueryData)
        {
            IResResult result = new ResResult();

            TransactionResultsMsg msg;
            foreach (var item in TransferQueryData.TransferQueryDatas)
            {
                msg = new TransactionResultsMsg(TransferQueryData);
                QueryTranactionStatusService service = new QueryTranactionStatusService();
                var rt = service.PushQueryTranactionService(msg);
                result.MergeResResult(rt);
            }
            return result;
            #endregion
        }

    }
}