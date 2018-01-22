using BankDirectConnection.Domain.BOC.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
    /*===============================================================================================================================
	*	Create by Fancy at 2017/12/24 17:58:25
	===============================================================================================================================*/
    /// <summary>
    /// 交易查询
    /// </summary>
    public class TransactionInquiryMsg : ITransactionInquiryMsg
    {
        public TransactionInquiryMsg()
        {
            this.HeaderMessage = new Header();
            this.Trans = new TransactionInquiryTrans();
        }
        public Header HeaderMessage { get; set; }
        public TransactionInquiryTrans Trans { get; set; }
    }

    public  class TransactionInquiryTrans: ITransactionInquiryTrans
    {
        public string Ibknum { get; set; }

        public string Actacn { get; set; }

        public string Type { get; set; }

        public string Begnum { get; set; }

        public string Recnum { get; set; }

        public string Direction { get; set; }

        public DateScope DateScope { get; set; }

        public AmountScope AmountScope { get; set; }

        public TransactionInquiryTrans()
        {
            this.DateScope = new DateScope();
            this.AmountScope = new AmountScope();
        }
    }

    public class DateScope: IDateScope
    {
        public string From { get; set; }

        public string To { get; set; }
    }

    public class AmountScope : IAmountScope
    {
        public string From { get; set; }

        public string To { get; set; }
    }

    
}
