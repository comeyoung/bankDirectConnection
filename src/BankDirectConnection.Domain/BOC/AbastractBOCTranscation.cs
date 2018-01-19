using BankDirectConnection.BaseApplication.BaseTranscation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankDirectConnection.Domain.BOC.Message;

namespace BankDirectConnection.Domain.BOC
{
    public abstract class AbastractBOCTranscation : IBaseBOCTranscation, ICheckAble
    {
        public Header HeaderMessage { get; set; }

        public virtual bool Check()
        {
            // TODO 做一些基本的校验
            return true;
        }
    }
}
