using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.Domain.SGB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.PushBankment.SGBService.Service
{
    public class QueryTranactionResultsService
    {
        public IResResult PushQueryTranactionResultsService(TransactionResultsMsg Msg) {
            if (null == Msg)
                throw new InnerException("2022002", "Transaction result information can not be empty ");
            var transXml = Serialization.BuildXMLForQueryTransactionResults(Msg);
            var res = SGBHttp.PostRequest(transXml);
            var rt = Deserialization.TransactionResultsParseResonseMsg(res);
            return ResResult.Create(rt);
        }
    }
}
