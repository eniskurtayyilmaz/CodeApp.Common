using System.Net.Mail;
using CodeApp.Common.Models;

namespace CodeApp.Email.Adapter
{
    public interface ISmtpClient
    {
        void Send(MailMessage mail);
        string Host { get; }
        string ReplyAddress { get; }
        int Port { get; }
        bool EnableSsl { get; }
        bool UseDefaultCredentials { get; }
        string SMTPEmailAddress { get; }
    }
    public class SmtpClientAdapter : SmtpClient, ISmtpClient
    {
        private readonly SmtpAddress _smtpAddress;
        private string _replyAddress;

        public SmtpClientAdapter(SmtpAddress smtpAddress)
        {
            _smtpAddress = smtpAddress;
            this.BuildSMTP();
        }

        public void BuildSMTP()
        {
            this.Host = _smtpAddress.SMTPAddress;
            this.Port = _smtpAddress.Port;
            this.EnableSsl = _smtpAddress.EnableSSL;
            this.UseDefaultCredentials = _smtpAddress.UseDefaultCredentials;
            this.Credentials = new System.Net.NetworkCredential(_smtpAddress.SMTPEmailAddress, _smtpAddress.SMTPEmailPassword);
        }


        string ISmtpClient.Host => this.Host;
        int ISmtpClient.Port => this.Port;
        bool ISmtpClient.EnableSsl => this.EnableSsl;
        bool ISmtpClient.UseDefaultCredentials => this.UseDefaultCredentials;
        string ISmtpClient.ReplyAddress => _smtpAddress.ReplyToAddress;
        string ISmtpClient.SMTPEmailAddress => _smtpAddress.SMTPEmailAddress;
    }
}