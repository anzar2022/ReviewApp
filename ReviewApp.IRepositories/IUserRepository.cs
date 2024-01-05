using ReviewApp.Model;

namespace ReviewApp.IRepositories
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetUserLogin(string emailAddress, string password);
        Task<User> GetUserByRefreshTokenAsync(string refreshToken);
    }
}
