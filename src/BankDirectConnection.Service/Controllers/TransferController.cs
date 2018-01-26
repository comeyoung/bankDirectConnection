using BankDirectConnection.BaseApplication.ExceptionMsg;
using BankDirectConnection.Domain.QueryBO;
using BankDirectConnection.Domain.Service;
using BankDirectConnection.Domain.TransferBO;
using BankDirectConnection.PushBankment.BankTransfer;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
namespace BankDirectConnection.Service.Controllers
{
    public class TransferController : ApiController
    {
        /// <summary>
        /// 转账付款
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IHttpActionResult PaymentTransfer()
        { 
            try
            {
                HttpContent requestContent = Request.Content;
                string tranJson = requestContent.ReadAsStringAsync().Result;
                if (null == tranJson)
                    throw new InnerException("2002003", "the format of trans info is bad.");
                var Transcations = JsonConvert.DeserializeObject<Transcations>(tranJson);
                BankService bankService = new BankService();
                var rt = bankService.PaymentTransfer(Transcations);
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