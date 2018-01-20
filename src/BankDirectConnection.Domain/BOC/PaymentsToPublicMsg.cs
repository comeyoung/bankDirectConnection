using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.BOC.Message;
using BankDirectConnection.Domain.TransferBO;
using System.Collections.Generic;

namespace BankDirectConnection.Domain.BOC
{
    /*===============================================================================================================================
	*	Create by Fancy at 2017/12/24 16:58:56
	===============================================================================================================================*/
    /// <summary>
    /// 对公转账
    /// </summary>
    public class PaymentsToPublicMsg: AbastractBOCTranscation, IPaymentsToPublicMsg
    {
        public PaymentsToPublicMsg()
        {
            this.HeaderMessage = new Header("b2e0009");
            this.Trans = new List<PaymentsToPublicTrans>();
        }

        public PaymentsToPublicMsg(ITranscations Transcations)
        {
            this.HeaderMessage = new Header("b2e0009");
            this.Trans = new List<PaymentsToPublicTrans>();
            Create(Transcations);
            this.Check();
        }

        public List<PaymentsToPublicTrans> Trans { get; set; }

        public override bool Check()
        {
            return base.Check();
        }

        public PaymentsToPublicMsg Create(ITranscations Transcations)
        {
            if (null == Transcations)
                throw new BusinessException("the value of transcation is null") { Code = "1012002" };
            // PaymentsToPublicMsg msg = new PaymentsToPublicMsg();
            foreach (var Transcation in Transcations.Transcations)
            {
                //以交易明细确定交易笔数
                foreach (var item in Transcation.TransDetail)
                {
                    PaymentsToPublicTrans trans = new PaymentsToPublicTrans();
                    trans.Insid = Transcation.ClientId;
                    trans.Fractn.Fribkn = Transcation.FromAcct.BankId;
                    trans.Fractn.Actacn = Transcation.FromAcct.AcctId;
                    trans.Fractn.Actnam = Transcation.FromAcct.AcctName;
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
    public class PaymentsToPublicTrans
    {
        public PaymentsToPublicTrans()
        {
            this.Fractn = new Fractn();
            this.Toactn = new Toactn();
        }
        /// <summary>
        /// 指令ID，一 条转账指令  ,在客户端的唯一标识，建议企业按时间顺序生成且不超过12位
        /// </summary>
        public string Insid { get; set; }

        /// <summary>
        /// 网银交易流水号
        /// </summary>
        public string Obssid { get; set; }
        /// <summary>
        /// 转账金额
        /// </summary>
        public decimal Trnamt { get; set; }
        /// <summary>
        /// 转账货币 只支持001或者CNY
        /// </summary>
        public string Trncur { get; set; }
        /// <summary>
        /// 银行处理优先级(0-普通；1-加急)
        /// </summary>
        public string Priolv { get; set; }
        /// <summary>
        /// 用途
        /// </summary>
        public string Furinfo { get; set; }
        /// <summary>
        /// 要求的转账日期 （一个月内） YYYYMMDD

        /// </summary>
        public string TrfDate { get; set; }
        /// <summary>
        /// 要求的转账时间
        /// </summary>
        public string TrfTime { get; set; }
        /// <summary>
        /// 手续费账号
        /// </summary>
        public string Comacn { get; set; }

        /// <summary>
        /// 付款人信息
        /// </summary>
        public Fractn Fractn { get; set; }

        /// <summary>
        /// 收款人信息
        /// </summary>
        public Toactn Toactn { get; set; }
    }

   
    /// <summary>
    /// 收款人账户信息
    /// </summary>
    public class Toactn
    {
        /// <summary>
        /// 收款行联行号
        /// </summary>
        public string ToiBkn { get; set; }
        /// <summary>
        /// 收款账号
        /// </summary>
        public string Actacn { get; set; }

        /// <summary>
        /// 收款人名称
        /// </summary>
        public string Toname { get; set; }

        /// <summary>
        /// 收款人地址
        /// </summary>
        public string Toaddr { get; set; }

        /// <summary>
        /// 收款人开户行名称
        /// </summary>
        public string Tobknm { get; set; }
    }
}
