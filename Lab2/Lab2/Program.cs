using System;
using System.Threading;
using System.Threading.Tasks;

namespace Lab2
{
    class Program
    {
        static void Main()
        {
            // Working with the Thread class
            ThreadDemo();

            // Working with Async-Await
            AsyncAwaitDemo();

            Console.ReadLine();
        }

        static void ThreadDemo()
        {
            Console.WriteLine("Working with the Thread class:");

            // Creating and starting a thread for generating, sorting, and processing an array
            Thread thread = new Thread(GenerateSortAndProcessArray);
            thread.Start();

            // Performing some actions in the main thread
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"Main thread: {i}");
                Thread.Sleep(100);
            }

            // Waiting for the thread to complete
            thread.Join();

            Console.WriteLine("Thread class work completed.");
            Console.WriteLine();
        }

        static void GenerateSortAndProcessArray()
        {
            Console.WriteLine("Generating, sorting, and processing an array:");

            // Generating a large array of numbers
            Random random = new Random();
            int[] array = new int[1000];
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 10000);
            }

            // Sorting the array
            Array.Sort(array);

            // Calculating the sum and average of the array
            int sum = 0;
            foreach (var item in array)
            {
                sum += item;
            }
            double average = sum / array.Length;

            Console.WriteLine($"Array sum: {sum}");
            Console.WriteLine($"Array average: {average}");

            // Displaying a message for even numbers
            Console.WriteLine("Even numbers in the array:");
            foreach (var item in array)
            {
                if (item % 2 == 0)
                {
                    Console.Write($"{item} ");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Generation, sorting, and processing of the array completed.");
        }

        static async void AsyncAwaitDemo()
        {
            Console.WriteLine("Working with Async-Await:");

            // Calling an asynchronous method
            await DoAsyncTask();

            Console.WriteLine("Async-Await work completed.");
        }

        static async Task DoAsyncTask()
        {
            Console.WriteLine("Start of an asynchronous task.");

            // Simulating data retrieval from a remote server
            string data = await GetDataFromRemoteServer();

            // Processing the received data
            ProcessData(data);

            Console.WriteLine("Completion of the asynchronous task.");
        }

        static async Task<string> GetDataFromRemoteServer()
        {
            Console.WriteLine("Getting data from a remote server (asynchronously)...");
            await Task.Delay(3000); // Simulating a delay in data retrieval
            return "Data received from the remote server.";
        }

        static void ProcessData(string data)
        {
            Console.WriteLine($"Processing the received data: {data}");
        }
    }
}