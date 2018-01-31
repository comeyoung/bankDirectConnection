using BankDirectConnection.Domain.BOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.IPushBankment.Service.BOC
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/31 19:08:37
	===============================================================================================================================*/
    public interface IPaymentsToPrivateService: IBOCPaymentTransferService<IPaymentsToPrivateMsg>
    {
    }
}
