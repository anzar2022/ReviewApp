using Microsoft.EntityFrameworkCore;
using ReviewApp.Data;
using ReviewApp.IRepositories;
using ReviewApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace ReviewApp.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ReviewAppDbContext context) : base(context)
        {
        }
    }
}