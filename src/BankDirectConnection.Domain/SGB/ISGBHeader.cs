using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.SGB
{
    public interface ISGBHeader
    {
        CommonHeader Head { get; set; }
    }
}
