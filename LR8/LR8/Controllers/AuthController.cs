using LR8.Models;
using LR8.Services;
using LR8.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace LR8.Controllers
{

    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register/")]
        public async Task<IActionResult> Register(User user)
        {
            await Task.Delay(2000);
            var newUser = await _authService.RegisterUser(user);
            return Ok($"User with email: {newUser.Email} registered successfully!");
        }

        [HttpPost("login/")]
        public async Task<string> Login(AuthData authData)
        {
            await Task.Delay(2000);
            var jwt = await _authService.LoginUser(authData.Email, authData.PasswordEncrypted);
            return "Bearer token: " + jwt;
        }
    }
}
