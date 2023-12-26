using ReviewApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
