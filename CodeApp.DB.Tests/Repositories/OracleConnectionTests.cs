using CodeApp.DB.Helpers;
using CodeApp.DB.Repositories;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Data;

namespace CodeApp.DB.Tests.Repositories
{


    [TestClass]
    public class OracleConnectionTests
    {

        [TestMethod]
        [Ignore("Realtime connection required")]

        public void Can_Connect_OracleDb()
        {
            var connectionString = Properties.Resources.ConnectionString;

            using (var oracleConnectionFactory = new OracleConnectionFactory(connectionString).CreateConnection())
            {
                oracleConnectionFactory.State.Should().Be(ConnectionState.Open);
            }
        }

        [TestMethod]
        [Ignore("Realtime connection required")]

        public void Can_Connect_OracleDb_With_DateTimeFormat()
        {
            var connectionString = Properties.Resources.ConnectionString;

            using (var oracleConnectionFactory = new OracleConnectionFactory(connectionString).CreateConnection().SetOracleDate())
            {
                oracleConnectionFactory.State.Should().Be(ConnectionState.Open);
            }
        }
    }
}
