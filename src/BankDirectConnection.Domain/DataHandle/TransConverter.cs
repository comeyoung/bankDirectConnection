using BankDirectConnection.Domain.TransferBO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankDirectConnection.Domain.DataHandle
{
    /*===============================================================================================================================
	*	Create by Fancy at 2018/1/26 11:20:01
	===============================================================================================================================*/
    public class TransConverter<TConcrete, TInterface> : JsonConverter where TConcrete: TInterface
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Transcations));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            List<TConcrete> data = serializer.Deserialize<List<TConcrete>>(reader);
            
            List<TInterface> result = new List<TInterface>();
            foreach (TInterface d in data)
            {
                result.Add(d);
            }
            return result;
        }

    

        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            serializer.Serialize(writer, value);
        }
    }
}
