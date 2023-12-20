using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApp.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(long Id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(long Id);
    }
}
