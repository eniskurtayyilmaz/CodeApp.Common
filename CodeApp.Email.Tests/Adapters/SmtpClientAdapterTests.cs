using System.Collections.Generic;
using AutoFixture;
using CodeApp.Common.Models;
using CodeApp.Email.Adapter;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeApp.Email.Tests.Adapters
{
    [TestClass]
    public class SmtpClientAdapterTests
    {
        [TestMethod]
        public void Can_Get_Instance()
        {
            var fixture = new AutoFixture.Fixture();
            var model = fixture.Create<SmtpAddressConfig>();

            ISmtpClient adapter = new SmtpClientAdapter(model);

            adapter.Host.Should().Be(model.SMTPAddress);
            adapter.Port.Should().Be(model.Port);
            adapter.EnableSsl.Should().Be(model.EnableSSL);
            adapter.UseDefaultCredentials.Should().Be(model.EnableSSL);
            adapter.ReplyAddress.Should().Be(model.ReplyToAddress);
            adapter.SMTPEmailAddress.Should().BeEquivalentTo(model.SMTPEmailAddress);
        }
    }
}
