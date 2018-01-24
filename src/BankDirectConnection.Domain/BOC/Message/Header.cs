using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC.Message
{
    /*===============================================================================================================================
	*	Create by Fancy at 2017/12/24 16:24:29
	===============================================================================================================================*/
    /// <summary>
    /// 消息头
    /// </summary>
    public class Header:IHeader
    {
        public Header() { }
        public Header(string TransType)
        {
            this.Cusopr = "136140253";
            this.Custid = "133812368";
            this.Termid = "E163083136140";
            // this.Trnid = DateTime.Now.ToString("yyyyMMddHHmmss");
            this.Trncod = TransType;
        }
        /// <summary>
        /// 企业前置机
        /// </summary>
        public string Termid { get; set; }

        /// <summary>
        /// 客户端产生的报文编号
        /// </summary>
        public string Trnid { get; set; }

        /// <summary>
        /// 企业在中行网银系统的客户编号
        /// </summary>
        public string Custid { get; set; }

        /// <summary>
        /// 企业操作员代码
        /// </summary>
        public string Cusopr { get; set; }

        /// <summary>
        /// 交易代码 b2e开头加4位数字
        /// </summary>
        public string Trncod { get; set; }

        public string Token { get; set; }

        /// <summary>
        /// 交易流水号
        /// </summary>
        public string Obssmsgid { get; set; }
        /// <summary>
        /// 业务类型
        /// </summary>
        public string TrnTyp { get; set; }
    }
}
