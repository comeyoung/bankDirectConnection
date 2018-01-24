using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.BOC.Message;
using BankDirectConnection.Domain.QueryBO;
using System;
using System.Collections.Generic;

namespace BankDirectConnection.Domain.BOC
{
    /*===============================================================================================================================
	*	Create by Fancy at 2017/12/24 17:59:43
	===============================================================================================================================*/
    /// <summary>
    /// 交易状态查询
    /// </summary>
    public class TransactionStatusInquiryMsg: ITransactionStatusInquiryMsg,ICheckAble
    {
        public TransactionStatusInquiryMsg()
        {
            this.HeaderMessage = new Header();
            this.Trans = new List<ITransactionStatusInquiry>();
            
        }

        public TransactionStatusInquiryMsg(ITransferQueryDataList TransferQueryDataList)
        {
            this.HeaderMessage = new Header();
            this.Trans = new List<ITransactionStatusInquiry>();
            this.Create(TransferQueryDataList);
            this.Check();
        }
        public Header HeaderMessage { get; set; }

        public List<ITransactionStatusInquiry> Trans { get; set; }

        public bool Check()
        {
            if (this.Trans.Count >= 100)
                throw new BusinessException("2012003", "The number of bills cannot exceed 100");
            return true;
        }

        private void Create(ITransferQueryDataList TransferQueryDataList)
        {
            foreach (var item in TransferQueryDataList.TransferQueryDatas)
            {
                this.Trans.Add(new TransactionStatusInquiry(item));
            }
        }
    }

    public class TransactionStatusInquiry: ITransactionStatusInquiry
    {
        /// <summary>
        ///  转账指令
        /// </summary>
        public string Insid { get; set; }

        /// <summary>
        /// 网银交易流水号
        /// </summary>
        public string Obssid { get; set; }

        public TransactionStatusInquiry() {
        }
        public TransactionStatusInquiry(ITransferQueryData Data)
        {
            this.Insid = Data.ClientId;
            this.Obssid = Data.ObssId;
            this.Check();
        }
        public  bool Check()
        {
            if (string.IsNullOrEmpty(this.Obssid) && string.IsNullOrEmpty(this.Insid)) {
                throw new BusinessException("the purpose of trans can't be null if choosed the convient transfer") { Code = "1011010" };
            } else if (this.Obssid.Length > 19) {
                throw new BusinessException("Online banking transaction serial number is not more than 19 ") { Code = "2011001" };
            } else if (this.Insid.Length < 32) {
                throw new BusinessException("The transfer instruction ID does not exceed 32") { Code = "2011001" };
            }
            return true;
        }

    }
}
