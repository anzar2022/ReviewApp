using ReviewApp.DTO;
using ReviewApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApp.IServices
{
    public interface IReviewTaskService
    {
        Task<ReviewTask> GetReviewTaskByIdAsync(long Id);
        Task<IEnumerable<ReviewTask>> GetAllReviewTasksAsync();
        Task AddReviewTaskAsync(CreateReviewTaskDto task);
        Task UpdateReviewTaskAsync(long Id, UpdateReviewTaskDto taskDto);
        Task DeleteReviewTaskAsync(long Id);

        Task<int> GetWeightageSumByQuarterIdAsync(int quarterId);

        Task<ReviewTask> UpdateReviewTaskStartDateAsync(long Id, DateOnly TaskStartDate);

        Task<ReviewTask> UpdateReviewTaskCompleteDateAsync(long Id, DateOnly TaskCompleteDate);
        Task<ReviewTask> UpdateReviewTaskCancelAsync(long Id);
    }
}
