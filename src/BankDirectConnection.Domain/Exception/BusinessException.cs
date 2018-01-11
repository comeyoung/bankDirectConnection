using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.Exception
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/11 15:03:41
	===============================================================================================================================*/
    public class BusinessException:ApplicationException
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
