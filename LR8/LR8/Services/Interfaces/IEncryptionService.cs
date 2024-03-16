using LR8.Models;

namespace LR8.Services.Interfaces
{
    public interface IEncryptionService
    {
        string EncryptPassword(string password);
        bool ConfirmPassword(string password, string encryptPassword);
    }
}
