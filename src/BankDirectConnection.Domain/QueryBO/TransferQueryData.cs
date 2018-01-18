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
        public IList<ITransferQueryData> TransferQueryDatas
        {
            get;set;
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
    }
}
