using ReviewApp.DTO;
using ReviewApp.IRepositories;
using ReviewApp.IServices;
using ReviewApp.Model;
using System.Linq.Expressions;

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

        public async Task AddReviewTaskAsync(CreateReviewTaskDto taskDto)
        {

            var reviewTask = new ReviewTask()
            {
                EmployeeComment = taskDto.EmployeeComment,
                EmployeeRating = taskDto.EmployeeRating,
                IsTaskCompleteDate = taskDto.IsTaskCompleteDate,
                IsTaskStartDate = taskDto.IsTaskStartDate,
                ManagerComment = taskDto.ManagerComment,
                ManagerRating = taskDto.ManagerRating,
                PercentageComplete = taskDto.PercentageComplete,
                QuarterId = taskDto.QuarterId,
                StatusId = taskDto.StatusId,
                TaskDescription = taskDto.TaskDescription,
                TaskCompleteDate = taskDto.TaskCompleteDate,
                TaskStartDate = taskDto.TaskStartDate,
                TaskTitle = taskDto.TaskTitle,
                UserId = taskDto.UserId,
                Weightage = taskDto.Weightage,




            };

            await _repository.AddAsync(reviewTask);
        }

        public async Task UpdateReviewTaskAsync(long Id, UpdateReviewTaskDto taskDto)
        {

            var existingTask = await _repository.GetByIdAsync(Id);
            if (existingTask != null)
            {
                existingTask.EmployeeComment = taskDto.EmployeeComment;
                existingTask.ManagerComment = taskDto.ManagerComment;
                existingTask.TaskTitle = taskDto.TaskTitle;
                existingTask.TaskDescription = taskDto.TaskDescription;
                existingTask.Weightage = taskDto.Weightage;
                existingTask.StatusId = taskDto.StatusId;
                existingTask.EmployeeRating = taskDto.EmployeeRating;
                existingTask.ManagerRating = taskDto.ManagerRating;
                existingTask.PercentageComplete = taskDto.PercentageComplete;
                existingTask.StatusId = taskDto.StatusId;
                existingTask.UserId = taskDto.UserId;
                existingTask.QuarterId = taskDto.QuarterId;


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

        public async Task<ReviewTask> UpdateReviewTaskStartDateAsync(long Id, DateOnly TaskStartDate)
        {
            var oldTask = await _repository.GetByIdAsync(Id);
            if (oldTask != null)
            {
                oldTask.TaskStartDate = TaskStartDate;
                oldTask.IsTaskStartDate = true;
                oldTask = await _repository.UpdateAsync(oldTask);
            }

            return oldTask;


        }
        public async Task<ReviewTask> UpdateReviewTaskCompleteDateAsync(long Id, DateOnly TaskCompleteDate)
        {
            var oldTask = await _repository.GetByIdAsync(Id);
            if (oldTask != null)
            {
                oldTask.TaskCompleteDate = TaskCompleteDate;
                oldTask.IsTaskCompleteDate = true;
                await _repository.UpdateAsync(oldTask);
            }
            return oldTask;
        }
        public async Task<ReviewTask> UpdateReviewTaskCancelAsync(long Id)
        {
            var oldTask = await _repository.GetByIdAsync(Id);
            if (oldTask != null)
            {
                oldTask.TaskCompleteDate = DateOnly.MinValue;
                oldTask.IsTaskCompleteDate = false;
                oldTask.TaskStartDate = DateOnly.MinValue;
                oldTask.IsTaskStartDate = false;
                await _repository.UpdateAsync(oldTask);
            }
            else
            {
                return null;
            }
            return oldTask;
        }

        public Task<IEnumerable<ReviewTask>> GetReviewTasksByUserIdAsync(long userId)
        {
            Expression<Func<ReviewTask, bool>> filterExpression = entity => entity.UserId == userId;

            var reviewTasks = _repository.FilterAsync(filterExpression);

            return reviewTasks;
        }
    }
}
