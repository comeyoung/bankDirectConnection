using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.BaseApplication.BaseTranscation
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/12 14:21:35
	===============================================================================================================================*/
    public interface IBaseTranscation
    {
        bool Check();

        /// <summary>
        /// 付款账号信息
        /// </summary>
        IAccount FromAcct { get; set; }
    }
}
