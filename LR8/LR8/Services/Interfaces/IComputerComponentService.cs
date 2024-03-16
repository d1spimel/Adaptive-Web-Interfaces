using LR8.Models;

namespace LR8.Services.Interfaces
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
