using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.QueryBO
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 17:37:16
	===============================================================================================================================*/
    public interface ITransferQueryDataList
    {
        IList<ITransferQueryData> ITransferQueryDatas { get; set; }
    }

    public interface ITransferQueryData
    {
        string ClientId { get; set; }

        string InsId { get; set; }

        string ObssId { get; set; }

        string StartDate { get; set; }
    }
}
