using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.BaseApplication.DataHandle;
using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.DataHandle;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.TransferBO
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/12 18:03:36
	===============================================================================================================================*/ 
    public class Transcations : IBaseTranscations<ITranscation>, ITranscations
    {
        public Transcations()
        {
            this.TranscationItems = new List<ITranscation>();
        }
        public string BusinessType
        {
            get;set;
        }
        [JsonConverter(typeof(TransConverter<Transcation, ITranscation>))]
        public IList<ITranscation> TranscationItems
        {
            get;set;
        }

        public string TransWay
        {
            get;set;
        }

        public  bool Check()
        {
            foreach (var item in TranscationItems) {
                if (item.PaymentCur=="RMB") {
                    item.PaymentCur = "CNY";
                }
            }
            
            if (string.IsNullOrEmpty(this.TransWay))
                throw new BusinessException("the value of transferway is null") { Code = "1001006" };
            if (string.IsNullOrEmpty(this.BusinessType))
                throw new BusinessException("the value of businesstype is null") { Code = "1001007" };
            this.TranscationItems.ToList().ForEach(c => c.Check());
            return true;
        }

        public void InitData()
        {
            if (null == this.TranscationItems)
                throw new InnerException("", "");
            this.TranscationItems.ToList().ForEach(c => { c.TransWay = this.TransWay; c.BusinessType = this.BusinessType; });
        }
    }

   
}
