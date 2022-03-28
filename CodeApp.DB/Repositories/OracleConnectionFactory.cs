using Oracle.ManagedDataAccess.Client;
using System.Data;
using System.Threading.Tasks;
using Dapper;

namespace CodeApp.DB.Repositories
{
    public class OracleConnectionFactory : IDatabaseConnectionFactory, IDatabaseConnectionAsyncFactory
    {
        private readonly string _connectionString;

        public OracleConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            var sqlConnection = new OracleConnection(_connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var sqlConnection = new OracleConnection(_connectionString);
            await sqlConnection.OpenAsync();
            return sqlConnection;
        }
    }
}
