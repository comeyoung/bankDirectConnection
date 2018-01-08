using BankDirectConnection.Domain.BOC.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
    /*===============================================================================================================================
	*	Create by Fancy at 2017/12/24 16:35:25
	===============================================================================================================================*/
    public class SignOutMsg
    {
        public Header HeaderMessage { get; set; }

        public SignOutTrans Trans { get; set; }
    }
    /// <summary>
    /// 签到消息体
    /// </summary>
    public class SignOutTrans
    {
        public string Custdt { get; set; }
    }
}
