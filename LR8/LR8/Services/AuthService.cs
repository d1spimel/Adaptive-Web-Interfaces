using LR8.Models;
using LR8.Services.Interfaces;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;


namespace LR8.Services
{
    public class AuthService
    {
        private readonly IUserService _userService;
        private readonly IEncryptionService _passwordService;

        public AuthService(IUserService userService, IEncryptionService passwordService)
        {
            _userService = userService;
            _passwordService = passwordService;
        }

        public async Task<User> RegisterUser(User user)
        {
            var existingUser = await _userService.ValidateUser(user.Email);
            if (existingUser != null)
            {
                throw new Exception("User with this email already exists!");
            }

            // Установка id нового пользователя
            var users = await _userService.GetUsersAsync();
            user.Id = users.Any() ? users.Max(u => u.Id) + 1 : 1;

            // Хеширование пароля перед сохранением
            user.EncryptedPassword = _passwordService.EncryptPassword(user.EncryptedPassword);

            // Добавление пользователя
            return await _userService.AddUserAsync(user);
        }

        public async Task<string> LoginUser(string email, string password)
        {
            var existingUser = await _userService.ValidateUser(email);
            if (existingUser == null)
            {
                return "Invalid Email";
            }

            if (_passwordService.ConfirmPassword(password, existingUser.EncryptedPassword))
            {
                // В случае успешной аутентификации генерируем JWT токен
                var token = GenerateJwtToken(existingUser);
                return token;
            }

            // Обновление даты последней неудачной попытки входа и количества неудачных попыток
            existingUser.LastLoginDate = DateTime.Now;
            existingUser.FailedLoginAttempts++;

            return "Password is incorrect! Please try again";
        }

        private string GenerateJwtToken(User user)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, user.Email),
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("ThisIsASuperSecretKeyForJWTTokenGeneration"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "MyAppIssuer",
                audience: "MyAppAudience",
                claims: claims,
                expires: DateTime.Now.AddDays(60),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
