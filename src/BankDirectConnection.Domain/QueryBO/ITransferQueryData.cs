using BankDirectConnection.BaseApplication.BaseTranscation;
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
    /// <summary>
    /// 交易查询数据接口
    /// </summary>
    public interface ITransferQueryDataList: IBaseQueryDatas<ITransferQueryData>
    {
        
    }

    public interface ITransferQueryData: IBaseQueryData
    {

        string ObssId { get; set; }

        string StartDate { get; set; }
    }
}
