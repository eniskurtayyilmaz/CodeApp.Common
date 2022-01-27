﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace CodeApp.Common.Models
{
    public class UserConfig
    {
        [JsonProperty("users", NullValueHandling = NullValueHandling.Ignore)]
        public List<User> Users { get; set; }
        [JsonProperty("connectionString", NullValueHandling = NullValueHandling.Ignore)]
        public string ConnectionString { get; set; }

        [JsonProperty("smtpAddresses", NullValueHandling = NullValueHandling.Ignore)]
        public List<SmtpAddress> SMTPAddresses { get; set; }
        public UserConfig()
        {
            Users = new List<User>();
            SMTPAddresses = new List<SmtpAddress>();
        }
    }
}