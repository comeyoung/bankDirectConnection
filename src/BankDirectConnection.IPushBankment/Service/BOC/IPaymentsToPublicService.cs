using BankDirectConnection.Domain.BOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.IPushBankment.Service.BOC
{
    public interface IPaymentsToPublicService : IBOCPaymentTransferService<IPaymentsToPublicMsg>
    {
    }
}
