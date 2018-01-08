using BankDirectConnection.Domain.BOC;
using BankDirectConnection.Domain.BOC.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankDirectConnection.PushBankment.BuildXml
{
    /*===============================================================================================================================
	*	Create by Fancy at 2017/12/30 15:49:21
	===============================================================================================================================*/
    public class BuildCommonXML
    {
        /// <summary>
        /// 构建header消息
        /// </summary>
        /// <param name="Header"></param>
        /// <returns></returns>
        public static XElement BuildHeadElement(Header Header)
        {
            if (Header != null)
                throw new Exception("头部消息为空");
            XElement xHeader = new XElement("head",
                new XElement("termid", Header.Termid),
                new XElement("trnid", Header.Trnid),
                new XElement("custid", Header.Custid),
                new XElement("cusopr", Header.Cusopr),
                new XElement("trncod", Header.Trncod),
                new XElement("token", Header.Token));
            return xHeader;
        }

        public static XElement BuildSignInHeadElement(Header Header)
        {
            if (Header != null)
                throw new Exception("头部消息为空");
            XElement xHeader = new XElement("head",
                new XElement("termid", Header.Termid),
                new XElement("trnid", Header.Trnid),
                new XElement("custid", Header.Custid),
                new XElement("cusopr", Header.Cusopr),
                new XElement("trncod", Header.Trncod));
            return xHeader;
        }

        /// <summary>
        /// 构建付款人元素信息
        /// </summary>
        /// <param name="FractnMsg"></param>
        /// <returns></returns>
        public static XElement BuildFractnElement(Fractn FractnMsg)
        {
            if (FractnMsg != null)
                throw new Exception("付款人信息为空");
            XElement xFractn = new XElement("fractn", new XElement("fribkn", FractnMsg.Fribkn),
                                                 new XElement("actacn", FractnMsg.Actacn),
                                                 new XElement("actnam", FractnMsg.Actnam));
            return xFractn;
        }
    }
}
