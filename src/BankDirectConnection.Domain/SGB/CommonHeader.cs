using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.SGB
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 12:54:29
	===============================================================================================================================*/
    /// <summary>
    /// 公共包头
    /// </summary>
    public class CommonHeader
    {
        /// <summary>
        /// 内部交易代码
        /// </summary>
        public string CCTransCode { get; set; }

        /// <summary>
        /// 请求方流水号
        /// </summary>
        public string ReqSeqNo { get; set; }

        /// <summary>
        /// 请求日期
        /// </summary>
        public string ReqDate { get; set; }

        /// <summary>
        /// 请求时间（到毫秒）
        /// </summary>
        public string ReqTime { get; set; }

        public string ProductID { get; set; }

        public string ChannelType { get; set; }

        /// <summary>
        /// 客户号
        /// </summary>
        public string CorpNo { get; set; }

        /// <summary>
        /// 企业操作员编号
        /// </summary>
        public string OpNo { get; set; }

        /// <summary>
        /// 操作员密码
        /// </summary>
        public string PassWord { get; set; }

        /// <summary>
        /// 认证码(认证成功，记录号码)
        /// </summary>
        public string AuthNo { get; set; }

        /// <summary>
        /// 备用：数字签名（客户端填，唯一性，不可抵赖）
        /// </summary>
        public string Sign { get; set; }
    }
}
