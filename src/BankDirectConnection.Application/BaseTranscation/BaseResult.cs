using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.BaseApplication.BaseTranscation
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/12 14:31:00
	===============================================================================================================================*/
    public class BaseResult: IBaseResult
    {
        public BaseResult()
        {
            this.Status = new Status();
        }
        public IStatus Status { get; set; }
    }

    public class Status : IStatus
    {
        public string RspCod { get; set; }

        public string RspMsg { get; set; }

        /// <summary>
        /// 请求是否成功
        /// </summary>
        /// <returns>成功：true;失败：false</returns>
        public bool IsSuccess()
        {
            switch (this.RspCod)
            {
                case "B001":
                case "B002":
                case "B054":
                case "B059":
                case "B149":
                case "B150":
                    return true;
                default:
                    return false;

            }
        }
    }
}
