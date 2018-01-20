using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
    public interface IFractn
    {
        /// <summary>
        /// 联行号
        /// </summary>
         string Fribkn { get; set; }
        /// <summary>
        /// 付款账号
        /// </summary>
         string Actacn { get; set; }
        /// <summary>
        /// 付款人名称
        /// </summary>
         string Actnam { get; set; }
    }
}
