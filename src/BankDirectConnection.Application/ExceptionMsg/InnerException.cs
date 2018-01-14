using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.BaseApplication.ExceptionMsg
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/14 11:34:31
	===============================================================================================================================*/
    public class InnerException: ApplicationException
    {
        public InnerException(string message) : base(message)
        {

        }

        public InnerException(string code, string message) : base(message)
        {
            this.Code = code;
        }

        public string Code
        {
            get;
            set;
        }
        public override string Message
        {
            get
            {
                return "code:" + this.Code + ";message:Inner Error." + base.Message;
            }
        }
    }
}
