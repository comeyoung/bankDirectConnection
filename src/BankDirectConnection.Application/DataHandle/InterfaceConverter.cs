using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.BaseApplication.DataHandle
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/26 11:06:12
	===============================================================================================================================*/
    public class InterfaceConverter<TInterface, TConcrete> : CustomCreationConverter<TInterface>
       where TConcrete : TInterface, new()
    {
        public override TInterface Create(Type objectType)
        {
            return new TConcrete();
        }
    }
}
