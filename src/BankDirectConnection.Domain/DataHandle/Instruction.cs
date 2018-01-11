using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.DataHandle
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/11 13:23:37
	===============================================================================================================================*/
    /// <summary>
    /// 指令处理
    /// </summary>
    public class Instruction
    {
        public static string NewInsSid()
        {
            return Guid.NewGuid().ToString().Trim('-');
        }
    }
}
