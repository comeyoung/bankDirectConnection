using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.BaseApplication.DataHandle;
using BankDirectConnection.Domain.TransferBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.SGB.PaymentMsg
{
    public interface IRMBPaymentMsg: IBaseSGBTranscation
    {
        #region property

        /// <summary>
        /// 加急标志
        /// </summary>
        emPriolv Priority { get; set; }
        #endregion
      
    }
}
    