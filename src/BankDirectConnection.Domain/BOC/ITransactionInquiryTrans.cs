using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
    public interface ITransactionInquiryTrans
    {
         string Ibknum { get; set; }

         string Actacn { get; set; }

        string Type { get; set; }

        string Begnum { get; set; }

        string Recnum { get; set; }

        string Direction { get; set; }

        DateScope DateScope { get; set; }

        AmountScope AmountScope { get; set; }

    }
}
