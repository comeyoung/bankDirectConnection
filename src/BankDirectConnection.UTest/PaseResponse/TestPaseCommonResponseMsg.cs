﻿using System;
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
            var rt = Deserialization.ParseResonseMsg(msg);
            Assert.AreEqual("内部交易代码", rt.CCTransCode);
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
