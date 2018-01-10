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
    public class ResResult
    {
        public ResResult()
        {
            this.status = new Status();
            this.response = new List<Response>();
        }

        public Status status { get; set; }

        public List<Response> response { get; set; }
    }

    public class Status
    {
        public string RspCod { get; set; }

        public string RspMsg { get; set; }
    }

    public class Response
    {
        public Status status { get; set; }

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
