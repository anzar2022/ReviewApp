using ReviewApp.Data;
using ReviewApp.IRepositories;
using ReviewApp.Model;

namespace ReviewApp.Repositories
{
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        public StatusRepository(ReviewAppDbContext context) : base(context)
        {
            // Additional configurations if needed
        }

        // Implement specific methods for Status if needed
    }
}
