using BankDirectConnection.BaseApplication.ExceptionMsg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.BaseApplication.DataHandle
{
    /*===============================================================================================================================
		Create by Fancy in 2018/1/23 17:35:58
	===============================================================================================================================*/
    public class Instruction
    {
        /// <summary>
        /// 截取时间戳位数
        /// </summary>
        private const int TIMESTAMP = 8;
        private const int DATETIME = 6;


        /// <summary>
        /// 生成EDI指令单
        /// </summary>
        /// <returns></returns>
        public static string NewInsSid(string TransWay)
        {
            if (string.IsNullOrEmpty(TransWay))
                throw new BusinessException("the value of transway is null") { Code = "1001006" };
            switch (TransWay)
            {
                // 日期 银行接口 接口类型 时间戳  随机数
                //180123    01     1     15166819  254
                case "01": return DateTime.Now.ToString("yyMMdd") + "01" + GetTimestamp();
                case "02": return DateTime.Now.ToString("yyMMdd") + "02" + GetTimestamp();
                default: throw new BusinessException("the value of transway is bad") { Code = "1001006" };
            }
        }

        /// <summary>
        /// 获取时间戳
        /// </summary>
        /// <returns></returns>
        public static string GetTimestamp()
        {
            System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1));
            long timeStamp = (long)(DateTime.Now - startTime).TotalSeconds;
            return timeStamp.ToString().Substring(timeStamp.ToString().Length - TIMESTAMP);
        }

        /// <summary>
        /// 解析EDI指令单，获取调用银行接口
        /// </summary>
        /// <param name="EDIId"></param>
        /// <returns></returns>
        public static emBankService ParseInsId(string EDIId)
        {
            string bankCode = GetBankService(EDIId);
            switch (bankCode)
            {
                case "01": return emBankService.emBOCService;
                case "02": return emBankService.emSGBService;
                default: throw new BusinessException("error insid") { Code = "1001009" };
            }
        }

        /// <summary>
        /// 获取请求的银行接口
        /// </summary>
        /// <param name="EDIId"></param>
        /// <returns></returns>
        public static string GetBankService(string EDIId)
        {
            if (string.IsNullOrEmpty(EDIId))
                throw new InnerException("1001009", "the value of EDIId is empty");
            return EDIId.Substring(5, 2);
        }
    }
}
