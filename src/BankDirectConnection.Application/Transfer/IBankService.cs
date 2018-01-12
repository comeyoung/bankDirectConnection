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
    public interface IBankService<T,C,D,In,Out>: ITransferService<T,C>, IQueryService<D,In,Out> 
        where C: IBaseTranscation
        where T: IBaseTranscations<C>
        where D: IBaseQueryData
        where In: IBaseQueryDatas<D>
        where Out: IBaseResult
    {
        //银行服务接口
    }
}
