using BankDirectConnection.BaseApplication.BaseTranscation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
     public interface IWageAndReimbursementTrans:ICheckAble
    {
         string Ceitinfo { get; set; }
         string Transtype { get; set; }
         
        /// <summary>
        /// 付款人手机号
        /// </summary>
         string Telephone { get; set; }

        /// <summary>
        /// 货币
        /// </summary>
         string Pybcur { get; set; }

        /// <summary>
        /// 批总金额
        /// </summary>
         decimal Pybamt { get; set; }
        /// <summary>
        /// 批总笔数
        /// </summary>
         int Pybnum { get; set; }

        /// <summary>
        /// 代发类型 5：他行银联支付6：他行大小额支付7：我行
        /// </summary>
         string Crdtyp { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
         string Furinfo { get; set; }

         string Useinf { get; set; }

        /// <summary>
        /// 要求的付款日期
        /// </summary>
         string Trfdate { get; set; }

         Fractn FractnMessage { get; set; }

         List<IDetail> DetailMessage { get; set; }
    }
}
