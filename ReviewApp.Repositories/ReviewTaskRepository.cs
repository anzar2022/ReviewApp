using Microsoft.EntityFrameworkCore;
using ReviewApp.Data;
using ReviewApp.IRepositories;
using ReviewApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApp.Repositories
{
    public class ReviewTaskRepository : Repository<ReviewTask>, IReviewTaskRepository
    {
        public ReviewTaskRepository(ReviewAppDbContext context) : base(context)
        {
            // Additional configurations if needed
        }

        public async Task<IEnumerable<ReviewTask>> GetAllAsyncWithQuarter()
        {
            return await _context.Set<ReviewTask>().Include(rt => rt.Quarter).ToListAsync();
          
        }

        public async Task<IEnumerable<ReviewTask>> GetAllAsyncWithForeignKey()
        {
            return await _context.Set<ReviewTask>().Include(rt => rt.Quarter).Include(rt => rt.Status).ToListAsync();

        }


    }
}
