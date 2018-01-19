using BankDirectConnection.Domain.QueryBO;
using BankDirectConnection.Domain.TransferBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BankDirectConnection.Service.Controllers
{
    public class TransController : ApiController
    {
        public TransController()
        {

        }
        /// <summary>
        /// 转账付款
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult PaymentTransfer([FromBody]ITranscations Transcations)
        {
            try
            {

            }
            catch(Exception ex)
            {

            }
            return Json(new { code = 0 });
        }

        /// <summary>
        /// 转账付款
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult QueryTransStatus([FromBody]ITransferQueryDataList TransferQueryData)
        {
            try
            {

            }
            catch(Exception ex)
            {

            }
            return Json(new { code = 0 });
        }
    }
}
