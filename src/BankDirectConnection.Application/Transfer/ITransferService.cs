using BankDirectConnection.BaseApplication.BaseTranscation;
using System.Collections.Generic;

namespace BankDirectConnection.Application.Transfer
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 11:05:12
	===============================================================================================================================*/
    public interface ITransferService<T,D> where D: IBaseTranscation where T: IBaseTranscations<D>
    {
        /// <summary>
        /// 转账付款
        /// </summary>
        /// <param name="Transcation"></param>
        void PaymentTransfer(T Transcations);

    }
}
