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
    }
}
