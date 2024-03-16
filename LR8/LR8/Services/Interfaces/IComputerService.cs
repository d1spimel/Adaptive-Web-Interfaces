using LR8.Models;

namespace LR8.Services.Interfaces
{
    public interface IComputerService
    {
        Task<List<Computer>> GetComputersAsync();
        Task<Computer> GetComputerByIdAsync(int id);
        Task AddComputerAsync(Computer computer);
        Task<Computer> UpdateComputerAsync(int id, Computer computer);
        Task<Computer> DeleteComputerAsync(int id);
    }
}
