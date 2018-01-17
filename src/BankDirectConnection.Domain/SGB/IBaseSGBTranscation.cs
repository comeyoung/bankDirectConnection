using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.SGB
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/13 15:09:20
	===============================================================================================================================*/
    public interface IBaseSGBTranscation: ISGBHeader
    {
        string DbAccNo { get; set; }

        string CrAccNo { get; set; }
    }
}
