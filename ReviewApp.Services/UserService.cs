using ReviewApp.DTO;
using ReviewApp.IRepositories;
using ReviewApp.IServices;
using ReviewApp.Model;

namespace ReviewApp.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> CreateUser(CreateUserDto userDto)
        {
            return await _userRepository.AddAsync(new User() { EmailAddress = userDto.EmailAddress, Password = userDto.Password, IsActive = userDto.IsActive, UserRoleId = userDto.UserRoleId });
        }

        public async Task<bool> DeleteUser(long Id)
        {
            return await _userRepository.DeleteAsync(Id);
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            return await _userRepository.GetAllAsync();
        }

        public Task<User> GetUserById(long Id)
        {
            return _userRepository.GetByIdAsync(Id);
        }

        public async Task<User> UpdateUser(long Id, UpdateUserDto userDto)
        {
            var oldUser = await _userRepository.GetByIdAsync(Id);
            if (oldUser != null)
            {
                oldUser.EmailAddress = userDto.EmailAddress;
                oldUser.IsActive = userDto.IsActive;
                oldUser.UserRoleId = userDto.UserRoleId;

                return await _userRepository.UpdateAsync(oldUser);
                return oldUser;
            }
            return null;


        }

        public async Task<User> GetUserLogin(LoginDto loginDto)
        {
            return await _userRepository.GetUserLogin(loginDto.EmailAddress, loginDto.Password);
        }
    }
}
