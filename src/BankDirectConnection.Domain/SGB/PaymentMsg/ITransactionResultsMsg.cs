using BankDirectConnection.BaseApplication.BaseTranscation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.SGB.PaymentMsg
{
    public interface ITransactionResultsMsg : IBaseSGBTranscation, ISGBHeader, ICheckAble
    {
        ITransactionResults Trans { get; set; }
        
    }
    
    public interface ITransactionResults
    {
         string CmeSeqNo { get; set; }
         string StartDate { get; set; }
    }
}

