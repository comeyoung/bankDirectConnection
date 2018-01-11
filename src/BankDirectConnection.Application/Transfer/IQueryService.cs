using BankDirectConnection.Domain.QueryBO;
using BankDirectConnection.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Application.Transfer
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/10 11:04:30
	===============================================================================================================================*/
    public interface IQueryService
    {
        IResResult QueryTransStatus(ITransferQueryData TransferQueryData);
    }
}
