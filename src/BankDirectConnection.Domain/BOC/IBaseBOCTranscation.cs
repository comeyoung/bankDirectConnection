using BankDirectConnection.Domain.BOC.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
    /*===============================================================================================================================
		Create by Fancy in 2018/1/19 17:25:10
	===============================================================================================================================*/

    public interface IBaseBOCTranscation
    {
         Header HeaderMessage { get; set; }
    }
}
