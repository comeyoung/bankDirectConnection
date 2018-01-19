using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.Domain.TransferBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.SGB.PaymentMsg
{
    public interface IInnerTransferMsg : IBaseSGBTranscation
    {
        #region property
        
        /// <summary>
        /// 收款人省市代码
        /// </summary>
        string CrProv { get; set; }


        #endregion
    }
}
