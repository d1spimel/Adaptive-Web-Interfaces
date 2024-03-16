using System.ComponentModel.DataAnnotations;

namespace LR8.Models
{
    public class AuthData
    {
        [EmailAddress]
        public string Email { get; set; }
        public string PasswordEncrypted { get; set; }
    }
}
