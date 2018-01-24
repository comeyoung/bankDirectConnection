using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
    public interface IHeader
    {
        /// <summary>
        /// 企业前置机
        /// </summary>
        string Termid { get; set; }

        /// <summary>
        /// 客户端产生的报文编号
        /// </summary>
        string Trnid { get; set; }

        /// <summary>
        /// 企业在中行网银系统的客户编号
        /// </summary>
        string Custid { get; set; }

        /// <summary>
        /// 企业操作员代码
        /// </summary>
        string Cusopr { get; set; }

        /// <summary>
        /// 交易代码 b2e开头加4位数字
        /// </summary>
        string Trncod { get; set; }

        string Token { get; set; }

        /// <summary>
        /// 交易流水号
        /// </summary>
        string Obssmsgid { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        string TrnTyp { get; set; }
    }
}
