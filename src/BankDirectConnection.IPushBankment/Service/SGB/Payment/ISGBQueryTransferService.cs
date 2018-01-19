using BankDirectConnection.Domain.Service;
using BankDirectConnection.Domain.SGB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.IPushBankment.Service.SGB.Payment
{
    public interface ISGBQueryTransferService<T> where T : IBaseSGBTranscation
    {
         IResResult PushQueryTranactionService(T Msg);
      
    }
}
