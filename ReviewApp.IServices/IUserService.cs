using ReviewApp.DTO;
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
         Task<User> CreateUser(CreateUserDto userDto);
         Task<User> UpdateUser(long Id, User user);
         Task<bool> DeleteUser(long Id);
         Task<User> GetUserById(long Id);
         Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserLogin(LoginDto loginDto);

    }
}
