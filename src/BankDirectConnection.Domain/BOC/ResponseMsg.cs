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
            this.status = new Status();
            this.DetailResponses = new List<DetailResponse>();
        }
        public Status status { get; set; }

        public string serverdt { get; set; }

        public string token { get; set; }

        public List<DetailResponse> DetailResponses { get; set; }
    }

    public class DetailResponse
    {
        public Status status { get; set; }

        public string insid { get; set; }

        public string obssid { get; set; }

    }


}
