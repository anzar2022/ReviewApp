﻿using ReviewApp.IRepositories;
using ReviewApp.IServices;
using ReviewApp.Model;

namespace ReviewApp.Services
{
    public class StatusService : IStatusService
    {
        private readonly IStatusRepository _repository;

        public StatusService(IStatusRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<Status> GetStatusByIdAsync(int id)
        {
            return await _repository.GetByIdAsync<int>(id);
        }

        public async Task<IEnumerable<Status>> GetAllStatusesAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddStatusAsync(Status status)
        {
            await _repository.AddAsync(status);
        }

        public async Task UpdateStatusAsync(Status status)
        {
            await _repository.UpdateAsync(status);
        }

        public async Task DeleteStatusAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
