using System.Collections.Generic;
using System.Threading.Tasks;

namespace HTTPLessonApi.Domain.Interfaces.Repositories
{
    public interface IRepository<T>
    {
        Task<T> Get(int? id);

        Task Update(T entity);

        Task<IEnumerable<T>> Select();
        
        Task<T> Insert(T entity);

        Task Delete(T entity);
    }
}