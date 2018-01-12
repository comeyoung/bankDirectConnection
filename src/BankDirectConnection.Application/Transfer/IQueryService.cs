using BankDirectConnection.BaseApplication.BaseTranscation;

namespace BankDirectConnection.Application.Transfer
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 11:04:30
	===============================================================================================================================*/
    public interface IQueryService<T,In,Out> where T: IBaseQueryData where In: BaseApplication.BaseTranscation.IBaseQueryDatas<T> where Out:IBaseResult
    {
        Out QueryTransStatus(In TransferQueryData);
    }
}
