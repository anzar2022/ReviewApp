using ReviewApp.IRepositories;
using ReviewApp.IServices;
using ReviewApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository) {
            _userRepository = userRepository;
        }
        public async Task<User> CreateUser(User user)
        {
          return await _userRepository.AddAsync(user);
        }

        public async Task<bool> DeleteUser(int Id)
        {
           return await _userRepository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetAllAsync();
        }

        public Task<User> GetUserById(int Id)
        {
            return _userRepository.GetByIdAsync(Id);
        }

        public async Task<User> UpdateUser(int Id,User user)
        {
            var oldUser = await   _userRepository.GetByIdAsync(Id);
            if (oldUser !=null)
            {
                oldUser.EmailAddress = user.EmailAddress;
                oldUser.IsActive = user.IsActive;

                return await _userRepository.UpdateAsync(oldUser);
            }
            return user;
          
        }
    }
}
