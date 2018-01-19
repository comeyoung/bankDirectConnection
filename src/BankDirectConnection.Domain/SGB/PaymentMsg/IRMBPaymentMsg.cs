using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.Domain.TransferBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.SGB.PaymentMsg
{
    interface IRMBPaymentMsg: IBaseSGBTranscation
    {

        #region property

       

        /// <summary>
        /// 加急标志
        /// </summary>
        string Priority { get; set; }

       
        #endregion

        

      
    }
}
    