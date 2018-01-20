using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
    public interface ITransactionStatusInquiry
    {
         string Insid { get; set; }

        /// <summary>
        /// 网银交易流水号
        /// </summary>
         string Obssid { get; set; }

         
    }
}
