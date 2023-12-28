﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApp.IRepositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(long Id);
        Task<T> GetByIdAsync<TId>(TId id);
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> AddAsync(T entity);
        Task<T> UpdateAsync(T entity);
        Task DeleteAsync(long Id);
    }
}
