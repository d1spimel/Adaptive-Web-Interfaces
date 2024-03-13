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
            _devices = new List<Device>
            {
                new Device { Id = 1, Name = "Smartphone", Type = "Mobile", Description = "Smartphone with latest features", Price = 800 },
                new Device { Id = 2, Name = "Laptop", Type = "Portable", Description = "Powerful laptop for work and entertainment", Price = 1200 },
                new Device { Id = 3, Name = "Desktop Computer", Type = "Desktop", Description = "High-performance desktop computer", Price = 1500 },
                new Device { Id = 4, Name = "Tablet", Type = "Mobile", Description = "Versatile tablet for productivity and entertainment", Price = 600 },
                new Device { Id = 5, Name = "Smartwatch", Type = "Wearable", Description = "Feature-rich smartwatch for fitness and communication", Price = 300 },
                new Device { Id = 6, Name = "Gaming Console", Type = "Entertainment", Description = "Next-generation gaming console for immersive gaming experiences", Price = 500 },
                new Device { Id = 7, Name = "Wireless Headphones", Type = "Audio", Description = "High-quality wireless headphones for superior audio experience", Price = 200 },
                new Device { Id = 8, Name = "Digital Camera", Type = "Photography", Description = "Professional digital camera for capturing stunning images", Price = 1500 },
                new Device { Id = 9, Name = "External Hard Drive", Type = "Storage", Description = "Large-capacity external hard drive for data backup and storage", Price = 100 },
                new Device { Id = 10, Name = "Fitness Tracker", Type = "Wearable", Description = "Fitness tracker to monitor physical activity and health metrics", Price = 100 },
            };
        }

        public async Task<List<Device>> GetDevicesAsync()
        {
            await Task.Delay(100);
            return _devices;
        }

        public async Task<Device> GetDeviceByIdAsync(int id)
        {
            await Task.Delay(100);
            return _devices.Find(device => device.Id == id);
        }

        public async Task AddDeviceAsync(Device device)
        {
            await Task.Delay(100);
            device.Id = _devices.Count + 1;
            _devices.Add(device);
        }

        public async Task<Device> UpdateDeviceAsync(int id, Device device)
        {
            await Task.Delay(100);
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
            await Task.Delay(100);
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
