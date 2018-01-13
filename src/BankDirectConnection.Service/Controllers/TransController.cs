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
        /// <summary>
        /// 转账付款
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult PaymentTransfer([FromBody]Transcations Transcations)
        {
            return Json(new { code = 0 });
        }

        /// <summary>
        /// 转账付款
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult QueryTransStatus([FromBody]TransferQueryDataList TransferQueryData)
        {
            return Json(new { code = 0 });
        }
    }
}
