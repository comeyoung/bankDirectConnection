using BankDirectConnection.BaseApplication.BaseTranscation;
using BankDirectConnection.Domain.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.BOC
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/11 17:37:00
	===============================================================================================================================*/
    public class ResponseMsg
    {
        public ResponseMsg()
        {
            this.Status = new Status();
            this.DetailResponses = new List<DetailResponse>();
        }
        public Status Status { get; set; }

        public string Serverdt { get; set; }

        public string Token { get; set; }

        public List<DetailResponse> DetailResponses { get; set; }
    }

    public class DetailResponse
    {
        public DetailResponse()
        {
            this.Status = new Status();
        }
        public Status Status { get; set; }

        public string Insid { get; set; }

        public string Obssid { get; set; }

    }


}
