using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.DataHandle
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/2 13:54:17
	===============================================================================================================================*/
    public class Date
    {
        /// <summary>
        /// 返回yyyyMMdd格式
        /// </summary>
        /// <param name="Date"></param>
        public static string ToString(DateTime Date)
        {
            return Date.ToString("yyyyMMdd");
        }
    }
}
