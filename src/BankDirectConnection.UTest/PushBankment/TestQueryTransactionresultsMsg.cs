using BankDirectConnection.Domain.SGB;
using BankDirectConnection.PushBankment.SGBService;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.UTest.PushBankment
{
    [TestClass]
    public class TestQueryTransactionresultsMsg
    {

        public TransactionResultsMsg transactionResultsMsg() {
            TransactionResultsMsg trm = new TransactionResultsMsg();
            trm.Trans.CmeSeqNo = "20134569";
            trm.Trans.StartDate = "20170809";
            return trm;
        }
        [TestMethod]
        public void TestXMLForQueryTransactionResults()
        {
            var xMLForQueryTransactionResults = Serialization.BuildXMLForQueryTransactionResults(transactionResultsMsg());
            Console.WriteLine(xMLForQueryTransactionResults);
        }


        [TestMethod]
        public void TestQueryTransactionResponse() {
            string msg = "<ap><CCTransCode>SGQ010</CCTransCode><Cmp><CmeSeqNo>ddd123456</CmeSeqNo><JnlState>3102</JnlState><Postscript>附言(状态信息)</Postscript><RespSeqNo>ddd123456</RespSeqNo><HostSeqNo>原网银流水</HostSeqNo><CertSeqNo>原核心流水</CertSeqNo></Cmp></ap>";
            var rt = Deserialization.TransactionResultsParseResonseMsg(msg);
           
            Console.Write(rt.Trans.CertSeqNo);
        }
    }
}
