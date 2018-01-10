using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Application.Transfer
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 11:03:53
	===============================================================================================================================*/
    public abstract class AbastractTrans
    {
        public virtual bool Check()
        {
            return true;
        }
    }
}
