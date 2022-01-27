using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using CodeApp.Email.Models;

namespace CodeApp.Email.Adapter
{
    public interface IEmailAdapter
    {
        EmailResult SendMail(EmailMessage emailMessage);
    }

    public class EmailAdapter : IEmailAdapter
    {
        private readonly ISmtpClient _smtpClient;

        public EmailAdapter(ISmtpClient smtpClient)
        {
            this._smtpClient = smtpClient;
        }

        public EmailResult SendMail(EmailMessage emailMessage)
        {
            using (MailMessage mailMessage = new MailMessage())
            {
                foreach (var to in emailMessage.To)
                {
                    mailMessage.To.Add(to);
                }

                foreach (var bcc in emailMessage.Bcc)
                {
                    mailMessage.Bcc.Add(bcc);
                }

                foreach (var cc in emailMessage.Cc)
                {
                    mailMessage.CC.Add(cc);
                }

                if (!string.IsNullOrEmpty(_smtpClient.ReplyAddress))
                {
                    mailMessage.ReplyToList.Add(new MailAddress(_smtpClient.ReplyAddress, "reply-to"));
                }

                mailMessage.From = new MailAddress(_smtpClient.SMTPEmailAddress);
                mailMessage.Subject = emailMessage.Subject;
                mailMessage.IsBodyHtml = emailMessage.IsHTMLBody;
                mailMessage.Body = emailMessage.Body;
                try
                {

                    _smtpClient.Send(mailMessage);
                    return new EmailResult()
                    {
                        Message = "OK"
                    };
                }
                catch (Exception e)
                {
                    return new EmailResult()
                    {
                        IsError = true,
                        Message = e.Message
                    };
                }
            }
        }
    }
}
