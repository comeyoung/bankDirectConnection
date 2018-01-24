using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.BaseApplication.ExceptionMsg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.SGB
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/13 15:07:49
	===============================================================================================================================*/
    public abstract class AbstractSGBTranscation : IBaseSGBTranscation,ICheckAble
    {
        public string ClientId
        {
            get;
            set;
                               
        }
        public string EDIId
        {
            get;
            set;
        }
        public string CrAccName
        {
            get;
            set;
        }

        /// <summary>
        /// 收款账号
        /// </summary>
        public string CrAccNo
        {
            get;
            set;
        }

        public string CrBankName
        {
            get;
            set;
        }

        public string CrCifType
        {
            get;
            set;
        }

        public string CrCur
        {
            get;
            set;
        }

        public string DbAccName
        {
            get;
            set;
        }

        /// <summary>
        /// 付款账号
        /// </summary>
        public string DbAccNo
        {
            get;set;
        }

        public string DbCur
        {
            get;
            set;
        }

        public string Docket
        {
            get;
            set;
        }

       

        public string Fees
        {
            get;
            set;
        }

        public string ForeignPayee
        {
            get;
            set;
        }

        public CommonHeader Head
        {
            get;
            set;
        }

        public string StartDate
        {
            get;
            set;
        }

        public string StartTime
        {
            get;
            set;
        }

        public decimal TransAmt
        {
            get;
            set;
        }

        public string TranType
        {
            get;
            set;
        }

        public string UnionDeptId
        {
            get;
            set;
        }

        public string WhyUse
        {
            get;
            set;
        }

        public virtual bool Check()
        {
            if (String.IsNullOrEmpty(this.Head.ReqSeqNo))
                throw new BusinessException("the value of clientid is null") { Code = "1021002" };
            if (String.IsNullOrEmpty(this.DbAccNo))
                throw new BusinessException("the value of fromacct's accountid is null") { Code = "1021012" };
            if (String.IsNullOrEmpty(this.CrAccNo))
                throw new BusinessException("the value of toacct's accountid is null") { Code = "1021004" };
            return true;
        }
    }
}
