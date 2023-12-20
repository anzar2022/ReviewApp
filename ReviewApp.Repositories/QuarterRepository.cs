using Microsoft.EntityFrameworkCore;
using ReviewApp.IRepositories;
using ReviewApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApp.Repositories
{
    public class QuarterRepository : Repository<Quarter>, IQuarterRepository
    {
        public QuarterRepository(DbContext context) : base(context)
        {
            // Additional configurations if needed
        }

        // Implement specific methods for Quarter if needed
    }
}
