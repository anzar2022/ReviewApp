using ReviewApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApp.IServices
{
    public interface IStatusService
    {
        Task<Status> GetStatusByIdAsync(int id);
        Task<IEnumerable<Status>> GetAllStatusesAsync();
        Task AddStatusAsync(Status status);
        Task UpdateStatusAsync(Status status);
        Task DeleteStatusAsync(int id);
    }
}
