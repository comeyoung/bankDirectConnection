﻿using BankDirectConnection.Domain.SGB.PaymentMsg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.IPushBankment.Service.SGB
{
    /*===============================================================================================================================
		Create by Fancy in 2018/1/19 14:02:14
	===============================================================================================================================*/

    /// <summary>
    /// 外币转账接口
    /// </summary>
    public interface IForeignCurryPaymentService: ISGBPaymentTransferService<IForeignCurryPaymentMsg>
    {

    }
}
