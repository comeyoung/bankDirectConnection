using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.SGB
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/11 16:01:55
	===============================================================================================================================*/
    public class BatchTransResponse
    {
        public BatchTransResponse()
        {
            this.CommonResponse = new CommonResponseMsg();
            this.CmpMsg = new CmpMsg();
        }
        public CommonResponseMsg CommonResponse { get; set; }
        /// <summary>
        /// SG内部交易代码
        /// </summary>
        public string CCTransCode { get; set; }

        public CmpMsg CmpMsg { get; set; }
    }

    public class CmpMsg
    {
        public CmpMsg()
        {
            this.ListMsg = new List<SGB.ListMsg>();
        }
        /// <summary>
        /// 原客户端流水号
        /// </summary>
        public string CmeSeqNo { get; set; }
        
        /// <summary>
        /// 状态返回码
        /// </summary>
        public string JnlState { get; set; }

        /// <summary>
        /// 附言(状态信息)
        /// </summary>
        public string Postscript { get; set; }

        /// <summary>
        /// 原应答流水号
        /// </summary>
        public string RespSeqNo { get; set; }

        /// <summary>
        /// 原网银流水
        /// </summary>
        public string HostSeqNo { get; set; }

        public List<ListMsg> ListMsg { get; set; }
    }
    public class ListMsg
    {
        /// <summary>
        /// 批量流水号
        /// </summary>
        public string ParentJnlno { get; set; }

        /// <summary>
        /// 单笔流水号
        /// </summary>
        public string JnlNo { get; set; }

        /// <summary>
        /// 原核心流水
        /// </summary>
        public string CertSeqNo { get; set; }

        /// <summary>
        /// 状态返回码
        /// </summary>
        public string JnlState { get; set; }

        /// <summary>
        /// 附言(状态信息)
        /// </summary>
        public string Postscript { get; set; }

        /// <summary>
        /// 拒绝原因
        /// </summary>
        public string ReturnMsg { get; set; }
    }
}
