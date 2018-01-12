using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.BaseApplication.BaseTranscation
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/12 14:30:36
	===============================================================================================================================*/
    public interface IBaseResult
    {
        IStatus Status { get; set; }
    }

    public interface IStatus
    {
        string RspCod { get; set; }

        string RspMsg { get; set; }
    }
}
