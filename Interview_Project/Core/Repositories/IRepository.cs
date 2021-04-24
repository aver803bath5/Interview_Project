using System.Collections.Generic;
using System.Threading.Tasks;

namespace Interview_Project.Core.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<T> DeleteAsync(int id);
        Task<T> AddAsync(T entity);
    }
}