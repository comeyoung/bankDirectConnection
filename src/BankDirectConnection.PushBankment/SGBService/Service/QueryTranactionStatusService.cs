﻿using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.Domain.SGB;
using BankDirectConnection.IPushBankment.Service.SGB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.PushBankment.SGBService.Service
{
    public class QueryTranactionStatusService : ISGBQueryTransferService
    {
        public IResResult PushQueryTranactionService(TransactionResultsMsg Msg) {
            if (null == Msg)
                throw new InnerException("2022002", "Transaction result information can not be empty ");
            var transXml = Serialization.BuildXMLForQueryTransactionResults(Msg);
            var res = SGBHttp.PostRequest(transXml);
            var rt = Deserialization.ParseResonseMsg(res);
            return ResResult.Create(rt);
        }
    }
}
