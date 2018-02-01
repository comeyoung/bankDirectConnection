using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankDirectConnection.BaseApplication.DataHandle;
using BankDirectConnection.Domain.BOC.Message;
using BankDirectConnection.Domain.TransferBO;
using BankDirectConnection.BaseApplication.ExceptionMsg;

namespace BankDirectConnection.Domain.BOC
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/31 18:38:14
	===============================================================================================================================*/
    public class PaymentsToPrivateMsg : AbastractBOCTranscation, IPaymentsToPrivateMsg
    {
        public PaymentsToPrivateMsg()
        {
            this.HeaderMessage = new Header("b2e0061");
            this.Trans = new List<IPaymentsToPrivateTrans>();
        }

        public PaymentsToPrivateMsg(ITranscations Transcations)
        {
            this.HeaderMessage = new Header("b2e0061");
            this.Trans = new List<IPaymentsToPrivateTrans>();
            this.Create(Transcations);
            this.Check();
        }
        public IList<IPaymentsToPrivateTrans> Trans
        {
            get; set;
        }

        public PaymentsToPrivateMsg Create(ITranscations Transcations)
        {
            if (null == Transcations)
                throw new BusinessException("the value of transcation is null") { Code = "1012002" };
            IPaymentsToPrivateTrans trans;
            foreach (var Transcation in Transcations.TranscationItems)
            {
                //以交易明细确定交易笔数
                if (Transcation.TransDetail.Count != 1)
                    throw new BusinessException("1001011", "每笔交易不能有多行明细");
                foreach (var item in Transcation.TransDetail)
                {
                    if (item.ToAcct.BankType.Equals(emBankType.emEmpty))
                        throw new BusinessException("1011017", "收款账户的银行类型为空");
                    trans = new PaymentsToPrivateTrans();
                    trans.EDIId = Transcation.EDIId;
                    trans.ClientId = Transcation.ClientId;
                    trans.Fractn.Fribkn = Transcation.FromAcct.BankId;
                    trans.Fractn.Actacn = Transcation.FromAcct.AcctId;
                    trans.Fractn.Actnam = Transcation.FromAcct.AcctName;
                    trans.Bocflag = EnumHelper.GetEnumValue(item.ToAcct.BankType);
                    trans.Toactn.ToiBkn = item.ToAcct.BankId;
                    trans.Toactn.Actacn = item.ToAcct.AcctId;
                    trans.Toactn.Tobknm = item.ToAcct.BankName;
                    trans.Toactn.Toname = item.ToAcct.AcctName;
                    trans.Trnamt = item.TransAmount;
                    trans.Trncur = item.TransCur;
                    trans.Priolv = Transcation.Priority;
                    trans.Furinfo = Transcation.Purpose;
                    trans.TrfDate = Transcation.TransDate;
                    trans.Comacn = Transcation.FeeAcct;
                    this.Trans.Add(trans);
                }
            }
            return this;
        }
    }

    public class PaymentsToPrivateTrans : AbastractBOCTranscation, IPaymentsToPrivateTrans
    {
        public PaymentsToPrivateTrans()
        {
            this.Fractn = new Fractn();
            this.Toactn = new Toactn();
        }
        public string Bocflag
        {
            get;set;
        }

        public string Comacn
        {
            get; set;
        }

        public string Cuspriolv
        {
            get; set;
        }

        public Fractn Fractn
        {
            get; set;
        }

        public string Furinfo
        {
            get; set;
        }

        public string Obssid
        {
            get; set;
        }

        public emPriolv Priolv
        {
            get; set;
        }

        public Toactn Toactn
        {
            get; set;
        }

        public string TrfDate
        {
            get; set;
        }

        public string TrfTime
        {
            get; set;
        }

        public decimal Trnamt
        {
            get; set;
        }

        public string Trncur
        {
            get; set;
        }
    }

}
