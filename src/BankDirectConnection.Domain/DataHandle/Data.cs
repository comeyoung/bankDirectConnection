using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.DataHandle
{
    /*===============================================================================================================================
		Create by Fancy in 2018/1/23 18:02:27
	===============================================================================================================================*/
    public class Data
    {
        /// <summary>
        /// 银行代码
        /// </summary>
        public const int BANKCODE = 3;
        /// <summary>
        /// 中行对公转账业务最大明细行
        /// </summary>
        public const int MAX_LINENUM_OF_BOC_TRANSFER = 1000;
        /// <summary>
        /// 中行交易状态查询业务最多明细行
        /// </summary>
        public const int MAX_LINENUM_OF_BOC_QUERY_TRANSFERSTATUS = 100;
        /// <summary>
        /// 中行网银交易流水最大长度
        /// </summary>
        public const int MAX_LENGTH_OF_OBSSID = 19;
    }
}
