using BankDirectConnection.BaseApplication.BaseTranscation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Application.Transfer
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 11:05:22
	===============================================================================================================================*/
    public interface IBankService<T,D,In,Out>: ITransferService<T>, IQueryService<D,In,Out> 
        where T: IBaseTranscation
        where D: IBaseQueryData
        where In: IBaseQueryDatas<D>
        where Out: IBaseResult
    {
        //银行服务接口
    }
}
