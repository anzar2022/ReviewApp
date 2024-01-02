using ReviewApp.DTO;
using ReviewApp.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApp.IServices
{
    public  interface IAuthService
    {
        Task<(string AccessToken, string RefreshToken)> GenerateJwtToken(string EmailAddress, int UserId);
        Task<(string AccessToken, string RefreshToken, User user)> RefreshAccessTokenAsync(string refreshToken);
    }
}
