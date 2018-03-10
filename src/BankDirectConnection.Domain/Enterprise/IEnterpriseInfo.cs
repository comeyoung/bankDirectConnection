using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.Enterprise
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/3/8 14:55:42
	===============================================================================================================================*/
    public interface IEnterpriseInfo
    {
        string BankType { get; set; }

        string GroupNumber { get; set; }

        string Operator { get; set; }

        string OperatorPsw { get; set; }

        string UsbKey { get; set; }
    }
}
