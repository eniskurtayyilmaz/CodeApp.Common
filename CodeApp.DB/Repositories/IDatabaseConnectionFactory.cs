using System.Data;

namespace CodeApp.DB.Repositories
{
    public interface IDatabaseConnectionFactory
    {
        IDbConnection CreateConnection();
    }
}
