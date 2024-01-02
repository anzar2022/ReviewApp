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

        

        //public UserRepository(DbContext context) : base(context)
        //{
        //}

        //public UserRepository(ReviewAppDbContext context) : base(context)
        //{
        //}

        //public async Task<User> GetUserLogin(string emailAddress, string password)
        //{
        //    return await _context.Set<User>()
        //               .FirstOrDefaultAsync(u => u.EmailAddress == emailAddress && u.Password == password);
        //}
        public async Task<User> GetUserLogin(string emailAddress, string password)
        {
            return await _context.Set<User>()
                                .FirstOrDefaultAsync(u => u.EmailAddress == emailAddress && u.Password == password);
        }
        public async Task<User> GetUserByRefreshTokenAsync(string refreshToken)
        {
            return await _context.Set<User>().FirstOrDefaultAsync(u => u.RefreshToken == refreshToken);
        }
    }
}