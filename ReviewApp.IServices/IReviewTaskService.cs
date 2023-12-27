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
        Task AddReviewTaskAsync(ReviewTask task);
        Task UpdateReviewTaskAsync(ReviewTask task);
        Task DeleteReviewTaskAsync(long Id);

        Task<int> GetWeightageSumByQuarterIdAsync(int quarterId);

        Task<ReviewTask> UpdateReviewTaskStartDateAsync(long Id, DateOnly TaskStartDate);
    }
}
