using BankDirectConnection.BaseApplication.BaseTranscation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.TransferBO
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/12 18:03:36
	===============================================================================================================================*/
    public class Transcations : BaseTranscations<ITranscation>, ITranscations
    {

<<<<<<< HEAD
        public Transcations()
        {
            this.Transcations = new List<ITranscation>();
        }

     

        public IList<ITranscation> Transcation { get; set; }
=======
>>>>>>> edi/master
    }

   
}
