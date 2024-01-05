using System.Linq.Expressions;

namespace ReviewApp.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(long Id);
        Task<T> GetByIdAsync<TId>(TId id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task<bool> DeleteAsync(long Id);

        Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> filter);
        Task<T> FilterSingleOrDefaultAsync(Expression<Func<T, bool>> filter);
    }
}
