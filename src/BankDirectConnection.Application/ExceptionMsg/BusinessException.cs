using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.BaseApplication.ExceptionMsg
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/12 14:25:10
	===============================================================================================================================*/
    public class BusinessException : ApplicationException
    {
        public BusinessException(string message) : base(message)
        {

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
                return "code:" + this.Code + ";message:" + base.Message;
            }
        }
    }
}
