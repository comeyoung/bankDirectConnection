using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.Service
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/11 10:25:28
	===============================================================================================================================*/
    public interface IResResult
    {
         IStatus status { get; set; }

         IList<IResponse> response { get; set; }
    }

    public interface IStatus
    {
         string RspCod { get; set; }

         string RspMsg { get; set; }
    }

    public interface IResponse
    {
         Status status { get; set; }

        /// <summary>
        /// 客户端生成
        /// </summary>
         string ClientId { get; set; }

        /// <summary>
        /// 转账指令ID 中间件生成
        /// </summary>
         string InsId { get; set; }

        /// <summary>
        /// 网银交易流水号
        /// </summary>
         string ObssId { get; set; }
    }
}
