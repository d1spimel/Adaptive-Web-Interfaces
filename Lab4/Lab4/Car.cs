using System;
using System.Reflection;

namespace Lab4
{
    public class Car
    {
        public string Brand { get; set; }
        private int Year { get; set; }
        protected string Model { get; set; }
        internal string Color { get; set; }
        protected internal double Price { get; set; }

        public Car(string brand, int year, string model, string color, double price)
        {
            Brand = brand;
            Year = year;
            Model = model;
            Color = color;
            Price = price;
        }

        public void Start()
        {
            Console.WriteLine($"The {Brand} {Model} has started.");
        }

        private void Accelerate()
        {
            Console.WriteLine($"The {Brand} {Model} is accelerating.");
        }

        protected internal void Brake()
        {
            Console.WriteLine($"The {Brand} {Model} is braking.");
        }

        public bool CheckPrice(double threshold)
        {
            if (Price > threshold)
            {
                Console.WriteLine($"The {Brand} {Model} is expensive.");
                return true;
            }
            else
            {
                Console.WriteLine($"The {Brand} {Model} is affordable.");
                return false;
            }
        }
    }
}
