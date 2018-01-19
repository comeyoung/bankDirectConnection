using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.Domain.TransferBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.SGB.PaymentMsg
{
    public interface IForeignCurryPaymentMsg: IBaseSGBTranscation
    {
        #region property
        /// <summary>
        /// 国际银行编码
        /// </summary>
        string BeneSwifCode { get; set; }

        /// <summary>
        /// 参考汇率
        /// </summary>
         string Rate { get; set; }
        
        #endregion
    }
}
