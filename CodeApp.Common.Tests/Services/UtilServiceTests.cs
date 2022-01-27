using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using CodeApp.Common.Helpers;
using CodeApp.Common.Models;
using CodeApp.Common.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace CodeApp.Common.Tests.Services
{
    [TestClass]
    public class UtilServiceTests
    {
        private IJsonHelpers<UserConfig> _jsonHelpers;
        private UtilService _utilService;

        [TestInitialize]
        public void Setup()
        {
            _jsonHelpers = new JsonHelpers<UserConfig>();
            _utilService = new UtilService(_jsonHelpers);
        }

        [TestMethod]
        public void Can_GetJsonString()
        {
            var result = _utilService.GetJsonString();

            result.Should().NotBeNullOrEmpty();
            result.Should().NotBeNullOrWhiteSpace();
        }

        [TestMethod]
        public void Can_Get_UserConfig()
        {
            var result = _utilService.GetUserConfig();

            result.Should().NotBeNull();

            result.ConnectionString.Should().NotBeNullOrEmpty();
            result.ConnectionString.Should().NotBeNullOrWhiteSpace();
            result.ConnectionString.Should().Be("Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 172.19.22.155)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = ORFTSTDB))) ; User Id=finans; Password=Glmnfls78T;");

            result.Users.Should().HaveCount(2);
            result.Users[0].UserName.Should().Be("userNameTest1");
            result.Users[0].Password.Should().Be("passwordTest1");
            result.Users[1].UserName.Should().Be("testUser");
            result.Users[1].Password.Should().Be("testPassword");

            result.SMTPAddresses.Should().HaveCount(2);
            result.SMTPAddresses[0].SMTPAddress.Should().Be("smtpAddress1");
            result.SMTPAddresses[0].SMTPEmailAddress.Should().Be("smtpEmailAddress1");
            result.SMTPAddresses[0].SMTPEmailPassword.Should().Be("smtpEmailPassword1");
            result.SMTPAddresses[0].UseDefaultCredentials.Should().Be(true);       
            result.SMTPAddresses[0].EnableSSL.Should().Be(true);
            result.SMTPAddresses[0].Port.Should().Be(1);
            result.SMTPAddresses[0].ReplyToAddress.Should().Be("replyToAddress");  
            
            
            result.SMTPAddresses[1].SMTPAddress.Should().Be("smtpAddress2");
            result.SMTPAddresses[1].SMTPEmailAddress.Should().Be("smtpEmailAddress2");
            result.SMTPAddresses[1].SMTPEmailPassword.Should().Be("smtpEmailPassword2");
            result.SMTPAddresses[1].UseDefaultCredentials.Should().Be(true);       
            result.SMTPAddresses[1].EnableSSL.Should().Be(true);
            result.SMTPAddresses[1].Port.Should().Be(2);
            result.SMTPAddresses[1].ReplyToAddress.Should().Be("replyToAddress");
        }

        [TestMethod]
        public void Can_Get_ConnectionString()
        {
            var result = _utilService.GetConnectionString();

            result.Should().NotBeNull();
            result.Should().NotBeNullOrEmpty();
            result.Should().NotBeNullOrWhiteSpace();
            result.Should().Be("Data Source=(DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 172.19.22.155)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = ORFTSTDB))) ; User Id=finans; Password=Glmnfls78T;");
        }

        [TestMethod]
        [DataRow("userNameTest1", "passwordTest1")]
        [DataRow("testUser", "testPassword")]
        public void Can_Get_ExistUser(string userName, string password)
        {
            var result = _utilService.GetExistUser(userName, password);


            result.Should().NotBeNull();
            result.UserName.Should().Be(userName);
            result.Password.Should().Be(password);
        }
    }
}
