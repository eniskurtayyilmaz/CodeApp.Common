using FluentAssertions;
using CodeApp.Oracle.Repositories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeApp.Oracle.Tests.Repositories
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
    }
}
