using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
    public interface IAmountScope
    {
        string From { get; set; }

        string To { get; set; }
    }
}
