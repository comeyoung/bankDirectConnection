﻿using BankDirectConnection.BaseApplication.BaseTranscation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.TransferBO
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/12 18:02:26
	===============================================================================================================================*/
    public interface ITranscations : IBaseTranscations<ITranscation>
    {
        // IList<ITranscation> Transcations { get; set; }
    }
}