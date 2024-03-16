using LR8.Models;

namespace LR8.Services.Interfaces
{
    public interface IDeviceService
    {
        Task<List<Device>> GetDevicesAsync();
        Task<Device> GetDeviceByIdAsync(int id);
        Task AddDeviceAsync(Device device);
        Task<Device> UpdateDeviceAsync(int id, Device device);
        Task<Device> DeleteDeviceAsync(int id);
    }
}
