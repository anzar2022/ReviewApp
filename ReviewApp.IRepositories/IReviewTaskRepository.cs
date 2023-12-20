using ReviewApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApp.IRepositories
{
    public interface IReviewTaskRepository : IRepository<ReviewTask>
    {
        // Define specific methods for ReviewTask if needed
        // For example:
        // Task<ReviewTask> GetTaskByStatusAsync(int status);
    }
}
