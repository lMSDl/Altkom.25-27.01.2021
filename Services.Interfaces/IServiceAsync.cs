using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface IServiceAsync<T> where T : Entity
    {
        Task<IEnumerable<T>> ReadAsync();
        Task<int> CreateAsync(T entity);
        Task<T> ReadAsync(int id);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
    }
}
