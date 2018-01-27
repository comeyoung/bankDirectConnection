using BankDirectConnection.BaseApplication.DataHandle;
using BankDirectConnection.BaseApplication.ExceptionMsg;
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
            this.NewEDIId();
            this.Create(TransferQueryData);
            this.Check();
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
            if (string.IsNullOrEmpty(this.Head.ReqSeqNo))
                throw new InnerException("", "");
            if (string.IsNullOrEmpty(this.Trans.CmeSeqNo))
                throw new BusinessException("1021009", "the value of EDIId is empty");
            return true;
        }

        private TransactionResultsMsg Create(ITransferQueryData TransferQueryData)
        {
            this.Head.CCTransCode = "SGQ010";
            this.Head.ReqDate = DateTime.Now.ToString("yyyyMMdd");
            this.Head.ReqTime = DateTime.Now.ToString("HHmmss")+DateTime.Now.Millisecond.ToString("000");
            this.Trans.CmeSeqNo = TransferQueryData.EDIId;
            this.Trans.StartDate = TransferQueryData.StartDate;
            this.ClientId = TransferQueryData.ClientId;
            this.EDIId = TransferQueryData.EDIId;
            return this;
        }

        public void NewEDIId()
        {
             this.Head.ReqSeqNo = Instruction.NewInsSid("02");
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
