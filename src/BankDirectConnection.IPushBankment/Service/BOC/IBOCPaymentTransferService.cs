using BankDirectConnection.Domain.BOC;
using BankDirectConnection.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.IPushBankment.Service.BOC
{
    public interface IBOCPaymentTransferService<T> where T: IBaseBOCTranscation
    {
        IResResult PushPaymentTransferInfo(T Msg);
    }

}
