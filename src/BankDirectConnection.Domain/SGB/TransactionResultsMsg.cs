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
        
        public TransactionResultsMsg(ITransferQueryData TransferQueryData)
        {
            this.Head = new CommonHeader();
            this.Trans = new TransactionResults();
            this.Create(TransferQueryData);
        }

        #region property
        /// <summary>
        /// 客户端流水号
        /// </summary>
        public string ClientId
        {
            get; set;
        }
        /// <summary>
        /// EDI平台Id
        /// </summary>
        public string EDIId
        {
            get; set;
        }

        public CommonHeader Head
        {
            get;
            set;
        }

        public ITransactionResults Trans { get; set; }
        #endregion


        public bool Check()
        {
            throw new NotImplementedException();
        }

        private TransactionResultsMsg Create(ITransferQueryData TransferQueryData)
        {
            this.Trans.CmeSeqNo = TransferQueryData.ClientId;
            this.Trans.StartDate = TransferQueryData.StartDate;
            this.Head.ReqDate = TransferQueryData.StartDate;
            this.Head.ReqTime = TransferQueryData.StartTime;
            this.ClientId = TransferQueryData.ClientId;
            this.EDIId = TransferQueryData.EDIId;
            return this;
        }
    }
    public class TransactionResults: ITransactionResults
    {
        /// <summary>
        /// 客户端请求流水
        /// </summary>
        public string CmeSeqNo { get; set; }
        /// <summary>
        /// 起始时间
        /// </summary>
        public string StartDate { get; set; }
        
    }
}
