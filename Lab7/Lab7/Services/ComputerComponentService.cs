using Lab7.Models;
using Lab7.Services.Interfaces;

namespace Lab7.Services
{
    public class ComputerComponentService : IComputerComponentService
    {
        private readonly List<ComputerComponent> _computerComponents;

        public ComputerComponentService()
        {
            // Пример инициализации списка комплектующих ПК
            _computerComponents = new List<ComputerComponent>
            {
                new ComputerComponent { Id = 1, Brand = "Intel", Model = "Core i5", Processor = "Central Processing Unit", RAM = 8, StorageCapacity = 256, Price = 150 },
                new ComputerComponent { Id = 2, Brand = "Nvidia", Model = "GeForce RTX 3080", Processor = "Graphics Processing Unit", RAM = 0, StorageCapacity = 0, Price = 300 },
                new ComputerComponent { Id = 3, Brand = "Corsair", Model = "Vengeance LPX", Processor = "Random Access Memory", RAM = 16, StorageCapacity = 0, Price = 80 },
                // Добавьте здесь остальные комплектующие ПК
            };
        }

        public async Task<List<ComputerComponent>> GetComputerComponentsAsync()
        {
            // Можно добавить логику для доступа к данным из базы данных или другого источника
            await Task.Delay(100); // Просто для имитации задержки
            return _computerComponents;
        }

        public async Task<ComputerComponent> GetComputerComponentByIdAsync(int id)
        {
            // Можно добавить логику для доступа к данным из базы данных или другого источника
            await Task.Delay(100); // Просто для имитации задержки
            return _computerComponents.Find(component => component.Id == id);
        }

        public async Task AddComputerComponentAsync(ComputerComponent computerComponent)
        {
            // Можно добавить логику для добавления компонента в базу данных или другое хранилище
            await Task.Delay(100); // Просто для имитации задержки
            computerComponent.Id = _computerComponents.Count + 1;
            _computerComponents.Add(computerComponent);
        }

        public async Task<ComputerComponent> UpdateComputerComponentAsync(int id, ComputerComponent computerComponent)
        {
            // Можно добавить логику для обновления компонента в базе данных или другом хранилище
            await Task.Delay(100); // Просто для имитации задержки
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
            // Можно добавить логику для удаления компонента из базы данных или другого хранилища
            await Task.Delay(100); // Просто для имитации задержки
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
