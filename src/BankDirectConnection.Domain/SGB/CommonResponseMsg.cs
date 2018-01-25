using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.SGB
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 13:06:01
	===============================================================================================================================*/
    /// <summary>
    /// 法兴接口公共返回
    /// </summary>
    public class CommonResponseMsg
    {
        public CommonResponseMsg()
        {
            this.CmeMsgs = new List<CmeMsg>();
        }
        /// <summary>
        /// 内部交易代码
        /// </summary>
        public string CCTransCode { get; set; }

        /// <summary>
        /// 请求方流水号
        /// </summary>

        public string ReqSeqNo { get; set; }

        /// <summary>
        /// 返回来源
        /// </summary>
        public string RespSource { get; set; }

        /// <summary>
        /// 应答流水号
        /// </summary>
        public string RespSeqNo { get; set; }

        /// <summary>
        /// 网银流水号  ObssId
        /// </summary>
        public string HostSeqNo { get; set; }
        
        /// <summary>
        /// 返回日期
        /// </summary>
        public string RespDate { get; set; }
        /// <summary>
        /// 返回时间
        /// </summary>
        public string RespTime { get; set; }

        /// <summary>
        /// 返回码
        /// </summary>
        public string RespCode { get; set; }

        /// <summary>
        /// 返回信息
        /// </summary>
        public string RespInfo { get; set; }

        /// <summary>
        /// 返回扩展信息
        /// </summary>
        public string RxtInfo { get; set; }

        /// <summary>
        /// 数据文件标识
        /// </summary>
        public string FileFlag { get; set; }


        public List<CmeMsg> CmeMsgs { get; set; }
    }

    public class CmeMsg
    {
        /// <summary>
        /// 记录数
        /// </summary>
        public string RecordNum { get; set; }

        /// <summary>
        /// 字段数
        /// </summary>
        public string FieldNum { get; set; }

        /// <summary>
        /// 私有数据区
        /// </summary>
        public string RespPrvData { get; set; }

        /// <summary>
        /// 文件名
        /// </summary>
        public string BatchFileName { get; set; }
    }
}
