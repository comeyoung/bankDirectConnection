using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.QueryBO;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.PushBankment.BankTransfer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BankDirectConnection.Service.Controllers
{
    public class TransferQueryController : ApiController
    {
        /// <summary>
        /// 转账付款
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult QueryTransStatus([FromBody]ITransferQueryDataList TransferQueryData)
        {
            try
            {
                if (null == TransferQueryData)
                    throw new InnerException("2002003", "the format of trans info is bad.");
                BankService bankService = new BankService();
                var rt = bankService.QueryTransStatus(TransferQueryData);
                return Json(rt);
            }
            catch (BusinessException ex)
            {
                return Json(new ResResult(ex.Code, ex.Message));
            }
            catch (InnerException ex)
            {
                return Json(new ResResult(ex.Code, ex.Message));
            }
            catch (Exception ex)
            {
                return Json(new ResResult("2002004", ex.Message));
            }
        }
    }
}
