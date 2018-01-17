using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.BaseApplication.BaseTranscation
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/12 14:39:12
	===============================================================================================================================*/

    public interface IBaseQueryDatas<T> where T: IBaseQueryData
    {
        IList<T> TransferQueryDatas { get; set; }
    }

    public interface IBaseQueryData
    {
        string ClientId { get; set; }

        string EDIId { get; set; }
    }
}
