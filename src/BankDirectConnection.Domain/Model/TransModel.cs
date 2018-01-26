using BankDirectConnection.BaseApplication.DataHandle;
using BankDirectConnection.Domain.TransferBO;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.Model
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/25 9:47:53
	===============================================================================================================================*/
    public class TransModel
    {
        public TransModel()
        {
            this.TransDetails = new List<TransDetailModel>();
        }

      

        public static List<TransModel> Create(ITranscations Trans)
        {
            List<TransModel> transModels = new List<TransModel>();
            TransModel trans;
            foreach (var item in Trans.TranscationItems)
            {
                #region head
                trans = new TransModel();
                trans.EDIId = item.EDIId;
                trans.ClientId = item.ClientId;
                trans.TransWay = item.TransWay;
                trans.BusinessType = item.BusinessType;
                trans.PaymentCur = item.PaymentCur;
                trans.PaymentType = item.PaymentType;
                trans.Purpose = item.Purpose;
                trans.Priority = item.Priority;
                trans.TransDate = DateTime.ParseExact(item.TransDate,
                                        "yyyyMMdd",
                                        CultureInfo.InvariantCulture,
                                        DateTimeStyles.None); 
                trans.TransTime = Convert.ToInt32(item.TransTime);
                trans.FeeType = item.FeeType;
                trans.FeeAcct = item.FeeAcct;
                trans.Comments = item.Comments;
                trans.BankId = item.FromAcct.BankId;
                trans.BankName = item.FromAcct.BankName;
                trans.AcctId = item.FromAcct.AcctId;
                trans.AcctName = item.FromAcct.AcctName;
                trans.TransAmount = item.TransDetail.ToList().Sum(c => c.TransAmount);
                #endregion
                foreach (var line in item.TransDetail)
                {
                    #region detail
                    var detail = new TransDetailModel();
                    detail.EDIId = item.EDIId;
                    detail.LineId = item.TransDetail.IndexOf(line);
                    detail.ClientId = item.ClientId;
                    detail.BankId = line.ToAcct.BankId;
                    detail.BankName = line.ToAcct.BankName;
                    detail.AcctId = line.ToAcct.AcctId;
                    detail.AcctName = line.ToAcct.AcctName;
                    detail.AcctType = line.ToAcct.AcctType;
                    detail.TransCur = line.TransCur;
                    detail.TransAmount = line.TransAmount;
                    detail.SWIFTCode = line.SWIFTCode;
                    detail.ReciepterIdType = line.ReciepterIdType;
                    detail.ReciepterIdCode = line.ReciepterIdCode;
                    detail.ReceipterType = line.ReceipterType;
                    detail.Rate = line.Rate;
                    #endregion
                    trans.TransDetails.Add(detail);
                }
                transModels.Add(trans);
            }
            return transModels;
        }

        public string EDIId { get; set; }

        public string ClientId { get; set; }

        public string TransWay { get; set; }

        public string BusinessType { get; set; }

        public string PaymentCur { get; set; }

        public string PaymentType { get; set; }

        public string Purpose { get; set; }

        public emPriolv Priority { get; set; }

        public DateTime TransDate { get; set; }

        public int TransTime { get; set; }

        public string FeeType { get; set; }

        public string FeeAcct { get; set; }

        public string Comments { get; set; }

        public string BankId { get; set; }

        public string BankName { get; set; }

        public string AcctId { get; set; }

        public string AcctName { get; set; }

        /// <summary>
        /// 交易结果编码
        /// </summary>
        public string TransCode { get; set; }

        public Decimal TransAmount { get; set; }

        public List<TransDetailModel> TransDetails { get; set; }
    }
}
