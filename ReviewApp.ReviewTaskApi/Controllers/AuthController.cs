using Microsoft.AspNetCore.Mvc;
using ReviewApp.DTO;
using ReviewApp.IServices;

namespace ReviewApp.ReviewTaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUserService _userService;

        public AuthController(IAuthService authService, IUserService userService)
        {
            _authService = authService;
            _userService = userService;
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDto loginDto)
        {
            // var user = new User();
            var user = await _userService.GetUserLogin(loginDto);
            if (user == null)
            {
                return Unauthorized(); // Invalid credentials
            }
            var (accessToken, refreshToken) = await _authService.GenerateJwtToken(loginDto.EmailAddress, user.UserId);

            return Ok(new
            {
                AccessToken = accessToken,
                RefreshToken = refreshToken,
                User = user,
            });


        }
        [HttpPost("refresh-token")]
        public async Task<ActionResult> RefreshToken(RefreshTokenDto refreshTokenDto)
        {
            var (accessToken, newRefreshToken, user) = await _authService.RefreshAccessTokenAsync(refreshTokenDto.RefreshToken);

            if (accessToken == null || newRefreshToken == null)
            {
                return Unauthorized(); // Invalid or expired refresh token
            }

            return Ok(new
            {
                AccessToken = accessToken,
                RefreshToken = newRefreshToken,
                User = user,
            });
        }
    }
}
