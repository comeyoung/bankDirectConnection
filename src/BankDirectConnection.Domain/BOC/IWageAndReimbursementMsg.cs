using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
    /*===============================================================================================================================
		Create by Fancy in 2018/1/19 17:24:04
	===============================================================================================================================*/

    public interface IWageAndReimbursementMsg: IBaseBOCTranscation
    {
         WageAndReimbursementTrans Trans { get; set; }
    }
}
