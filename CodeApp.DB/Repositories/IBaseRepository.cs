using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeApp.DB.Repositories
{
    public interface IBaseRepositoryAsync<TRequest, TResponse>
    {
        TResponse GetByIdAsync(string id);
        IEnumerable<TResponse> GetAllAsync();
        int AddAsync(TRequest entity);
        int UpdateAsync(TRequest entity);
        int DeleteAsync(string id);
        TResponse ExecuteAsync(TRequest model);
    }

    public interface IBaseRepository<TRequest, TResponse>
    {
        TResponse GetById(string id);
        IEnumerable<TResponse> GetAll();
        int Add(TRequest entity);
        int Update(TRequest entity);
        int Delete(string id);
        TResponse Execute(TRequest model);
    }
}
