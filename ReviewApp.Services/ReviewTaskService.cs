using ReviewApp.IRepositories;
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
            return await _repository.GetAllAsyncWithForeignKey();
        }

        public async Task AddReviewTaskAsync(ReviewTask task)
        {
            await _repository.AddAsync(task);
        }

        public async Task UpdateReviewTaskAsync(long  Id , ReviewTask task)
        {

            var existingTask = await _repository.GetByIdAsync(Id);
            if (existingTask != null)
            {
                existingTask.EmployeeComment = task.EmployeeComment;
                existingTask.ManagerComment = task.ManagerComment;
                existingTask.TaskTitle = task.TaskTitle;
                existingTask.TaskDescription = task.TaskDescription;
                existingTask.Weightage = task.Weightage;
                existingTask.StatusId = task.StatusId;
                existingTask.EmployeeRating = task.EmployeeRating;
                existingTask.ManagerRating = task.ManagerRating;
                existingTask.PercentageComplete = task.PercentageComplete;
            }

            await _repository.UpdateAsync(existingTask);
        }

        public async Task DeleteReviewTaskAsync(long Id)
        {
            await _repository.DeleteAsync(Id);
        }

        public Task<int> GetWeightageSumByQuarterIdAsync(int quarterId)
        {
            return _repository.GetWeightageSumByQuarterIdAsync(quarterId);
        }

        public async Task<ReviewTask> UpdateReviewTaskStartDateAsync(long Id , DateOnly TaskStartDate)
        {
            var oldTask  = await _repository.GetByIdAsync(Id);
            if (oldTask != null)
            {
                oldTask.TaskStartDate =  TaskStartDate;
                await _repository.UpdateAsync(oldTask);
            }

            return oldTask;


        }

    }
}
