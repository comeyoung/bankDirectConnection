using BankDirectConnection.Domain.BOC.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
    public interface ITransactionStatusInquiryMsg: IBaseBOCTranscation
    {
        
        List<ITransactionStatusInquiry> Trans { get; set; }
    }
}
