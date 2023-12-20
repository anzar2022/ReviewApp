﻿using ReviewApp.IRepositories;
using ReviewApp.IServices;
using ReviewApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApp.Services
{
    public class ReviewTaskService : IReviewTaskService
    {
        private readonly IReviewTaskRepository _repository;

        public ReviewTaskService(IReviewTaskRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<ReviewTask> GetReviewTaskByIdAsync(long Id)
        {
            return await _repository.GetByIdAsync(Id);
        }

        public async Task<IEnumerable<ReviewTask>> GetAllReviewTasksAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task AddReviewTaskAsync(ReviewTask task)
        {
            await _repository.AddAsync(task);
        }

        public async Task UpdateReviewTaskAsync(ReviewTask task)
        {
            await _repository.UpdateAsync(task);
        }

        public async Task DeleteReviewTaskAsync(long Id)
        {
            await _repository.DeleteAsync(Id);
        }
    }
}
