using System.Data;

namespace CodeApp.Oracle.Repositories
{
    public interface IDatabaseConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
