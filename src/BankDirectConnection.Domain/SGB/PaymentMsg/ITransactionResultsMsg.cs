using BankDirectConnection.BaseApplication.BaseTranscation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.SGB.PaymentMsg
{
    interface ITransactionResultsMsg : ISGBHeader,ICheckAble
    {
        TransactionResults Trans { get; set; }
        
    }
    
}

