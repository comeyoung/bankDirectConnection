using BankDirectConnection.Domain.BOC.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
    /*===============================================================================================================================
	*	Create by Fancy at 2017/12/24 16:59:25
	===============================================================================================================================*/
    public class WageAndReimbursementMsg
    {
        public WageAndReimbursementMsg()
        {
            this.HeaderMessage = new Header();
            this.Trans = new WageAndReimbursementTrans();
        }
        public Header HeaderMessage { get; set; }

        public WageAndReimbursementTrans Trans { get; set; }
    }
    public class WageAndReimbursementTrans
    {
        public string Ceitinfo { get; set; }
        public string Transtype { get; set; }
        public string Insid { get; set; }
        public string Telephone { get; set; }

        public string Pybcur { get; set; }

        public string Pybamt { get; set; }
        public string Pybnum { get; set; }

        public string Crdtyp { get; set; }

        public string Furinfo { get; set; }

        public string Useinf { get; set; }

        public string Trfdate { get; set; }

        public Fractn FractnMessage { get; set; }

        public Detail DetailMessage { get; set; }
    }


    public class Detail
    {
        public string Toibkn { get; set; }

        public string Tobank { get; set; }

        public string Toactn { get; set; }

        public string Pydcur { get; set; }

        public string Pydamt { get; set; }

        public string Toname { get; set; }

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
