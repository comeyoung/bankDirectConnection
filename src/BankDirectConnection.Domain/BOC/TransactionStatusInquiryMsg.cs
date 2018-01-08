using BankDirectConnection.Domain.BOC.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
    /*===============================================================================================================================
	*	Create by Fancy at 2017/12/24 17:59:43
	===============================================================================================================================*/
    /// <summary>
    /// 交易状态查询
    /// </summary>
    public class TransactionStatusInquiryMsg
    {
        public TransactionStatusInquiryMsg()
        {
            this.HeaderMessage = new Header();
            this.Trans = new TransactionStatusInquiry();
        }
        public Header HeaderMessage { get; set; }

        public TransactionStatusInquiry Trans { get; set; }
    }

    public class TransactionStatusInquiry
    {
        /// <summary>
        ///  转账指令
        /// </summary>
        public string Insid { get; set; }

        /// <summary>
        /// 网银交易流水号
        /// </summary>
        public string Obssid { get; set; }
    }
}
