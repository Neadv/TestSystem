using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineTestSystem.Api.Models.Contracts
{
    public interface IRepository<T>
    {
        Task<T> GetById(object id);
        Task<IEnumerable<T>> GetAll();
        Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
    }
}
