using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.SGB
{
    /// <summary>
    /// 交易结果查询
    /// </summary>
    public class TransactionResultsMsg : ISGBHeader
    {
        public TransactionResultsMsg()
        {
            this.Head = new CommonHeader();
            this.Trans = new TransactionResults();
        }

        public CommonHeader Head
        {
            get;
            set;
        }

        public TransactionResults Trans { get; set; }
    }
    public class TransactionResults{
    public string CmeSeqNo { get; set; }
    public string StartDate { get; set; }

    


    }
}
