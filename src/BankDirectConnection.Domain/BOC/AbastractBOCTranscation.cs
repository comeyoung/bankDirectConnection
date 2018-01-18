using BankDirectConnection.BaseApplication.BaseTranscation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
    public abstract class AbastractBOCTranscation : ICheckAble
    {
        public virtual bool Check()
        {
            // TODO 做一些基本的校验
            return true;
        }
    }
}
