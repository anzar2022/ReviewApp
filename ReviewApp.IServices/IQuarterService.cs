using ReviewApp.Model;

namespace ReviewApp.IServices
{
    public interface IQuarterService
    {
        Task<Quarter> GetQuarterByIdAsync(int Id);
        Task<IEnumerable<Quarter>> GetAllQuartersAsync();
        Task AddQuarterAsync(Quarter quarter);
        Task UpdateQuarterAsync(Quarter quarter);
        Task DeleteQuarterAsync(int Id);
    }
}
