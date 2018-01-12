using BankDirectConnection.BaseApplication.ExceptionMsg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.BaseApplication.BaseTranscation
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/12 14:22:01
	===============================================================================================================================*/
    public abstract class BaseTranscation
    {
        public IAccount FromAcct
        {
            get; set;
        }

        public virtual bool Check()
        {
            if (string.IsNullOrEmpty(FromAcct.AcctId))
                throw new BusinessException("the value of from account's account id is null .") { Code = "1001001" };
            if (string.IsNullOrEmpty(FromAcct.BankId))
                throw new BusinessException("the value of from account's bank id is null .") { Code = "1001002" };
            return true;
        }
    }
}
