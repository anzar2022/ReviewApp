﻿using ReviewApp.Model;

namespace ReviewApp.IRepositories
{
    public interface IReviewTaskRepository : IRepository<ReviewTask>
    {
        // Define specific methods for ReviewTask if needed
        // For example:
        // Task<ReviewTask> GetTaskByStatusAsync(int status);

        Task<IEnumerable<ReviewTask>> GetAllAsyncWithQuarter();
        Task<IEnumerable<ReviewTask>> GetAllAsyncWithForeignKey();

        Task<int> GetWeightageSumByQuarterIdAsync(int quarterId);
    }
}
