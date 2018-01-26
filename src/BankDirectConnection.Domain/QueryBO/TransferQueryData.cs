using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.DataHandle;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.QueryBO
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 17:39:21
	===============================================================================================================================*/
    /// <summary>
    /// 交易查询数据
    /// </summary>
    public class TransferQueryDataList : ITransferQueryDataList
    {
        public TransferQueryDataList()
        {
            this.TransferQueryDatas = new List<ITransferQueryData>();
        }
        [JsonConverter(typeof(TransConverter<TransferQueryData, ITransferQueryData>))]
        public IList<ITransferQueryData> TransferQueryDatas
        {
            get;set;
        }

        public bool Check()
        {
            this.TransferQueryDatas.ToList().ForEach(c => c.Check());
            return true;
        }
    }

    public class TransferQueryData : ITransferQueryData
    {
        public string ClientId
        {
            get;set;
        }

        public string EDIId
        {
            get;set;
        }

        public string ObssId
        {
            get;set;
        }

        public string StartDate
        {
            get;set;
        }
        

        public string StartTime
        {
            get; set;
        }

        public bool Check()
        {
            if (string.IsNullOrEmpty(this.ClientId))
                throw new BusinessException("the value of clientid is null.") { Code = "1001005" };
            if (!string.IsNullOrEmpty(this.EDIId))
                throw new BusinessException("the value of EDIId should be empty.") { Code = "1001009" };
            return true;
        }
    }
}
