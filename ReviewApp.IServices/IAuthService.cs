using ReviewApp.Model;

namespace ReviewApp.IServices
{
    public interface IAuthService
    {
        Task<(string AccessToken, string RefreshToken)> GenerateJwtToken(string EmailAddress, long UserId);
        Task<(string AccessToken, string RefreshToken, User user)> RefreshAccessTokenAsync(string refreshToken);
    }
}
