using BankDirectConnection.Domain.SGB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.IPushBankment.Service.SGB
{
    /// <summary>
    /// 查询交易状态接口
    /// </summary>
    public interface IQueryTranactionStatusService : ISGBQueryTransferService<TransactionResultsMsg>
    {
    }
}
