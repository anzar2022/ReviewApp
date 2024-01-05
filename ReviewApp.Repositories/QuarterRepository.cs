using ReviewApp.Data;
using ReviewApp.IRepositories;
using ReviewApp.Model;

namespace ReviewApp.Repositories
{
    public class QuarterRepository : Repository<Quarter>, IQuarterRepository
    {
        public QuarterRepository(ReviewAppDbContext context) : base(context)
        {
            // Additional configurations if needed
        }

        // Implement specific methods for Quarter if needed
    }
}
