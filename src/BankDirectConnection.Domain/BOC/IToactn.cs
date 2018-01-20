using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
    public interface IToactn
    {
         string ToiBkn { get; set; }
        /// <summary>
        /// 收款账号
        /// </summary>
         string Actacn { get; set; }

        /// <summary>
        /// 收款人名称
        /// </summary>
         string Toname { get; set; }

        /// <summary>
        /// 收款人地址
        /// </summary>
         string Toaddr { get; set; }

        /// <summary>
        /// 收款人开户行名称
        /// </summary>
         string Tobknm { get; set; }
    }
}
