using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.Common
{
    /*===============================================================================================================================
		Create by Fancy in 2018/1/18 14:20:46
	====================================================================================================================================*/
    public class BankServiceConfig
    {
        /// <summary>
        /// 企业前置机
        /// </summary>
        public string Termid { get; set; }

        /// <summary>
        /// 客户端产生的报文编号
        /// </summary>
        public string Trnid { get; set; }
    }
}
