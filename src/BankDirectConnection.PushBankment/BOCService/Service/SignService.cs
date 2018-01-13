using BankDirectConnection.Domain.BOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.PushBankment.BOCService.Service
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/13 17:37:40
	===============================================================================================================================*/
    public class SignService
    {
        /// <summary>
        /// 签到
        /// </summary>
        /// <returns></returns>
        public ResponseMsg PushSignIn()
        {
            SignInMsg msg = new SignInMsg();
            msg.HeaderMessage.Cusopr = "EDF";
            msg.HeaderMessage.Custid = "";
            msg.HeaderMessage.Trncod = "";
            msg.HeaderMessage.Trnid = "";
            msg.Trans.Custdt = DateTime.Now.ToString("yyyyMMddHHddss");
            msg.Trans.Oprpwd = "";
            string transXML = Serialization.BuildXMLStrForSignInByLinq(msg);
            var rt = BOCHttp.PostRequest(transXML);
            return Deserialization.ParseResponseMsg(rt, "b2e0001");
        }

    }
}
