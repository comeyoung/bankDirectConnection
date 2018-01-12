using BankDirectConnection.BaseApplication.BaseTranscation;

namespace BankDirectConnection.Application.Transfer
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 11:05:12
	===============================================================================================================================*/
    public interface ITransferService<T> where T: IBaseTranscation
    {
        /// <summary>
        /// 转账付款
        /// </summary>
        /// <param name="Transcation"></param>
        void PaymentTransfer(T Transcation);

    }
}
