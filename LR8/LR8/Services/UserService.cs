using LR8.Models;
using LR8.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace LR8.Services
{
    public class UserService : IUserService
    {

        private readonly IEncryptionService _encryptionService;
        private List<User> _users;

        public UserService(IEncryptionService encryptionService)
        {
            _encryptionService = encryptionService;
            _users = new List<User>();
            for (int i = 0; i < 10; i++)
            {
                var defaultUser = new User
                {
                    Id = i + 1,
                    FirstName = $"User{i + 1}",
                    LastName = $"LastName{i + 1}",
                    Email = $"user{i + 1}@example.com",
                    DateOfBirth = DateTime.Now.AddYears(-20 - i), // Пример даты рождения
                    EncryptedPassword = _encryptionService.EncryptPassword($"password{i + 1}") // Пример шифрованного пароля
                };

                _users.Add(defaultUser);
            }
        }

        public async Task<IEnumerable<User>> GetUsersAsync()
        {
            // Возвращаем список пользователей асинхронно
            return await Task.FromResult(_users);
        }

        public async Task<User> GetUserByIdAsync(int id)
        {
            // Ищем пользователя по id и возвращаем асинхронно
            return await Task.FromResult(_users.FirstOrDefault(u => u.Id == id));
        }

        public async Task<User> AddUserAsync(User user)
        {
            // Генерируем уникальный id для нового пользователя
            user.Id = _users.Any() ? _users.Max(u => u.Id) + 1 : 1;

            // Шифруем пароль
            user.EncryptedPassword = new EncryptionService().EncryptPassword(user.EncryptedPassword);

            // Добавляем пользователя в список
            _users.Add(user);

            // Возвращаем нового пользователя асинхронно
            return await Task.FromResult(user);
        }

        public async Task<User> UpdateUserAsync(int id, User user)
        {
            // Находим пользователя по id
            var existingUser = _users.FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                throw new Exception("Пользователь не найден");
            }

            // Обновляем данные пользователя
            existingUser.FirstName = user.FirstName;
            existingUser.LastName = user.LastName;
            existingUser.Email = user.Email;
            existingUser.DateOfBirth = user.DateOfBirth;

            // Возвращаем обновленного пользователя асинхронно
            return await Task.FromResult(existingUser);
        }

        public async Task<User> DeleteUserAsync(int id)
        {
            // Находим пользователя по id
            var user = _users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                throw new Exception("Пользователь не найден");
            }

            // Удаляем пользователя из списка
            _users.Remove(user);

            // Возвращаем удаленного пользователя асинхронно
            return await Task.FromResult(user);
        }

        public async Task<User?> ValidateUser(string email)
        {
            // Ищем пользователя по email
            var user = _users.FirstOrDefault(u => u.Email == email);
            if (user != null) {
                // Возвращаем пользователя асинхронно
                return await Task.FromResult(user);
            }
            return null;
        }
    }
}
