using Lab7.Models;
using Lab7.Services.Interfaces;
using Microsoft.Extensions.FileSystemGlobbing;

namespace Lab7.Services
{
    public class DeviceService : IDeviceService
    {
        private readonly List<Device> _devices;

        public DeviceService()
        {
            // Пример инициализации списка девайсов
            _devices = new List<Device>
            {
                new Device { Id = 1, Name = "Smartphone", Type = "Mobile", Description = "Smartphone with latest features", Price = 800 },
                new Device { Id = 2, Name = "Laptop", Type = "Portable", Description = "Powerful laptop for work and entertainment", Price = 1200 },
                // Добавьте здесь остальные девайсы
            };
        }

        public async Task<List<Device>> GetDevicesAsync()
        {
            // Можно добавить логику для доступа к данным из базы данных или другого источника
            await Task.Delay(100); // Просто для имитации задержки
            return _devices;
        }

        public async Task<Device> GetDeviceByIdAsync(int id)
        {
            // Можно добавить логику для доступа к данным из базы данных или другого источника
            await Task.Delay(100); // Просто для имитации задержки
            return _devices.Find(device => device.Id == id);
        }

        public async Task AddDeviceAsync(Device device)
        {
            // Можно добавить логику для добавления девайса в базу данных или другое хранилище
            await Task.Delay(100); // Просто для имитации задержки
            device.Id = _devices.Count + 1;
            _devices.Add(device);
        }

        public async Task<Device> UpdateDeviceAsync(int id, Device device)
        {
            // Можно добавить логику для обновления девайса в базе данных или другом хранилище
            await Task.Delay(100); // Просто для имитации задержки
            var existingDevice = _devices.Find(d => d.Id == id);
            if (existingDevice != null)
            {
                existingDevice.Name = device.Name;
                existingDevice.Type = device.Type;
                existingDevice.Description = device.Description;
                existingDevice.Price = device.Price;
                return existingDevice;
            }
            return null;
        }

        public async Task<Device> DeleteDeviceAsync(int id)
        {
            // Можно добавить логику для удаления девайса из базы данных или другого хранилища
            await Task.Delay(100); // Просто для имитации задержки
            var existingDevice = _devices.Find(d => d.Id == id);
            if (existingDevice != null)
            {
                _devices.Remove(existingDevice);
                return existingDevice;
            }
            return null;
        }
    }
}
