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
    public class TranscationConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            return (objectType == typeof(Transcations));
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                List<Transcation> data = serializer.Deserialize<List<Transcation>>(reader);
                
                List<ITranscation> result = new List<ITranscation>();
                foreach (var d in data)
                {
                    result.Add(d);
                }
                return result;
            }
            catch(Exception ex)
            {
                throw ex;
            }
           
        }

        public override bool CanWrite
        {
            get { return false; }
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
