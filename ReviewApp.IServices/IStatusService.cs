using ReviewApp.Model;

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
