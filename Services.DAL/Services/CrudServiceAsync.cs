using Models;
using Services.Interfaces;
using System.Data.Entity ;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DAL.Services
{
    public class CrudServiceAsync<T> : IServiceAsync<T> where T : Entity
    {

        public async Task<int> CreateAsync(T entity)
        {
            using (var context = new Context())
            {
                var dbEntity = context.Set<T>().Add(entity);
                await context.SaveChangesAsync();
                return dbEntity.Id;
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var context = new Context())
            {
                var entity = await context.Set<T>().FindAsync(id);
                if (entity == null)
                    return;

                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<T>> ReadAsync()
        {
            using (var context = new Context())
            {
                var entities = await context.Set<T>().ToListAsync();
                await Task.Delay(5000);
                return entities;
            }
        }

        public async Task<T> ReadAsync(int id)
        {
            using (var context = new Context())
            {
                return await context.Set<T>().FindAsync(id);
            }
        }

        public async Task UpdateAsync(int id, T entity)
        {
            using (var context = new Context())
            {
                entity.Id = id;
                context.Set<T>().Attach(entity);
                context.Entry(entity).State = System.Data.Entity.EntityState.Modified;

                await context.SaveChangesAsync();
            }
        }
    }
}
