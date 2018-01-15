using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.Domain.BOC;
using BankDirectConnection.Domain.DataHandle;
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

        public static IResResult Create(ResponseMsg msg,string TransWay)
        {
            IResResult result = new ResResult();
            result.Status = msg.Status;
            foreach (var item in msg.DetailResponses)
            {
                IStatus status = new Status();
                if(item.Status.RspCod == "B001")
                {
                    status.RspCod = "0";
                    status.RspMsg = item.Status.RspMsg;
                }
                else
                {
                    //错误处理
                    // TODO
                }
                result.Response.Add(new Response() { Status = item.Status, ClientId = item.Insid, ObssId = item.Obssid, InsId = Instruction.NewInsSid(TransWay) });
            }


            return result;
        }

        public IResResult MergeResResult(IResResult ResResult)
        {
            if(this.Status.RspCod == "0" && ResResult.Status.RspCod == "0")
            {
                this.Status.RspCod = "0";
            }
            else
            {
                this.Status.RspCod = "2";
            }
            foreach (var item in ResResult.Response)
            {
                this.Response.Add(item);
            }
            return this;
        }

        public IStatus Status { get; set; }

        public IList<IResponse> Response { get; set; }

    }

   

    public class Response: IResponse
    {
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
