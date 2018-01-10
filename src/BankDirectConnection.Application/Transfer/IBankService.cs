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
    public interface IBankService: ITransferService, IQueryService
    {
        //银行服务接口
    }
}
