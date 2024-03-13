using Lab7.Models;
using Lab7.Services.Interfaces;

namespace Lab7.Services
{
    public class ComputerService : IComputerService
    {
        private readonly List<Computer> _computers;

        public ComputerService()
        {
            _computers = new List<Computer>
            {
                new Computer { Id = 1, Brand = "Dell", Model = "XPS 15", Processor = "Intel Core i7", RAM = 16, StorageCapacity = 512, Price = 1500 },
                new Computer { Id = 2, Brand = "HP", Model = "Pavilion", Processor = "AMD Ryzen 5", RAM = 8, StorageCapacity = 256, Price = 800 },
                new Computer { Id = 3, Brand = "Lenovo", Model = "ThinkPad", Processor = "Intel Core i5", RAM = 12, StorageCapacity = 512, Price = 1200 },
                new Computer { Id = 4, Brand = "Apple", Model = "MacBook Pro", Processor = "Apple M1", RAM = 8, StorageCapacity = 256, Price = 2000 },
                new Computer { Id = 5, Brand = "Asus", Model = "ROG Strix", Processor = "AMD Ryzen 9", RAM = 32, StorageCapacity = 1024, Price = 2500 },
                new Computer { Id = 6, Brand = "Acer", Model = "Predator Helios", Processor = "Intel Core i9", RAM = 32, StorageCapacity = 1000, Price = 2200 },
                new Computer { Id = 7, Brand = "Microsoft", Model = "Surface Laptop", Processor = "Intel Core i7", RAM = 16, StorageCapacity = 512, Price = 1800 },
                new Computer { Id = 8, Brand = "Samsung", Model = "Galaxy Book", Processor = "Intel Core i5", RAM = 16, StorageCapacity = 512, Price = 1400 },
                new Computer { Id = 9, Brand = "MSI", Model = "GS66 Stealth", Processor = "Intel Core i7", RAM = 32, StorageCapacity = 1000, Price = 2300 },
                new Computer { Id = 10, Brand = "Razer", Model = "Blade 15", Processor = "Intel Core i7", RAM = 16, StorageCapacity = 512, Price = 2000 },
            };
        }


        public async Task<List<Computer>> GetComputersAsync()
        {
            await Task.Delay(100);
            return _computers;
        }

        public async Task<Computer> GetComputerByIdAsync(int id)
        {
            await Task.Delay(100);
            return _computers.Find(computer => computer.Id == id);
        }

        public async Task AddComputerAsync(Computer computer)
        {
            await Task.Delay(100);
            computer.Id = _computers.Count + 1;
            _computers.Add(computer);
        }

        public async Task<Computer> UpdateComputerAsync(int id, Computer computer)
        {
            await Task.Delay(100);
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
            await Task.Delay(100);
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