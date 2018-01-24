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
         string ClientId { get; set; }
         string EDIId { get; set; }

        IHeader HeaderMessage { get; set; }
    }
}
