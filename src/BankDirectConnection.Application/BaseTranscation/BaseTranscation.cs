using BankDirectConnection.BaseApplication.DataHandle;
using BankDirectConnection.BaseApplication.ExceptionMsg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.BaseApplication.BaseTranscation
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/12 14:22:01
	===============================================================================================================================*/
    public abstract class BaseTranscation<P,T>: IBaseTranscation where P: IBaseTranscations<T> where T:IBaseTranscation
    {
        public BaseTranscation()
        {

        }
        private P _parent;
        public BaseTranscation(P Parent)
        {
            this._parent = Parent;
            this.Init();
            
        }
        public void Init()
        {
            this.TransWay = this._parent.TransWay;
            this.BusinessType = this._parent.BusinessType;
        }
        /// <summary>
        /// 客户端流水号
        /// </summary>
        public string ClientId { get; set; }

        /// <summary>
        /// 平台生成的流水号
        /// </summary>
        public string EDIId { get; set; }
        public IAccount FromAcct
        {
            get; set;
        }
        public string TransWay { get; set; }
        public string BusinessType { get; set; }

        public virtual bool Check()
        {
            if (string.IsNullOrEmpty(FromAcct.AcctId))
                throw new BusinessException("the value of from account's account id is null .") { Code = "1001001" };
            if (string.IsNullOrEmpty(FromAcct.BankId))
                throw new BusinessException("the value of from account's bank id is null .") { Code = "1001002" };
            return true;
        }

        public void NewEDIId()
        {
            if (null != this.TransWay && string.IsNullOrEmpty(this.EDIId))
                this.EDIId = Instruction.NewInsSid(this.TransWay);
        }

    }
}
