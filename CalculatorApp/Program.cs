using System;

namespace CalculatorApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;

            bool running = true;
            while (running)
            {
                Console.WriteLine("\n=== КАЛЬКУЛЯТОР ===");
                Console.WriteLine("1. Додавання (+)");
                Console.WriteLine("2. Віднімання (-)");
                Console.WriteLine("3. Множення (*)");
                Console.WriteLine("4. Ділення (/)");
                Console.WriteLine("0. Вихід");
                Console.Write("Оберіть дію: ");

                string input = Console.ReadLine();
                if (input == "0") break;

                Console.Write("Введіть перше число: ");
                double a = double.Parse(Console.ReadLine().Replace(',', '.'));

                Console.Write("Введіть друге число: ");
                double b = double.Parse(Console.ReadLine().Replace(',', '.'));

                double res = 0;
                switch (input)
                {
                    case "1": res = a + b; break;
                    case "2": res = a - b; break;
                    case "3": res = a * b; break;
                    case "4":
                        if (b == 0) { Console.WriteLine("Помилка: ділення на нуль!"); continue; }
                        res = a / b; break;
                }
                Console.WriteLine($"Результат: {res}");
            }
        }
    }
}
