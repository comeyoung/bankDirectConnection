using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.BaseApplication.DataHandle;
using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.BOC;
using BankDirectConnection.Domain.DataHandle;
using BankDirectConnection.Domain.SGB;
using BankDirectConnection.Domain.SGB.PaymentMsg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.Service
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 17:18:55
	===============================================================================================================================*/
    /// <summary>
    /// 对外接口返回
    /// </summary>
    public class ResResult : IResResult
    {
        public ResResult()
        {
            this.Status = new Status();
            this.Response = new List<IResponse>();
        }
        public ResResult(string ErrorCode, string ErrorMsg)
        {
            this.Status = new Status();
            this.Response = new List<IResponse>();
            this.Status.RspCod = ErrorCode;
            this.Status.RspMsg = ErrorMsg;
        }

        public static IResResult Create(QueryTransactionResultsResponse Rt, ITransactionResultsMsg Msg)
        {
            IResResult result = new ResResult();
            if (null == Rt)
                throw new InnerException("2022007", "Response information can not be empty ");
            result.Status.RspCod = Rt.Trans.JnlState;
            result.Status.RspMsg = Rt.Trans.Postscript;

            var res = new Response();
            res.EDIId = Rt.Trans.CmeSeqNo;
            res.ClientId = Msg.ClientId;
            if (Rt.Trans.IsSuccess())
            {
                result.Status.RspCod = "0";
                result.Status.RspMsg = "ok";
                res.ObssId = Rt.Trans.HostSeqNo;
                res.Status = result.Status;
            }
            else
            {
                var status = new Status() { RspCod = Rt.Trans.JnlState, RspMsg = Rt.Trans.Postscript };
                result.Status = status;
                res.Status = status;
            }
            result.Response.Add(res);
            return result;
        }

        public static IResResult Create<T>(T TransMsg, ResponseMsg Msg) where T : IBaseBOCTranscation
        {
            if (Msg.DetailResponses.Count() == 0)
            {
                throw new InnerException("2012008", "返回交易信息处理异常");
            }
            IResResult result = new ResResult();
            result.Status.RspCod = "0";
            result.Status.RspMsg = "OK";
            IResponse res;

            foreach (var item in Msg.DetailResponses)
            {

                res = new Response();
                if (typeof(T) == typeof(IWageAndReimbursementMsg))
                {
                    res.ClientId = ((IWageAndReimbursementMsg)TransMsg).Trans.ClientId;
                }
                else if (typeof(T) == typeof(IPaymentsToPublicMsg))
                {
                    res.ClientId = ((IPaymentsToPublicMsg)TransMsg).Trans.ToList().Find(c => c.EDIId == item.Insid).ClientId;
                }
                else if (typeof(T) == typeof(IPaymentsToPrivateMsg))
                {
                    res.ClientId = ((IPaymentsToPrivateMsg)TransMsg).Trans.ToList().Find(c => c.EDIId == item.Insid).ClientId;
                }
                else if (typeof(T) == typeof(ITransactionStatusInquiryMsg))
                {
                    res.ClientId = ((ITransactionStatusInquiryMsg)TransMsg).Trans.ToList().Find(c => c.EDIId == item.Insid).ClientId;

                }

                res.EDIId = item.Insid;
                res.ObssId = item.Obssid;
                if (!item.Status.IsSuccess())
                {
                    res.Status = item.Status;
                    result.Status = item.Status;
                }
                else
                {
                    res.Status.RspCod = "0";
                    res.Status.RspMsg = "OK";
                }

                result.Response.Add(res);

            }


            return result;
        }










        public static IResResult Create<T>(T TransMsg, CommonResponseMsg Msg) where T : IBaseSGBTranscation
        {

            IResResult result = new ResResult();
            result.Status.RspCod = "0";
            result.Status.RspMsg = "OK";
            IResponse res;
            if (typeof(T) == typeof(IForeignCurryPaymentMsg))
            {
                res = new Response();
                res.ObssId = Msg.HostSeqNo;
                res.ClientId = TransMsg.ClientId;
                res.EDIId = TransMsg.EDIId;
                if (Msg.IsSuccess())
                {
                    res.Status.RspCod = "0";
                    res.Status.RspMsg = "OK";
                }
                else
                {
                    res.Status = new BaseApplication.BaseTranscation.Status() { RspCod = Msg.RespCode, RspMsg = Msg.RespInfo };
                    result.Status = res.Status;
                }
                result.Response.Add(res);
            }
            else if (typeof(T) == typeof(IInnerTransferMsg))
            {
                res = new Response();
                res.ObssId = Msg.HostSeqNo;
                res.ClientId = TransMsg.ClientId;
                res.EDIId = TransMsg.EDIId;
                if (Msg.IsSuccess())
                {
                    res.Status.RspCod = "0";
                    res.Status.RspMsg = "OK";
                }
                else
                {
                    res.Status = new BaseApplication.BaseTranscation.Status() { RspCod = Msg.RespCode, RspMsg = Msg.RespInfo };
                    result.Status = res.Status;
                }
                result.Response.Add(res);
            }
            else if (typeof(T) == typeof(IRMBPaymentMsg))
            {
                res = new Response();
                res.ObssId = Msg.HostSeqNo;
                res.ClientId = TransMsg.ClientId;
                res.EDIId = TransMsg.EDIId;
                if (Msg.IsSuccess())
                {
                    res.Status.RspCod = "0";
                    res.Status.RspMsg = "OK";
                }
                else
                {
                    res.Status = new BaseApplication.BaseTranscation.Status() { RspCod = Msg.RespCode, RspMsg = Msg.RespInfo };
                    result.Status = res.Status;
                }
                result.Response.Add(res);
            }
            return result;
        }
        public IResResult MergeResResult(IResResult ResResult)
        {
            if (string.IsNullOrEmpty(this.Status.RspCod))
            {
                this.Status.RspCod = "0";
            }
            else if (this.Status.RspCod == "0" && ResResult.Status.RspCod == "0")
            {
                this.Status.RspCod = "0";
            }
            else if (ResResult.Status.RspCod != "0")
            {
                this.Status.RspCod = ResResult.Status.RspCod;
                this.Status.RspMsg = ResResult.Status.RspMsg;
            }
            foreach (var item in ResResult.Response)
            {
                this.Response.Add(item);
            }
            return this;
        }

        public IResResult MergeResResult(IResponse Result)
        {
            if (!Result.Status.IsSuccess())
            {
                this.Status.RspCod = Result.Status.RspCod;
                this.Status.RspMsg = Result.Status.RspMsg;
            }
            this.Response.Add(Result);
            return this;
        }

        public IStatus Status { get; set; }

        public IList<IResponse> Response { get; set; }

    }



    public class Response : IResponse
    {
        public Response()
        {
            this.Status = new Status();
        }
        public IStatus Status { get; set; }

        /// <summary>
        /// 客户端生成
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// 转账指令ID 中间件生成
        /// </summary>
        public string EDIId { get; set; }

        /// <summary>
        /// 网银交易流水号
        /// </summary>
        public string ObssId { get; set; }

    }
}
