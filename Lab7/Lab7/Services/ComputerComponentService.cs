using Lab7.Models;
using Lab7.Services.Interfaces;

namespace Lab7.Services
{
    public class ComputerComponentService : IComputerComponentService
    {
        private readonly List<ComputerComponent> _computerComponents;

        public ComputerComponentService()
        {
            _computerComponents = new List<ComputerComponent>
            {
                new ComputerComponent { Id = 1, Brand = "Intel", Model = "Core i5", Processor = "Central Processing Unit", RAM = 8, StorageCapacity = 256, Price = 150 },
                new ComputerComponent { Id = 2, Brand = "Nvidia", Model = "GeForce RTX 3080", Processor = "Graphics Processing Unit", RAM = 0, StorageCapacity = 0, Price = 300 },
                new ComputerComponent { Id = 3, Brand = "Corsair", Model = "Vengeance LPX", Processor = "Random Access Memory", RAM = 16, StorageCapacity = 0, Price = 80 },
                new ComputerComponent { Id = 4, Brand = "Samsung", Model = "970 EVO Plus", Processor = "Solid State Drive", RAM = 0, StorageCapacity = 512, Price = 100 },
                new ComputerComponent { Id = 5, Brand = "Seagate", Model = "BarraCuda", Processor = "Hard Disk Drive", RAM = 0, StorageCapacity = 2000, Price = 80 },
                new ComputerComponent { Id = 6, Brand = "Asus", Model = "ROG Strix X570-E", Processor = "Motherboard", RAM = 0, StorageCapacity = 0, Price = 250 },
                new ComputerComponent { Id = 7, Brand = "Cooler Master", Model = "Hyper 212 RGB", Processor = "CPU Cooler", RAM = 0, StorageCapacity = 0, Price = 50 },
                new ComputerComponent { Id = 8, Brand = "EVGA", Model = "SuperNOVA 850 G5", Processor = "Power Supply Unit", RAM = 0, StorageCapacity = 0, Price = 150 },
                new ComputerComponent { Id = 9, Brand = "Logitech", Model = "G502 Hero", Processor = "Gaming Mouse", RAM = 0, StorageCapacity = 0, Price = 60 },
                new ComputerComponent { Id = 10, Brand = "Razer", Model = "BlackWidow Elite", Processor = "Gaming Keyboard", RAM = 0, StorageCapacity = 0, Price = 120 },
            };
        }

        public async Task<List<ComputerComponent>> GetComputerComponentsAsync()
        {
            await Task.Delay(100);
            return _computerComponents;
        }

        public async Task<ComputerComponent> GetComputerComponentByIdAsync(int id)
        {
            await Task.Delay(100);
            return _computerComponents.Find(component => component.Id == id);
        }

        public async Task AddComputerComponentAsync(ComputerComponent computerComponent)
        {
            await Task.Delay(100);
            computerComponent.Id = _computerComponents.Count + 1;
            _computerComponents.Add(computerComponent);
        }

        public async Task<ComputerComponent> UpdateComputerComponentAsync(int id, ComputerComponent computerComponent)
        {
            await Task.Delay(100);
            var existingComponent = _computerComponents.Find(component => component.Id == id);
            if (existingComponent != null)
            {
                existingComponent.Id = computerComponent.Id;
                existingComponent.Brand = computerComponent.Brand;
                existingComponent.Model = computerComponent.Model;
                existingComponent.Processor = computerComponent.Processor;
                existingComponent.RAM = computerComponent.RAM;
                existingComponent.StorageCapacity = computerComponent.StorageCapacity;
                existingComponent.Price = computerComponent.Price;
                return existingComponent;
            }
            return null;
        }

        public async Task<ComputerComponent> DeleteComputerComponentAsync(int id)
        {
            await Task.Delay(100);
            var existingComponent = _computerComponents.Find(component => component.Id == id);
            if (existingComponent != null)
            {
                _computerComponents.Remove(existingComponent);
                return existingComponent;
            }
            return null;
        }
    }
}
