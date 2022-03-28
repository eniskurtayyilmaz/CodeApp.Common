using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeApp.DB.Repositories
{
    public interface IBaseRepositoryAsync<TRequest>
    {
        Task<TRequest> GetByIdAsync(string id);
        Task<IEnumerable<TRequest>> GetAllAsync();
        Task<int> AddAsync(TRequest entity);
        Task<int> UpdateAsync(TRequest entity);
        Task<int> DeleteAsync(string id);
        Task<TRequest> ExecuteAsync(TRequest model);
    }

    public interface IBaseRepository<TRequest>
    {
        TRequest GetById(string id);
        IEnumerable<TRequest> GetAll();
        int Add(TRequest entity);
        int Update(TRequest entity);
        int Delete(string id);
        TRequest Execute(TRequest model);
    }

    public interface IBaseRepositoryAsync<TRequest, TResponse>
    {
        Task<TResponse> GetByIdAsync(string id);
        Task<IEnumerable<TResponse>> GetAllAsync();
        Task<int> AddAsync(TRequest entity);
        Task<int> UpdateAsync(TRequest entity);
        Task<int> DeleteAsync(string id);
        Task<TResponse> ExecuteAsync(TRequest model);
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
