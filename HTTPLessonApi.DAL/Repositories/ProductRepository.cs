using System.Collections.Generic;
using System.Threading.Tasks;
using HTTPLessonApi.Domain.Entity;
using HTTPLessonApi.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HTTPLessonApi.DAL.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public async Task<IEnumerable<Product>> Select()
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Products.ToListAsync();
            }
        }

        public async Task<Product> Get(int? id)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Products.FirstOrDefaultAsync(x => x.Id == id);
            }
        }

        public async Task<Product> GetByParameter(object name)
        {
            using (var db = new ApplicationDbContext())
            {
                return await db.Products.FirstOrDefaultAsync(x => x.Name == name);
            }
        }

        public async Task<Product> Insert(Product product)
        {
            using (var db = new ApplicationDbContext())
            {
                await db.Products.AddAsync(product);
                await db.SaveChangesAsync();
                return product;
            }
        }

        public async Task InsertSomeValues(IEnumerable<Product> products)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Products.AddRange(products);
                await db.SaveChangesAsync();
            }
        }

        public async Task Delete(Product product)
        {
            using (var db = new ApplicationDbContext())
            { 
                db.Products.Remove(product);
                await db.SaveChangesAsync();
            }
        }
        
        public async Task Update(Product product)
        {
            using (var db = new ApplicationDbContext())
            { 
                db.Products.Update(product);
                await db.SaveChangesAsync();
            }
        }
    }
}