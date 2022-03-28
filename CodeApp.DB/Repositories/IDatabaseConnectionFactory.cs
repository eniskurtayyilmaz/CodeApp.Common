using System.Data;
using System.Threading.Tasks;

namespace CodeApp.DB.Repositories
{
    public interface IDatabaseConnectionFactory
    {
        IDbConnection CreateConnection();
    }

    public interface IDatabasaeConnectionAsyncFactory
    {
        Task<IDbConnection> CreateConnectionAsync();
    }
}
