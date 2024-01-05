using Microsoft.EntityFrameworkCore;
using ReviewApp.ErrorHandling;
using ReviewApp.IRepositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApp.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly DbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(DbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _dbSet = _context.Set<T>();
        }

        public async Task<T> GetByIdAsync(long id)
        {
            T entity = await _dbSet.FindAsync(id);

            if (entity == null)
            {
                // Handle the case where the entity with the given id is not found
                // For example, you can throw a NotFoundException or handle it based on your application's logic
                throw new NotFoundException($"Entity with ID '{id}' not found.");
                // Or you can return null or any other default value based on your requirements
                // return null;
            }

            return entity;
        }
        public async Task<T> GetByIdAsync<TId>(TId id)
        {
            T entity = await _dbSet.FindAsync(id);

            if (entity == null)
            {
                // Handle the case where the entity with the given id is not found
                // For example, you can throw a NotFoundException or handle it based on your application's logic
                throw new NotFoundException($"Entity with ID '{id}' not found.");
                // Or you can return null or any other default value based on your requirements
                // return null;
            }

            return entity;
        }


        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _context.SaveChangesAsync();

                return entity; // Return the added entity
            }
            catch (DbUpdateException)
            {
                // Handle specific database update exception, if needed
                // You can log the exception or perform any other necessary actions
                throw; // Re-throw the exception to be handled at a higher level
            }
            catch (Exception)
            {
                // Handle other exceptions that might occur during the adding process
                // You can log the exception or perform any other necessary actions
                throw; // Re-throw the exception to be handled at a higher level
            }
        }

        //public async Task UpdateAsync(T entity)
        //{
        //    _dbSet.Attach(entity);
        //    _context.Entry(entity).State = EntityState.Modified;
        //    await _context.SaveChangesAsync();
        //}
        public async Task<T> UpdateAsync(T entity)
        {
            try
            {
                _dbSet.Attach(entity);
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return entity; // Return the updated entity
            }
            catch (DbUpdateException ex)
            {
                // Handle specific database update exception, if needed
                // You can log the exception or perform any other necessary actions
                throw; // Re-throw the exception to be handled at a higher level
            }
            catch (Exception ex)
            {
                // Handle other exceptions that might occur during the update process
                // You can log the exception or perform any other necessary actions
                throw; // Re-throw the exception to be handled at a higher level
            }
        }

        public async Task<bool> DeleteAsync(long Id)
        {
            var entity = await _dbSet.FindAsync(Id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _context.SaveChangesAsync();

                return true;
            }
            return false;
        }

        public async Task<IEnumerable<T>> FilterAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.Where(filter).ToListAsync();
        }

        public async Task<T> FilterSingleOrDefaultAsync(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.SingleOrDefaultAsync(filter);
        }
    }
}
