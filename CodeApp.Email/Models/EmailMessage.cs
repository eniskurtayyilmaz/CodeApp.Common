using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeApp.Email.Models
{
    public class EmailMessage : IDisposable
    {
        public List<string> To { get; set; }
        public List<string> Bcc { get; set; }
        public List<string> Cc { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }

        public bool IsHTMLBody { get; set; }

        public EmailMessage()
        {
            To = new List<string>();
            Bcc = new List<string>();
            Cc = new List<string>();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }

    public class EmailResult
    {
        public bool IsError { get; set; }
        public string Message { get; set; }
    }
}
