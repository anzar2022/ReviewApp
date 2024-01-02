using Microsoft.EntityFrameworkCore;
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
        public UserRepository(DbContext context) : base(context)
        {
        }
    }
}