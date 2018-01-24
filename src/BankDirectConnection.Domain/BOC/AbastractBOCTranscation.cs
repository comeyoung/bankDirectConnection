using BankDirectConnection.BaseApplication.BaseTranscation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankDirectConnection.Domain.BOC.Message;
using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.TransferBO;

namespace BankDirectConnection.Domain.BOC
{
    public abstract class AbastractBOCTranscation : IBaseBOCTranscation, ICheckAble
    {
        public AbastractBOCTranscation() { }
        public AbastractBOCTranscation(ITranscation Transcation)
        {
            this.ClientId = Transcation.ClientId;
            this.EDIId = Transcation.EDIId;
        }
        public string EDIId
        {
            get;set;
        }

        public IHeader HeaderMessage { get; set; }

        public string ClientId
        {
            get;set;
        }


        public virtual bool Check()
        {
            // TODO 做一些基本的校验
            if(string.IsNullOrEmpty(this.HeaderMessage.Cusopr))
                throw new BusinessException("","");
            if(string.IsNullOrEmpty(this.HeaderMessage.Trncod))
                throw new BusinessException("","");
            if(string.IsNullOrEmpty(this.HeaderMessage.Custid))
                throw new BusinessException("","");
            return true;
        }
    }
}
