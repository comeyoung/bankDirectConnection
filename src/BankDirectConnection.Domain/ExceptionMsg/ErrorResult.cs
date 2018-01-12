using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.ExceptionMsg
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/12 11:45:33
	===============================================================================================================================*/
    public class ErrorResult
    {
        bool IsSuccess { get; set; }

        string ErrorCode { get; set; }

        string ErrorMsg { get; set; }
    }
}
