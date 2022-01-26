using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using CodeApp.Oracle.Helpers;
using CodeApp.Oracle.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeApp.Oracle.Tests.Helpers
{
    [TestClass]
    public class JsonHelpersTests
    {
        [TestMethod]
        public void Can_Get_Object_By_Json_UserConfig()
        {
            string json = Properties.Resources.UserJson;
            var userConfig = new JsonHelpers<UserConfig>().GetJsonObject(json);

            userConfig.Should().NotBeNull();

            userConfig.ConnectionString.Should().NotBeNullOrEmpty();
            userConfig.ConnectionString.Should().NotBeNullOrWhiteSpace();
            userConfig.ConnectionString.Should().Be("connectionStringTest");

            userConfig.Users.Should().HaveCount(2);
            userConfig.Users[0].UserName.Should().Be("userNameTest1");
            userConfig.Users[0].Password.Should().Be("passwordTest1");
            userConfig.Users[1].UserName.Should().Be("userNameTest2");
            userConfig.Users[1].Password.Should().Be("passwordTest2");
        }
    }
}
