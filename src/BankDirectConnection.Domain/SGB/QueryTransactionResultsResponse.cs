using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.SGB
{
    public class QueryTransactionResultsResponse : ISGBHeader
    {
        public QueryTransactionResultsResponse()
        {
            this.Head = new CommonHeader();
            this.Trans = new QueryTransactionResponse();
        }
             public CommonHeader Head
        {
            get;
            set;
        }
        public QueryTransactionResponse Trans { get; set; }
    }
       
        public class QueryTransactionResponse
    {
            public string CmeSeqNo { get; set; }
            public string JnlState { get; set; }
            public string Postscript { get; set; }
            public string RespSeqNo { get; set; }
            public string HostSeqNo { get; set; }
            public string CertSeqNo { get; set; }




    
    }
}
