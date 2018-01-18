using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankDirectConnection.PushBankment.BOCService;

namespace BankDirectConnection.UTest.PaseResponse
{
    [TestClass]
    public class TestParseResponseMsg
    {
        [TestMethod]
        public void TestResponseMsg()
        {
            // test 0009
            string msg = "<trn-b2e0009-rs><status><rspcod>0</rspcod><rspmsg>successful</rspmsg></status><b2e0009-rs><status><rspcod>0</rspcod><rspmsg>successful</rspmsg></status><insid>012452574sdds548ee</insid><obssid>514552842</obssid></b2e0009-rs><b2e0009-rs><status><rspcod>0</rspcod><rspmsg>successful</rspmsg></status><insid>012452574sdds548ee</insid><obssid>514552842</obssid></b2e0009-rs></trn-b2e0009-rs>";
            var rt =  Deserialization.ParseResponseMsg(msg, "b2e0009");
           // Assert.AreEqual("0", rt.Status.RspCod);
            Console.WriteLine(rt);
        }
    }
}
