using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.Domain.TransferBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.SGB
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/13 15:09:20
	===============================================================================================================================*/
    public interface IBaseSGBTranscation: ISGBHeader,ICheckAble
    {

        string ClientId { get; set; }

        string EDIId { get; set; }
       


       //IBaseSGBTranscation Create(ITranscation Transcation);


       // List<IBaseSGBTranscation> CreatePayments(ITranscations Transcations);
    }
}
