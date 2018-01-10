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
    public class TransferQueryDataList : ITransferQueryDataList
    {
        public TransferQueryDataList()
        {
            this.ITransferQueryDatas = new List<ITransferQueryData>();
        }
        public IList<ITransferQueryData> ITransferQueryDatas
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

        public string InsId
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
