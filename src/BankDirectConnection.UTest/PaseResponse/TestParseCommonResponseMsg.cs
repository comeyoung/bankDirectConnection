using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankDirectConnection.PushBankment.BankTransfer;
using BankDirectConnection.PushBankment.SGBService;

namespace BankDirectConnection.UTest.PaseResponse
{
    [TestClass]
    public class TestParseCommonResponseMsg
    {
        /// <summary>
        /// 测试SG银行公共包头反序列化
        /// </summary>
        [TestMethod]
        public void TestParseResponseMsg()
        {
            string msg = @"<ap><CCTransCode>SGT001</CCTransCode><ReqSeqNo>2b35cb176aed4b4fabf332de889949d1</ReqSeqNo><RespSource>ERP</RespSource><RespSeqNo>ERP40075325</RespSeqNo><HostSeqNo>364232</HostSeqNo><RespDate>20180118</RespDate><RespTime>142825876</RespTime><RespCode>0005</RespCode><RespInfo>交易待审核</RespInfo><RxtInfo>交易待审核</RxtInfo><FileFlag></FileFlag><Cme><RecordNum></RecordNum><FieldNum></FieldNum><RespPrvData></RespPrvData><BatchFileName></BatchFileName></Cme></ap>";
            var rt = Deserialization.ParseResonseMsg(msg);
            Assert.AreEqual("SGT001", rt.CCTransCode);
            Console.WriteLine(rt.CCTransCode);
        }

        [TestMethod]
        public void TestBatchResponseMsg()
        {
            string msg = "<ap><CCTransCode>内部交易代码</CCTransCode><ReqSeqNo>请求方流水号</ReqSeqNo><RespSource>返回来源</RespSource><RespSeqNo>应答流水号</RespSeqNo><HostSeqNo>网银流水</HostSeqNo><RespDate>返回日期</RespDate><RespTime>返回时间</RespTime><RespCode>返回码</RespCode><RespInfo>返回信息</RespInfo><RxtInfo>返回扩展信息</RxtInfo><FileFlag>数据文件标识</FileFlag><Cme><RecordNum>记录数</RecordNum><FieldNum>字段数</FieldNum><RespPrvData>私有数据区</RespPrvData><BatchFileName>文件名</BatchFileName></Cme><CCTransCode>SGQ010</CCTransCode><Cmp><CmeSeqNo>原客户端流水号</CmeSeqNo><JnlState>状态返回码</JnlState><Postscript>附言(状态信息)</Postscript><RespSeqNo>原应答流水号</RespSeqNo><HostSeqNo>原网银流水</HostSeqNo><List><ParentJnlno>批量流水号</ParentJnlno><JnlNo>单笔流水号</JnlNo><CertSeqNo>原核心流水</CertSeqNo><JnlState>状态返回码</JnlState><Postscript>附言(状态信息)</Postscript><ReturnMsg>拒绝原因</ReturnMsg></List></Cmp></ap>";
            var rt = Deserialization.ParseBatchTransResponse(msg);
            Assert.AreEqual("内部交易代码", rt.CCTransCode);
            Console.Write(rt.CCTransCode);
        }
    }
}
