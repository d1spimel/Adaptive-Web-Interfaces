using LR8.Models;

namespace LR8.Services.Interfaces
{
    public interface IVersionService
    {
        public int GetFirstVersion();
        public string GetSecondVersion();
        public byte[] GetThirdVersion();
    }
}