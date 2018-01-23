using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankDirectConnection.Domain.BOC;
using BankDirectConnection.PushBankment.BOCService;

namespace BankDirectConnection.UTest.PushBankment
{
    [TestClass]
    public class TestSignIn
    {
        [TestMethod]
        public void TestBuildSignInXML()
        {
            //Mock<SignInMsg> mockSignIn = new Mock<SignInMsg>();
            SignInMsg signInMsg = new SignInMsg();
            signInMsg.HeaderMessage.Cusopr = "136140253";
            signInMsg.HeaderMessage.Custid = "133812368";
            signInMsg.HeaderMessage.Obssmsgid = "100001";
            signInMsg.HeaderMessage.Termid = "100001";
            signInMsg.HeaderMessage.Trncod = "b2e0001";
            signInMsg.HeaderMessage.TrnTyp = "100001";
            signInMsg.Trans.Custdt = DateTime.Now.ToString("yyyyMMddHHmmss");
            signInMsg.Trans.Oprpwd = "4u7hc9Dy";
            signInMsg.Trans.UsbKey = "1111111a";

            string xmlStr = Serialization.BuildXMLStrForSignInByLinq(signInMsg);
            Console.WriteLine(xmlStr);
        }
       
    }
}
