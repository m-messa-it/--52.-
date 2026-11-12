using System;

namespace CalculatorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("        ПРОГРАМА «КАЛЬКУЛЯТОР»");
                Console.WriteLine("     Практична робота №52 (Варіант 2)");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Додавання (+)");
                Console.WriteLine("2. Віднімання (-)");
                Console.WriteLine("3. Множення (*)");
                Console.WriteLine("4. Ділення (/)");
                Console.WriteLine("0. Вихід з програми");
                Console.WriteLine("----------------------------------------");
                Console.Write("Оберіть потрібну дію: ");

                string choice = Console.ReadLine();
                if (choice == "0")
                {
                    isRunning = false;
                    Console.WriteLine("\nЗавершення роботи. До побачення!");
                }
                else
                {
                    Console.WriteLine("\nОбробка операції...");
                    Console.ReadKey();
                }
            }
        }
    }
}