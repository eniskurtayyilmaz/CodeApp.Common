using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CodeApp.DB.Repositories
{
    public class SqlConnectionFactory : IDatabaseConnectionFactory, IDatabaseConnectionAsyncFactory
    {
        private readonly string _connectionString;

        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection CreateConnection()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            return sqlConnection;
        }

        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync();
            return sqlConnection;
        }
    }
}