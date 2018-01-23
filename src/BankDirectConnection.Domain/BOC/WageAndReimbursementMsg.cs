using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.BOC.Message;
using BankDirectConnection.Domain.TransferBO;
using System.Collections.Generic;
using System;
using System.Linq;

namespace BankDirectConnection.Domain.BOC
{
    /*===============================================================================================================================
	*	Create by Fancy at 2017/12/24 16:59:25
	===============================================================================================================================*/
    /// <summary>
    /// 代发工资、报销
    /// </summary>
    public class WageAndReimbursementMsg : AbastractBOCTranscation, IWageAndReimbursementMsg
    {
        
        public WageAndReimbursementMsg()
        {
            this.HeaderMessage = new Header("b2e0078");
            this.Trans = new WageAndReimbursementTrans();
        }


        public WageAndReimbursementMsg(ITranscation Transcation)
        {
            this.HeaderMessage = new Header("b2e0078");
            this.Trans = new WageAndReimbursementTrans();
            this.Create(Transcation);
            this.Check();
            Transcation.Check();
        }

        public WageAndReimbursementTrans Trans { get; set; }

        /// <summary>
        /// 检查工资、报销数据
        /// </summary>
        /// <returns></returns>
        public override bool Check()
        {
            base.Check();
            if (string.IsNullOrEmpty(this.Trans.Furinfo))
                throw new BusinessException("the purpose of trans can't be null if choosed the convient transfer") { Code = "1011010" };
            return true;
        }

        private WageAndReimbursementMsg Create(ITranscation Transcation)
        {
            //一笔交易只能一个付款方
            // WageAndReimbursementTrans trans = new WageAndReimbursementTrans();
            this.Trans.Insid = Transcation.ClientId;
            this.Trans.Pybcur = Transcation.PaymentCur;
            this.Trans.FractnMessage.Fribkn = Transcation.FromAcct.BankId;
            this.Trans.FractnMessage.Actacn = Transcation.FromAcct.AcctId;
            this.Trans.FractnMessage.Actnam = Transcation.FromAcct.AcctName;
            //this.trans.Pybamt = Transcation.TransDetail.ForEach(c=>sum(c.TransAmount));
            this.Trans.Pybnum = Transcation.TransDetail.Count;
            this.Trans.Crdtyp = GetCrdtyp(Transcation.PaymentType);
            this.Trans.Furinfo = Transcation.Purpose;
            this.Trans.Trfdate = Transcation.TransDate;
            foreach (var item in Transcation.TransDetail)
            {
                var line = new Detail() {
                    Toibkn = item.ToAcct.BankId,
                    Tobank = item.ToAcct.BankName,
                    Toactn = item.ToAcct.AcctId,
                    Pydcur = item.TransCur,
                    Pydamt = item.TransAmount,
                    Toname = item.ToAcct.AcctName
                };
                this.Trans.DetailMessage.Add(line);
                this.Trans.Pybamt += item.TransAmount;

            }
            return this;
        }

        /// <summary>
        /// 获取代发类型
        /// </summary>
        /// <param name="PaymentType"></param>
        /// <returns></returns>
        private string GetCrdtyp(string PaymentType)
        {
            if (string.IsNullOrEmpty(PaymentType))
                throw new BusinessException("Transaction information can not be empty") { Code = "2012002" };
            switch (PaymentType)
            {
                case "01": return "5";
                case "02": return "7";
                default: return "6";
            }
        }

    }
    public class WageAndReimbursementTrans : IWageAndReimbursementTrans
    {
        public WageAndReimbursementTrans()
        {
            this.DetailMessage = new List<IDetail>();
            this.FractnMessage = new Fractn();
            
        }
        public string Ceitinfo { get; set; }
        public string Transtype { get; set; }
        public string Insid { get; set; }
        /// <summary>
        /// 付款人手机号
        /// </summary>
        public string Telephone { get; set; }

        /// <summary>
        /// 货币
        /// </summary>
        public string Pybcur { get; set; }

        /// <summary>
        /// 批总金额
        /// </summary>
        public decimal Pybamt { get; set; }
        /// <summary>
        /// 批总笔数
        /// </summary>
        public int Pybnum { get; set; }

        /// <summary>
        /// 代发类型 5：他行银联支付6：他行大小额支付7：我行
        /// </summary>
        public string Crdtyp { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string Furinfo { get; set; }

        public string Useinf { get; set; }

        /// <summary>
        /// 要求的付款日期
        /// </summary>
        public string Trfdate { get; set; }

        public Fractn FractnMessage { get; set; }

        public List<IDetail> DetailMessage { get; set; }

        public bool Check()
        {
           this.DetailMessage.ToList().ForEach(c => c.Check());
            return true;
        }
    }


    public class Detail:IDetail
    {

        public Detail()
        {
        }
       
        /// <summary>
        /// 收款行人行行号/收款省行标识
        /// </summary>
        public string Toibkn { get; set; }

        public string Tobank { get; set; }
        public bool Check()
        {
            if (string.IsNullOrEmpty(this.Tobank))
                throw new BusinessException("the Tobank can not be null") { Code = "2012005" };
            return true;
        }
        /// <summary>
        /// 收款账号
        /// </summary>
        public string Toactn { get; set; }

        /// <summary>
        /// 货币
        /// </summary>
        public string Pydcur { get; set; }

        /// <summary>
        /// 笔金额
        /// </summary>
        public decimal Pydamt { get; set; }

        /// <summary>
        /// 收款人名称
        /// </summary>
        public string Toname { get; set; }

        /// <summary>
        /// 收款人证件类型
        /// </summary>
        public string Toidtp { get; set; }

        public string Toidet { get; set; }

        public string Furinfo { get; set; }

        public string Purpose { get; set; }

        public string Reserve1 { get; set; }

        public string Reserve2 { get; set; }
        public string Reserve3 { get; set; }
        public string Reserve4 { get; set; }
    }
}
