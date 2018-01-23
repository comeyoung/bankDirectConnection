using BankDirectConnection.BaseApplication.DataHandle;
using BankDirectConnection.Domain.BOC.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
    /*===============================================================================================================================
	*	Create by Fancy at 2017/12/24 17:50:41
	===============================================================================================================================*/
    /// <summary>
    /// 余额查询
    /// </summary>
    public class BalanceInquiryMsg
    {
        public BalanceInquiryMsg()
        {
            this.HeaderMessage = new Header();
            this.Trans = new BalanceInquiryTrans();
        }
        public Header HeaderMessage { get; set; }
        public BalanceInquiryTrans Trans { get; set; }
    }

    public class BalanceInquiryTrans
    {

        public emBalanceType BalanceType { get; set; }
        public string Idknum { get; set; }
        
        public string Actacn { get; set; }

        /// <summary>
        /// YYYYMMDD
        /// </summary>
        public string StartDate { get; set; }
        /// <summary>
        /// YYYYMMDD
        /// </summary>
        public string EndDate { get; set; }
    }
}
