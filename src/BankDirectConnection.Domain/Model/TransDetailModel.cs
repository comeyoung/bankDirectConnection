using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.Model
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/25 9:48:16
	===============================================================================================================================*/
    public class TransDetailModel
    {
        public string EDIId { get; set; }

        public string ClientId { get; set; }

        public int LineId { get; set; }

        public string BankId { get; set; }

        public string BankName { get; set; }

        public string AcctId { get; set; }

        public string AcctName { get; set; }

        public string ReciepterIdType { get; set; }

        public string ReciepterIdCode { get; set; }

        public string AcctType { get; set; }

        public string ReceipterType { get; set; }

        public Decimal TransAmount { get; set; }

        public string TransCur { get; set; }

        public string SWIFTCode { get; set; }

        public Decimal Rate { get; set; }
    }
}
