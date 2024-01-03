using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ReviewApp.DTO;
using ReviewApp.IRepositories;
using ReviewApp.IServices;
using ReviewApp.Model;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ReviewApp.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;
    //    private readonly IConfiguration _configuration;
        private readonly JwtSettings _jwtSettings;
        public AuthService(IUserRepository userRepository , JwtSettings  jwtSettings ) {
            _userRepository = userRepository;
            _jwtSettings = jwtSettings;
           
        }
        public async Task<(string AccessToken, string RefreshToken)> GenerateJwtToken(string EmailAddress, long UserId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey); // Replace with your secret key

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Email, EmailAddress),
                new Claim("UserId", UserId.ToString())
                // Add more claims as needed
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpirationHours),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            // Generate a refresh token and set its expiration date
            var refreshToken = GenerateRefreshToken(); // Implement a method to generate a refresh token
            var refreshTokenExpiration = DateTime.UtcNow.AddHours(_jwtSettings.ExpirationHours); // Set the refresh token expiration

            claims.Add(new Claim("RefreshToken", refreshToken));

            var token = tokenHandler.CreateToken(tokenDescriptor);
            var generatedToken = tokenHandler.WriteToken(token);

            var user = await _userRepository.GetByIdAsync(UserId);
            var refreshTokenExpiryDate = DateTime.UtcNow.AddHours(_jwtSettings.RefreshTokenExpiryDate);
            user.RefreshTokenExpiryDate = refreshTokenExpiryDate;
            user.RefreshToken = refreshToken;

            await _userRepository.UpdateAsync(user);

            return (generatedToken, refreshToken);
        }
        public string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            using var rng = RandomNumberGenerator.Create();
            rng.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
        public async Task<(string AccessToken, string RefreshToken ,User user)> RefreshAccessTokenAsync(string refreshToken)
        {
            var user = await _userRepository.GetUserByRefreshTokenAsync(refreshToken);

            if (user == null || user.RefreshToken != refreshToken)
            {
                return (null, null, null); // Invalid refresh token
            }

            // Check if the refresh token is expired (additional logic based on your implementation)
            if (user.RefreshTokenExpiryDate <= DateTime.UtcNow)
            {
                return (null, null, null); // Refresh token expired
            }

            // Generate a new access token
            var (accessToken, newRefreshToken) = await GenerateJwtToken(user.EmailAddress, user.UserId);

            // Optionally, update the refresh token and its expiry date in the database
            user.RefreshToken = newRefreshToken;
            user.RefreshTokenExpiryDate = DateTime.UtcNow.AddHours(_jwtSettings.ExpirationHours);
            await _userRepository.UpdateAsync(user); // Update the user's refresh token in the database

            return (accessToken, newRefreshToken, user);
        }

    }
}
