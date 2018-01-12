using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.BaseApplication.BaseTranscation
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/12 17:56:27
	===============================================================================================================================*/
    public interface IBaseTranscations<T> where T:IBaseTranscation
    {
        /// <summary>
        /// 转账方式
        /// </summary>
        string TransWay { get; set; }
        /// <summary>
        /// 转账业务类型
        /// </summary>
        string BusinessType { get; set; }

        IList<T> Transcations { get; set; }

        bool Check();
    }
}
