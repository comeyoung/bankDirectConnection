using BankDirectConnection.BaseApplication.ExceptionMsg;
using System;

namespace BankDirectConnection.Domain.DataHandle
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/11 13:23:37
	===============================================================================================================================*/
    /// <summary>
    /// 指令处理
    /// </summary>
    public class Instruction
    {
        /// <summary>
        /// 生成EDI指令单
        /// </summary>
        /// <returns></returns>
        public static string NewInsSid(string TransWay)
        {
            if (string.IsNullOrEmpty(TransWay))
                throw new BusinessException("the value of transway is null") { Code= "1001006" };
            switch (TransWay)
            {
                case "01": return "01" + Guid.NewGuid().ToString().Trim('-');
                case "02": return "02"+ Guid.NewGuid().ToString().Trim('-');
                default:throw new BusinessException("the value of transway is bad") { Code= "1001006" };
            }
        }

        /// <summary>
        /// 解析EDI指令单，获取调用银行接口
        /// </summary>
        /// <param name="InsSid"></param>
        /// <returns></returns>
        public static emBankService ParseInsId(string InsId)
        {
            if (string.IsNullOrEmpty(InsId))
                throw new BusinessException("the value of insid is null") { Code= "1001009" };
            string bankCode = InsId.Substring(0, 2);
            switch (bankCode)
            {
                case "01":return emBankService.emBOCService;
                case "02": return emBankService.emSGBService;
                default: throw new BusinessException("error insid") { Code = "1001009" };
            }
        }
    }
}
