using BankDirectConnection.DapperRepository;
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
            //msg.HeaderMessage.Cusopr = "136140253";
            //msg.HeaderMessage.Custid = "133812368";
            //msg.HeaderMessage.Trncod = "b2e0001";
            //msg.HeaderMessage.Trnid = "";
            //msg.HeaderMessage.Termid = "E163083136140";
            //msg.Trans.Custdt = DateTime.Now.ToString("yyyyMMddHHddss");
            //msg.Trans.Oprpwd = "4u7hc9Dy";
            EnterpriseInfoDapperRepository epInfoRepo = new EnterpriseInfoDapperRepository();
            var epInfo = epInfoRepo.GetEnterprise("BOC").FirstOrDefault();
            if(epInfo != null)
            {
                msg.HeaderMessage.Cusopr = epInfo.Operator;
                msg.HeaderMessage.Custid = epInfo.GroupNumber;
                msg.HeaderMessage.Trncod = "b2e0001";
                msg.HeaderMessage.Trnid = "";
                msg.HeaderMessage.Termid = "E163083136140";
                msg.Trans.Custdt = DateTime.Now.ToString("yyyyMMddHHddss");
                msg.Trans.Oprpwd = epInfo.OperatorPsw;
            }

            string transXML = Serialization.BuildXMLStrForSignInByLinq(msg);
            var rt = BOCHttp.PostRequest(transXML);
            return Deserialization.ParseResponseMsg(rt, "b2e0001");
        }

    }
}
