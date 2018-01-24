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
    public class ResResult: IResResult
    {
        public ResResult()
        {
            this.Status = new Status();
            this.Response = new List<IResponse>();
        }
        public ResResult(string ErrorCode,string ErrorMsg)
        {
            this.Status = new Status();
            this.Response = new List<IResponse>();
            this.Status.RspCod = ErrorCode;
            this.Status.RspMsg = ErrorMsg;
        }

        public static IResResult Create(QueryTransactionResultsResponse rt)
        {
            //TODO 合并SGB转账业务返回的信息

            throw new NotImplementedException();
        }
        
        /// <summary>
        /// 处理BOC返回值
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static IResResult Create(ResponseMsg msg)
        {
            if (msg==null) {
                throw new InnerException("2012001", "Internal processing abnormality");
            }
            IResResult result = new ResResult();
            result.Status = msg.Status;
            if (result.Status.RspCod == "B001")
            {
                result.Status.RspCod = "0";                
            }
            foreach (var item in msg.DetailResponses)
            {
                Status status = new Status();
                if(item.Status.RspCod == "B001")
                {
                    status.RspCod = "0";
                    status.RspMsg = item.Status.RspMsg;

                }
                else
                {
                    //错误处理
                    // TODO
                    result.Status.RspCod = item.Status.RspCod;
                    result.Status.RspMsg = item.Status.RspMsg;
                }
                result.Response.Add(new Response() { Status = status, ClientId = item.Insid, ObssId = item.Obssid, InsId = Instruction.NewInsSid("01") });
            }


            return result;
        }

        public static IResResult Create<T>(T TransMsg, ResponseMsg Msg) where T : IBaseBOCTranscation
        {
            IResResult result = new ResResult();
            result.Status.RspCod = "0";
            result.Status.RspMsg = "OK";
            IResponse res;
            if(typeof(T) == typeof(IWageAndReimbursementMsg))
            {
                foreach (var item in Msg.DetailResponses)
                {
                    
                    res = new Response();
                    res.InsId = item.Insid;
                    res.ClientId = ((IWageAndReimbursementMsg)TransMsg).Trans.ClientId;
                    if (item.Status.RspCod != "B001")
                        result.Status = item.Status;
                    else
                    {
                        res.Status.RspCod = "0";
                        res.Status.RspMsg = "OK";
                    }

                    result.Response.Add(res);
                }
            }
            else if(typeof(T) == typeof(IPaymentsToPublicMsg))
            {
                foreach (var item in Msg.DetailResponses)
                {
                    res = new Response();
                    res.InsId = item.Insid;
                    res.ClientId = ((IPaymentsToPublicMsg)TransMsg).Trans.ToList().Find(c=>c.EDIId == item.Insid).ClientId;
                    if (item.Status.RspCod != "B001")
                        result.Status = item.Status;
                    else
                    {
                        res.Status.RspCod = "0";
                        res.Status.RspMsg = "OK";
                    }
                    result.Response.Add(res);
                }
            }else if(typeof(T) == typeof(ITransactionStatusInquiryMsg))
            {
                foreach (var item in Msg.DetailResponses)
                {
                    res = new Response();
                    res.InsId = item.Insid;
                    res.ClientId = ((ITransactionStatusInquiryMsg)TransMsg).Trans.ToList().Find(c => c.EDIId == item.Insid).ClientId;
                    if (item.Status.RspCod != "B001")
                        result.Status = item.Status;
                    else
                    {
                        res.Status.RspCod = "0";
                        res.Status.RspMsg = "OK";
                    }
                    result.Response.Add(res);
                }
            }
            return result;
        }

        /// <summary>
        /// 处理SGB返回值
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public static IResResult Create(CommonResponseMsg msg)
        {
            IResResult result = new ResResult();

            if(null == msg.RespCode)
                throw new InnerException("2022002", "Transaction information can not be empty ");
            if (msg.RespCode == "0000" || msg.RespCode == "0005" || msg.RespCode == "0006")
            {
                result.Status.RspCod = "0";
                result.Status.RspMsg = msg.RespInfo;
            }
            else {
                result.Status.RspCod = "100";
                result.Status.RspMsg = "error";
            }
            return result;
        }
        public static IResResult SGBCreate<T>(T TransMsg, CommonResponseMsg Msg) where T : IBaseSGBTranscation
        {
            IResResult result = new ResResult();
            result.Status.RspCod = "0";
            result.Status.RspMsg = "OK";
            IResponse res;
            if (typeof(T) == typeof(IForeignCurryPaymentMsg))
            {               
                    res = new Response();
                    res.InsId = Msg.HostSeqNo;
                    res.ClientId = TransMsg.ClientId;
              if (Msg.RespCode == "0000"|| Msg.RespCode == "0005" || Msg.RespCode == "0006") {
                    res.Status.RspCod = "0";
                    res.Status.RspMsg = "OK";
                }
                else
                {
                    result.Status.RspMsg = Msg.RespInfo;
                }
                result.Response.Add(res);


            }
            else if (typeof(T) == typeof(IInnerTransferMsg))
            {
                res = new Response();
                res.InsId = Msg.HostSeqNo;
                res.ClientId = TransMsg.ClientId;
                if (Msg.RespCode == "0000" || Msg.RespCode == "0005" || Msg.RespCode == "0006")
                {
                    res.Status.RspCod = "0";
                    res.Status.RspMsg = "OK";
                }
                else
                {
                    result.Status.RspMsg = Msg.RespInfo;
                }
                result.Response.Add(res);
            }
            else if (typeof(T) == typeof(IRMBPaymentMsg))
            {
                res = new Response();
                res.InsId = Msg.HostSeqNo;
                res.ClientId = TransMsg.ClientId;
                if (Msg.RespCode == "0000" || Msg.RespCode == "0005" || Msg.RespCode == "0006")
                {
                    res.Status.RspCod = "0";
                    res.Status.RspMsg = "OK";
                }
                else
                {
                    result.Status.RspMsg = Msg.RespInfo;
                }
                result.Response.Add(res);
            }
            return result;
        }
        public IResResult MergeResResult(IResResult ResResult)
        {
            if (string.IsNullOrEmpty(this.Status.RspCod)) {
                this.Status.RspCod = "0";
            }
            else if (this.Status.RspCod == "0" && ResResult.Status.RspCod == "0")
            {
                this.Status.RspCod = "0";
            }
            else if(ResResult.Status.RspCod !="0")
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
            if("B001" != Result.Status.RspCod)
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

   

    public class Response: IResponse
    {
        public Response() {
            this.Status = new Status();
        }
        public Status Status { get; set; }

        /// <summary>
        /// 客户端生成
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// 转账指令ID 中间件生成
        /// </summary>
        public string InsId { get; set; }

        /// <summary>
        /// 网银交易流水号
        /// </summary>
        public string ObssId { get; set; }
    }
}
