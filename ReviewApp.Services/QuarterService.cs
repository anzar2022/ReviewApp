﻿using ReviewApp.IRepositories;
using ReviewApp.IServices;
using ReviewApp.Model;

namespace ReviewApp.Services
{
    public class QuarterService : IQuarterService
    {
        private readonly IQuarterRepository _repository;

        public QuarterService(IQuarterRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Quarter> GetQuarterByIdAsync(int Id)
        {
            return await _repository.GetByIdAsync<int>(Id);
        }

        public async Task<IEnumerable<Quarter>> GetAllQuartersAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddQuarterAsync(Quarter quarter)
        {
            await _repository.AddAsync(quarter);
        }

        public async Task UpdateQuarterAsync(Quarter quarter)
        {
            await _repository.UpdateAsync(quarter);
        }

        public async Task DeleteQuarterAsync(int Id)
        {
            await _repository.DeleteAsync(Id);
        }
    }
}
