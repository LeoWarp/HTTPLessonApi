using System.Collections.Generic;
using System.Threading.Tasks;
using HTTPLessonApi.Domain.Entity;

namespace HTTPLessonApi.Domain.Interfaces.Repositories
{
    public interface IProductRepository : IRepository<Product>
    {
        Task<Product> GetByParameter(object obj);

        Task InsertSomeValues(IEnumerable<Product> products);
    }
}