using Lab7.Models;

namespace Lab7.Services.Interfaces
{
    public interface IComputerComponentService
    {
        Task<List<ComputerComponent>> GetComputerComponentsAsync();
        Task<ComputerComponent> GetComputerComponentByIdAsync(int id);
        Task AddComputerComponentAsync(ComputerComponent computerComponent);
        Task<ComputerComponent> UpdateComputerComponentAsync(int id, ComputerComponent computerComponent);
        Task<ComputerComponent> DeleteComputerComponentAsync(int id);
    }
}
