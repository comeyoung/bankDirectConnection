using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.PushBankment.BOCService
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/11 9:53:39
	===============================================================================================================================*/
    public class BOCHttp
    {
        //T4测试环境专线 http://10.16.253.167:9082/B2EP/XmlServlet
        //T4测试环境公网 http://180.168.146.79:81/B2EP/XmlServlet
        public static string BaseUrl = "http://180.168.146.79:81/B2EP/XmlServlet";
    }
}
