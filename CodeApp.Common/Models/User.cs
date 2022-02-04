using Newtonsoft.Json;

namespace CodeApp.Common.Models
{
    public class User : IModel
    {

        [JsonProperty("userName", NullValueHandling = NullValueHandling.Ignore)]
        public string UserName { get; set; }

        [JsonProperty("password", NullValueHandling = NullValueHandling.Ignore)]
        public string Password { get; set; }
    }
}