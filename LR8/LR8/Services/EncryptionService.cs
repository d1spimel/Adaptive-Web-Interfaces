using LR8.Models;
using LR8.Services.Interfaces;
using System.Security.Cryptography;
using System.Text;

namespace LR8.Services
{
    public class EncryptionService : IEncryptionService
    {
        public string EncryptPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(password);

                byte[] hashBytes = sha256.ComputeHash(bytes);

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    builder.Append(hashBytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        public bool ConfirmPassword(string password, string encryptPassword)
        {
            return EncryptPassword(password) == encryptPassword;
        }
    }
}
