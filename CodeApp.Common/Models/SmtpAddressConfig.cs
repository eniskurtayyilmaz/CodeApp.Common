using Newtonsoft.Json;

namespace CodeApp.Common.Models
{
    public class SmtpAddress 
    {
        [JsonProperty("smtpAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string SMTPAddress { get; set; }

        [JsonProperty("smtpEmailAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string SMTPEmailAddress { get; set; }

        [JsonProperty("smtpEmailPassword", NullValueHandling = NullValueHandling.Ignore)]
        public string SMTPEmailPassword { get; set; }

        [JsonProperty("port", NullValueHandling = NullValueHandling.Ignore)]
        public int Port { get; set; }

        [JsonProperty("useDefaultCredentials", NullValueHandling = NullValueHandling.Ignore)]
        public bool UseDefaultCredentials { get; set; }

        [JsonProperty("enableSSL", NullValueHandling = NullValueHandling.Ignore)]
        public bool EnableSSL { get; set; }

        [JsonProperty("replyToAddress", NullValueHandling = NullValueHandling.Ignore)]
        public string ReplyToAddress { get; set; }

        public void Map(SmtpAddress existQuery)
        {
            this.SMTPAddress = existQuery.SMTPAddress;
            this.SMTPEmailAddress = existQuery.SMTPEmailAddress;
            this.Port = existQuery.Port;
            this.UseDefaultCredentials = existQuery.UseDefaultCredentials;
            this.EnableSSL = existQuery.EnableSSL;
            this.ReplyToAddress = existQuery.ReplyToAddress;
        }
    }
}