using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.Abstract
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/11 10:30:07
	===============================================================================================================================*/
    public abstract class AbastractTrans
    {

        public virtual bool Check()
        {
            return true;
        }
    }
}
