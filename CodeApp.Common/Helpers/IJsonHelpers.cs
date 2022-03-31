using System.Text;
using CodeApp.Common.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CodeApp.Common.Helpers
{
    public interface IJsonHelpers
    {
        T DeSerialize<T>(string json);
        string Serialize(object obj);
        byte[] SerializeAsByteArray(object value);
    }

    public class JsonHelpers : IJsonHelpers 
    {
        public JsonHelpers()
        {
                
        }

        private readonly JsonSerializerSettings _serializeOptions = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
            PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None,
            Culture = System.Globalization.CultureInfo.CurrentCulture,
            DateTimeZoneHandling = Newtonsoft.Json.DateTimeZoneHandling.Local,
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
        };
        

        public T DeSerialize<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json, _serializeOptions);
        }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj, _serializeOptions);
        }

        public byte[] SerializeAsByteArray(object value)
        {
            return Encoding.UTF8.GetBytes(Serialize(value));
        }
    }
}
