using BankDirectConnection.Domain.Service;
using BankDirectConnection.Domain.SGB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.IPushBankment.Service.SGB
{
   public interface ISGBPaymentTransferService<T> where T : IBaseSGBTranscation
    {
          IResResult PushPaymentTranscationInfo(T Msg);
       
    }
}
