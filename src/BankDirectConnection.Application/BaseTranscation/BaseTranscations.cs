using BankDirectConnection.BaseApplication.ExceptionMsg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.BaseApplication.BaseTranscation
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/12 17:56:00
	===============================================================================================================================*/
    public abstract class BaseTranscations<T> : IBaseTranscations<T> where T : IBaseTranscation
    {
        public BaseTranscations() { this.Transcations = new List<T>(); }
        public string BusinessType
        {
            get;set;
        }

        public IList<T> Transcations
        {
            get;set;
        }

        public string TransWay
        {
            get;set;
        }

        public virtual bool Check()
        {
            if (string.IsNullOrEmpty(this.TransWay))
                throw new BusinessException("the value of transferway is null") { Code = "1001006" };
            if (string.IsNullOrEmpty(this.BusinessType))
                throw new BusinessException("the value of businesstype is null") { Code = "1001007" };
            this.Transcations.ToList().ForEach(c => c.Check());
            return true;
        }

        public void InitData()
        {
            if (null == this.Transcations)
                throw new InnerException("", "");
            this.Transcations.ToList().ForEach(c => { c.TransWay = this.TransWay; c.BusinessType = this.BusinessType; });
        }
    }
}
