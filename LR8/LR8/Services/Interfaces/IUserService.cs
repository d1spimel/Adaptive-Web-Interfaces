﻿using LR8.Models;

namespace LR8.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> AddUserAsync(User user);
        Task<User> UpdateUserAsync(int id, User user);
        Task<User> DeleteUserAsync(int id);
        Task<User> ValidateUser(string email);
    }
}
