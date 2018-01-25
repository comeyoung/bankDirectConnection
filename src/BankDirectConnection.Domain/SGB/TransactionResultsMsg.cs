using BankDirectConnection.Domain.QueryBO;
using BankDirectConnection.Domain.SGB.PaymentMsg;
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
    public class TransactionResultsMsg : ITransactionResultsMsg
    {
        public TransactionResultsMsg()
        {
            this.Head = new CommonHeader();
            this.Trans = new TransactionResults();
        }


        public TransactionResultsMsg(ITransferQueryDataList TransferQueryData)
        {
            this.Head = new CommonHeader();
            this.Trans = new TransactionResults();
            this.Create(TransferQueryData);
        }
        public CommonHeader Head
        {
            get;
            set;
        }
       
        public TransactionResults Trans { get; set; }

        public bool Check()
        {
            throw new NotImplementedException();
        }

        private TransactionResultsMsg Create(ITransferQueryDataList TransferQueryData)
        {
            //< CCTransCode > SGT002 </ CCTransCode >
            //< ReqSeqNo > 02201801221014590002 </ ReqSeqNo >
            //< ReqDate > 20180117 </ ReqDate >
            //< ReqTime > 请求时间（到毫秒）</ ReqTime >
            //< ProductID > ID </ ProductID > 
            //< ChannelType > ERP </ ChannelType >
            foreach (var item in TransferQueryData.TransferQueryDatas) {                                     
                this.Trans.CmeSeqNo = item.ClientId;
                this.Trans.StartDate = item.StartDate;
                this.Head.ReqDate = item.StartDate;
                this.Head.ReqTime = item.StartTime;
            }
            return this;
        }
    }
    public class TransactionResults{

       

        public string CmeSeqNo { get; set; }
        public string StartDate { get; set; }

    


    }
}
