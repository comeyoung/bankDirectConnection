using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.DataHandle
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/11 17:06:40
	===============================================================================================================================*/
    public class DataConvert
    {
        public static string ConvertStr(string value)
        {
            if (string.IsNullOrEmpty(value))
                return string.Empty;
            return value;
        }
    }
}
