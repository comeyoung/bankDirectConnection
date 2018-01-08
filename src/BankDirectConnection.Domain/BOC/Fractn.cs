using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
    /*===============================================================================================================================
	*	Create by Fancy at 2017/12/25 21:25:37
	===============================================================================================================================*/
   
        /// <summary>
        /// 付款人账户
        /// </summary>
        public class Fractn
        {
            /// <summary>
            /// 联行号
            /// </summary>
            public string Fribkn { get; set; }
            /// <summary>
            /// 付款账号
            /// </summary>
            public string Actacn { get; set; }
            /// <summary>
            /// 付款人名称
            /// </summary>
            public string Actnam { get; set; }
        }
    
}
