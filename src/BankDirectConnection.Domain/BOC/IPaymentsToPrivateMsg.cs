using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/31 16:52:48
	===============================================================================================================================*/
    public interface IPaymentsToPrivateMsg: IBaseBOCTranscation
    {
        IList<IPaymentsToPrivateTrans> Trans { get; set; }
    }
}
