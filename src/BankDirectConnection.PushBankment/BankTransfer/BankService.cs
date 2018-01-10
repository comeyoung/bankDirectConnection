using BankDirectConnection.Application.Transfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.PushBankment.BankTransfer
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 12:04:28
	===============================================================================================================================*/
    /// <summary>
    /// 银行服务
    /// </summary>
    public class BankService : IBankService
    {
        public void PaymentTransfer()
        {
           //获取银行信息，调用具体银行的服务
        }

        public void QueryTransStatus()
        {
            //获取银行信息，调用具体银行的服务
        }
    }
}
