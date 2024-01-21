using System;
using System.IO;

namespace Lab1
{
    class Program
    {
        static string loremIpsumText; // Змінна в якої буде міститися зміст файлу.

        static void Main()
        {
            LoadLoremIpsumText();
            Menu();
        }

        static void Menu()
        {
            while (true)
            {
                Console.WriteLine("Оберіть дію:");
                Console.WriteLine("1. Вивести кількість слів у тексті 'Lorem ipsum'");
                Console.WriteLine("2. Виконати математичну операцію");
                Console.WriteLine("3. Вихід");

                int choice;
                if (int.TryParse(Console.ReadLine(), out choice))
                {
                    switch (choice)
                    {
                        case 1:
                            DisplayWordCount();
                            break;
                        case 2:
                            PerformMathOperation();
                            break;
                        case 3:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Неправильний вибір. Будь ласка, виберіть знову.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Невірний формат вводу. Будь ласка, введіть ціле число.");
                }

                Console.WriteLine();
            }
        }

        static void LoadLoremIpsumText()
        {
            try
            {
                loremIpsumText = File.ReadAllText("LoremIpsum.txt"); // Читаємо вміст файлу.
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Помилка: Файл 'LoremIpsum.txt' не знайдено."); // Обробка помилки, коли файл не знайдено.
                Environment.Exit(1);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при зчитуванні файлу: {ex.Message}"); // Обробка помилки, коли файл не вдалося зчитатию
                Environment.Exit(1);
            }
        }

        static void DisplayWordCount()
        {
            int wordCount = loremIpsumText.Split(new char[] { ' ', '\n', '\r', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            Console.WriteLine($"Кількість слів у тексті 'Lorem ipsum': {wordCount}");
        }

        static void PerformMathOperation()
        {
            Console.WriteLine("Введіть математичний вираз:");
            string expression = Console.ReadLine();

            try
            {
                double result = EvaluateMathExpression(expression);
                Console.WriteLine($"Результат: {result}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка обчислення: {ex.Message}");
            }
        }

        static double EvaluateMathExpression(string expression)
        {
            return Convert.ToDouble(new System.Data.DataTable().Compute(expression, ""));
        }
    }
}