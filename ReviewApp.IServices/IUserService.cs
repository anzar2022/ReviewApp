using ReviewApp.DTO;
using ReviewApp.Model;

namespace ReviewApp.IServices
{
    public interface IUserService
    {
        Task<User> CreateUser(CreateUserDto userDto);
        Task<User> UpdateUser(long Id, UpdateUserDto user);
        Task<bool> DeleteUser(long Id);
        Task<User> GetUserById(long Id);
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserLogin(LoginDto loginDto);

    }
}
