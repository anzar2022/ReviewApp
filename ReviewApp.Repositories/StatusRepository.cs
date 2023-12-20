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
    public class StatusRepository : Repository<Status>, IStatusRepository
    {
        public StatusRepository(ReviewAppDbContext context) : base(context)
        {
            // Additional configurations if needed
        }

        // Implement specific methods for Status if needed
    }
}
