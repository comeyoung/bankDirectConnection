using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.Enterprise
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/3/8 14:50:29
	===============================================================================================================================*/
    public class EnterpriseInfo : IEnterpriseInfo
    {
        public string BankType
        {
            get;set;
        }

        public string GroupNumber
        {
            get;set;
        }

        public string Operator
        {
            get;set;
        }

        public string OperatorPsw
        {
            get;set;
        }

        public string UsbKey
        {
            get;set;
        }
    }
}
