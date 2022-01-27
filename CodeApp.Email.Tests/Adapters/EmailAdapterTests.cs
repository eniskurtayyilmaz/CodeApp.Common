using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using AutoFixture;
using CodeApp.Email.Adapter;
using CodeApp.Email.Models;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CodeApp.Email.Tests.Adapters
{

    public class EmailGenerator
    {
        public Guid AccountId { get; set; }
        public IEnumerable<string> EmailAddresses { get; set; }
    }

    [TestClass]
    public class EmailAdapterTests
    {
        private Mock<ISmtpClient> _mockSmtpClientAdapter;

        [TestInitialize]
        public void Setup()
        {
            this._mockSmtpClientAdapter = new Mock<ISmtpClient>();
        }

        [TestMethod]
        public void Can_Get_Instance()
        {
            var adapter = new EmailAdapter(_mockSmtpClientAdapter.Object);
        }

        [TestMethod]
        public void Can_Send_Mail()
        {
            var fixture = new AutoFixture.Fixture();
            fixture.Customize<EmailGenerator>(c => c
                .With(x =>
                        x.EmailAddresses,
                    fixture.CreateMany<MailAddress>().Select(x => x.Address)));

            var t = fixture.Create<EmailGenerator>();

            var emailModel = fixture.Build<EmailMessage>()
                .With(x => x.Body, "body")
                .With(x => x.To, t.EmailAddresses.ToList)
                .With(x => x.Bcc, t.EmailAddresses.ToList)
                .With(x => x.Cc, t.EmailAddresses.ToList)

                .Create();

            _mockSmtpClientAdapter.Setup(x => x.Host).Returns("smtp.address.com");
            _mockSmtpClientAdapter.Setup(x => x.SMTPEmailAddress).Returns("smtp@address.com");
            _mockSmtpClientAdapter.Setup(x => x.ReplyAddress).Returns("reply@address.com");
            _mockSmtpClientAdapter.Setup(x => x.EnableSsl).Returns(true);
            _mockSmtpClientAdapter.Setup(x => x.UseDefaultCredentials).Returns(true);
            _mockSmtpClientAdapter.Setup(x => x.Port).Returns(10);

            _mockSmtpClientAdapter.Setup(x => x.Send(It.IsAny<MailMessage>())).Callback((MailMessage m) =>
            {
                m.To.Count.Should().Be(emailModel.To.Count);
                m.CC.Count.Should().Be(emailModel.Cc.Count);
                m.Bcc.Count.Should().Be(emailModel.Bcc.Count);
                m.IsBodyHtml.Should().Be(emailModel.IsHTMLBody);
                m.Body.Should().Be(emailModel.Body);
                m.Subject.Should().Be(emailModel.Subject);
            });

            var adapter = new EmailAdapter(_mockSmtpClientAdapter.Object);

            //Action
            var result = adapter.SendMail(emailModel);

            result.IsError.Should().BeFalse();
            result.Message.Should().Be("OK");
        }

        [TestMethod]
        public void Can_Not_Send_Mail()
        {
            var fixture = new AutoFixture.Fixture();
            fixture.Customize<EmailGenerator>(c => c
                .With(x =>
                        x.EmailAddresses,
                    fixture.CreateMany<MailAddress>().Select(x => x.Address)));

            var t = fixture.Create<EmailGenerator>();

            var emailModel = fixture.Build<EmailMessage>()
                .With(x => x.Body, "body")
                .With(x => x.To, t.EmailAddresses.ToList)
                .With(x => x.Bcc, t.EmailAddresses.ToList)
                .With(x => x.Cc, t.EmailAddresses.ToList)

                .Create();

            _mockSmtpClientAdapter.Setup(x => x.Host).Returns("smtp.address.com");
            _mockSmtpClientAdapter.Setup(x => x.SMTPEmailAddress).Returns("smtp@address.com");
            _mockSmtpClientAdapter.Setup(x => x.ReplyAddress).Returns("reply@address.com");
            _mockSmtpClientAdapter.Setup(x => x.EnableSsl).Returns(true);
            _mockSmtpClientAdapter.Setup(x => x.UseDefaultCredentials).Returns(true);
            _mockSmtpClientAdapter.Setup(x => x.Port).Returns(10);

            _mockSmtpClientAdapter.Setup(x => x.Send(It.IsAny<MailMessage>())).Callback((MailMessage m) =>
            {
                m.To.Count.Should().Be(emailModel.To.Count);
                m.CC.Count.Should().Be(emailModel.Cc.Count);
                m.Bcc.Count.Should().Be(emailModel.Bcc.Count);
                m.IsBodyHtml.Should().Be(emailModel.IsHTMLBody);
                m.Body.Should().Be(emailModel.Body);
                m.Subject.Should().Be(emailModel.Subject);

                throw new Exception("Hobaaa");
            });

            var adapter = new EmailAdapter(_mockSmtpClientAdapter.Object);

            //Action
            var result = adapter.SendMail(emailModel);

            result.IsError.Should().BeTrue();
            result.Message.Should().Be("Hobaaa");
        }
    }
}