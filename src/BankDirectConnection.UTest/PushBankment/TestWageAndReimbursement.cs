using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankDirectConnection.PushBankment.BOCService;
using BankDirectConnection.Domain.BOC;

namespace BankDirectConnection.UTest.PushBankment
{
    [TestClass]
    public class TestWageAndReimbursement
    {
        public WageAndReimbursementMsg SetIn()
        {
            WageAndReimbursementMsg warm = new WageAndReimbursementMsg();
            Detail d = new Detail();
            warm.HeaderMessage.Cusopr = "136140253";
            warm.HeaderMessage.Custid = "133812368";
            warm.HeaderMessage.Obssmsgid = "d123666";
            warm.HeaderMessage.Termid = "E163083136140";
            warm.HeaderMessage.Token = "1Yk532BscUL1HJB-vhG_yv3";
            warm.HeaderMessage.Trncod = "b2e0078";
            warm.HeaderMessage.Trnid = "qwe1336";
            //warm.HeaderMessage.TrnTyp = "代发工资";
            warm.Trans.Ceitinfo = "某某";
            warm.Trans.Crdtyp = "5";
            d.Furinfo = "某某";
            d.Purpose = "代发";
            d.Pydamt = 5000.03M;
            d.Pydcur = "CNY";
            d.Reserve1 = "某某";
            d.Reserve2 = "某某";
            d.Reserve3 = "某某";
            d.Reserve4 = "某某";
            d.Toactn = "342856085028";
            d.Tobank = "";
            d.Toibkn = "40142";
            d.Toidet = "某某";
            d.Toidtp = "";
            d.Toname = "";

            warm.Trans.DetailMessage.Add(d);
            warm.Trans.FractnMessage.Actacn = "327256085181";
            warm.Trans.FractnMessage.Actnam = "";
            warm.Trans.FractnMessage.Fribkn = "40142";

            warm.Trans.Furinfo = "EC";
            warm.Trans.EDIId = "0120180122165802001";
            warm.Trans.Pybamt = 5000.03M;
            warm.Trans.Pybcur = "CNY";
            warm.Trans.Pybnum = 1;
            warm.Trans.Telephone = "18311542365";
            warm.Trans.Transtype = "某某";
            warm.Trans.Trfdate = "20180106";
            warm.Trans.Useinf = "某某";

            return warm;
        }


        [TestMethod]
        public void TestXMLForWageAndReimbursementByLinq()
        {
            var transXML = Serialization.BuildXMLForWageAndReimbursementByLinq(SetIn());
            Console.WriteLine(transXML);

        }
    }
}
