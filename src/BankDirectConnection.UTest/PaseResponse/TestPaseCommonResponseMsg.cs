using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankDirectConnection.PushBankment.BankTransfer;
using BankDirectConnection.PushBankment.SGBService;

namespace BankDirectConnection.UTest.PaseResponse
{
    [TestClass]
    public class TestPaseCommonResponseMsg
    {
        [TestMethod]
        public void TestParseResponseMsg()
        {
            string msg = @"<ap><CCTransCode>内部交易代码</CCTransCode><ReqSeqNo>请求方流水号</ReqSeqNo><RespSource>返回来源</RespSource><RespSeqNo>应答流水号</RespSeqNo><HostSeqNo>网银流水</HostSeqNo><RespDate>返回日期</RespDate><RespTime>返回时间</RespTime><RespCode>返回码</RespCode><RespInfo>返回信息</RespInfo><RxtInfo>返回扩展信息</RxtInfo><FileFlag>数据文件标识</FileFlag><Cme><RecordNum>记录数</RecordNum><FieldNum>字段数</FieldNum><RespPrvData>私有数据区</RespPrvData><BatchFileName>文件名</BatchFileName></Cme></ap>";
            var rt = Deserialization.PaseResonseMsg(msg);
            Assert.AreEqual("内部交易代码", rt.CCTransCode);
            Console.WriteLine(rt.CCTransCode);
        }
    }
}
