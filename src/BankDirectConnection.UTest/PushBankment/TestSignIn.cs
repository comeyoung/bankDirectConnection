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
            signInMsg.HeaderMessage.Cusopr = "100001";
            signInMsg.HeaderMessage.Custid = "100001";
            signInMsg.HeaderMessage.Obssmsgid = "100001";
            signInMsg.HeaderMessage.Termid = "100001";
            signInMsg.HeaderMessage.Trncod = "100001";
            signInMsg.HeaderMessage.TrnTyp = "100001";
            signInMsg.Trans.Ceitinfo = "2002";
            signInMsg.Trans.Custdt = "2002";
            signInMsg.Trans.Oprpwd = "2002";

            string xmlStr = Serialization.BuildXMLStrForSignInByLinq(signInMsg);
            Console.WriteLine(xmlStr);
        }
    }
}
