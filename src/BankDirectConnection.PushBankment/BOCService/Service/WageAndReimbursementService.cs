﻿using BankDirectConnection.Domain.Service;
using BankDirectConnection.Domain.TransferBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.PushBankment.BOCService.Service
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/12 11:17:23
	===============================================================================================================================*/
    /// <summary>
    /// 工资、报销代发快捷支付业务
    /// </summary>
    public class WageAndReimbursementService
    {
        public IResResult PushWageOrReimbursementInfo(ITranscations Transcations)
        {
            IResResult result = new ResResult();
            //获取token
            //构建xml
            //调用接口
            //处理result
            
            return result;
        }
    }
}
