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
            warm.HeaderMessage.Cusopr = "d123456";
            warm.HeaderMessage.Custid = "C123456";
            warm.HeaderMessage.Obssmsgid = "d123666";
            warm.HeaderMessage.Termid = "前置机";
            warm.HeaderMessage.Token = "qwe1336";
            warm.HeaderMessage.Trncod = "1133qwer";
            warm.HeaderMessage.Trnid = "qwe1336";
            warm.HeaderMessage.TrnTyp = "代发工资";
            warm.Trans.Ceitinfo = "某某";
            warm.Trans.Crdtyp = "5";


            d.Furinfo = "某某";
            d.Purpose = "代发";
            d.Pydamt = 5000;
            d.Pydcur = "人民币";
            d.Reserve1 = "某某";
            d.Reserve2 = "某某";
            d.Reserve3 = "某某";
            d.Reserve4 = "某某";
            d.Toactn = "q456";
            d.Tobank = "中国银行";
            d.Toibkn = "06d366";
            d.Toidet = "某某";
            d.Toidtp = "身份证";
            d.Toname = "张三";

            warm.Trans.DetailMessage.Add(d);
            warm.Trans.FractnMessage.Actacn = "123456789";
            warm.Trans.FractnMessage.Actnam = "李四";
            warm.Trans.FractnMessage.Fribkn = "qwe12345678";

            warm.Trans.Furinfo = "代发业务";
            warm.Trans.Insid = "123";
            warm.Trans.Pybamt = 5000;
            warm.Trans.Pybcur = "人民币";
            warm.Trans.Pybnum = 20;
            warm.Trans.Telephone = "18888888888";
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
