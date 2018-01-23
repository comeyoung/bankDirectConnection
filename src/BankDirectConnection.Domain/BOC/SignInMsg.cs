using BankDirectConnection.Domain.BOC.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
    /*===============================================================================================================================
	*	Create by Fancy at 2017/12/24 16:30:46
	===============================================================================================================================*/
    public class SignInMsg
    {
        public SignInMsg()
        {
            this.HeaderMessage = new Header();
            this.Trans = new SignInTrans();
        }
        public Header HeaderMessage { get; set; }

        public SignInTrans Trans { get; set; }

    }

    /// <summary>
    /// 签到消息体
    /// </summary>
    public class SignInTrans
    {
        public string Custdt { get; set; }

        public string Oprpwd { get; set; }

        public string Ceitinfo { get; set; }

        public string UsbKey { get; set; }
    }
}
