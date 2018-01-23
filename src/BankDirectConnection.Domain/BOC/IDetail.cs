using BankDirectConnection.BaseApplication.BaseTranscation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
   public interface IDetail:ICheckAble
    {
         string Toibkn { get; set; }

         string Tobank { get; set; }

        /// <summary>
        /// 收款账号
        /// </summary>
         string Toactn { get; set; }

        /// <summary>
        /// 货币
        /// </summary>
         string Pydcur { get; set; }

        /// <summary>
        /// 笔金额
        /// </summary>
         decimal Pydamt { get; set; }

        /// <summary>
        /// 收款人名称
        /// </summary>
         string Toname { get; set; }

        /// <summary>
        /// 收款人证件类型
        /// </summary>
         string Toidtp { get; set; }

         string Toidet { get; set; }

         string Furinfo { get; set; }

         string Purpose { get; set; }

         string Reserve1 { get; set; }

         string Reserve2 { get; set; }
         string Reserve3 { get; set; }
         string Reserve4 { get; set; }
    }
}
