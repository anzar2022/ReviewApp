using ReviewApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApp.IServices
{
    public interface IUserService
    {
         Task<User> CreateUser(User user);
         Task<User> UpdateUser(int Id, User user);
         Task<bool> DeleteUser(int Id);
         Task<User> GetUserById(int Id);
         Task<IEnumerable<User>> GetUsers();

    }
}
