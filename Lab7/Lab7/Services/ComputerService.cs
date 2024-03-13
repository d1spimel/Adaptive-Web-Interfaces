using Lab7.Models;
using Lab7.Services.Interfaces;

namespace Lab7.Services
{
    public class ComputerService : IComputerService
    {
        private readonly List<Computer> _computers;

        public ComputerService()
        {
            // Пример инициализации списка компьютеров
            _computers = new List<Computer>
            {
                new Computer { Id = 1, Brand = "Dell", Model = "XPS 15", Processor = "Intel Core i7", RAM = 16, StorageCapacity = 512, Price = 1500 },
                new Computer { Id = 2, Brand = "HP", Model = "Pavilion", Processor = "AMD Ryzen 5", RAM = 8, StorageCapacity = 256, Price = 800 },
                // Добавьте здесь остальные компьютеры
            };
        }

        public async Task<List<Computer>> GetComputersAsync()
        {
            // Можно добавить логику для доступа к данным из базы данных или другого источника
            await Task.Delay(100); // Просто для имитации задержки
            return _computers;
        }

        public async Task<Computer> GetComputerByIdAsync(int id)
        {
            // Можно добавить логику для доступа к данным из базы данных или другого источника
            await Task.Delay(100); // Просто для имитации задержки
            return _computers.Find(computer => computer.Id == id);
        }

        public async Task AddComputerAsync(Computer computer)
        {
            // Можно добавить логику для добавления компьютера в базу данных или другое хранилище
            await Task.Delay(100); // Просто для имитации задержки
            computer.Id = _computers.Count + 1;
            _computers.Add(computer);
        }

        public async Task<Computer> UpdateComputerAsync(int id, Computer computer)
        {
            // Можно добавить логику для обновления компьютера в базе данных или другом хранилище
            await Task.Delay(100); // Просто для имитации задержки
            var existingComputer = _computers.Find(c => c.Id == id);
            if (existingComputer != null)
            {
                existingComputer.Brand = computer.Brand;
                existingComputer.Model = computer.Model;
                existingComputer.Processor = computer.Processor;
                existingComputer.RAM = computer.RAM;
                existingComputer.StorageCapacity = computer.StorageCapacity;
                existingComputer.Price = computer.Price;
                return existingComputer;
            }
            return null;
        }

        public async Task<Computer> DeleteComputerAsync(int id)
        {
            // Можно добавить логику для удаления компьютера из базы данных или другого хранилища
            await Task.Delay(100); // Просто для имитации задержки
            var existingComputer = _computers.Find(c => c.Id == id);
            if (existingComputer != null)
            {
                _computers.Remove(existingComputer);
                return existingComputer;
            }
            return null;
        }
    }
}