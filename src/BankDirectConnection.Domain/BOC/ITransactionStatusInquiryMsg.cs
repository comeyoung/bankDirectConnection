using BankDirectConnection.Domain.BOC.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
    public interface ITransactionStatusInquiryMsg
    {
        Header HeaderMessage { get; set; }
        List<ITransactionStatusInquiry> Trans { get; set; }
    }
}
