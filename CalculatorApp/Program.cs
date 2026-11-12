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
                Console.Write("Оберіть потрібну дію (0-4): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": CalculateBasic("+"); break;
                    case "2": CalculateBasic("-"); break;
                    case "3": CalculateBasic("*"); break;
                    case "4": CalculateBasic("/"); break;
                    case "0":
                        isRunning = false;
                        Console.WriteLine("\nЗавершення роботи. До побачення!");
                        break;
                    default:
                        Console.WriteLine("\nНевірна команда! Спробуйте ще раз.");
                        WaitKey();
                        break;
                }
            }
        }

        static void CalculateBasic(string op)
        {
            Console.WriteLine($"\n--- Операція: {op} ---");
            double a = ReadNumber("Введіть перше число: ");
            double b = ReadNumber("Введіть друге число: ");
            double res = 0;

            if (op == "+") res = a + b;
            else if (op == "-") res = a - b;
            else if (op == "*") res = a * b;
            else if (op == "/")
            {
                if (b == 0)
                {
                    Console.WriteLine("Помилка: на нуль ділити не можна!");
                    WaitKey();
                    return;
                }
                res = a / b;
            }

            Console.WriteLine($"Результат: {res}");
            WaitKey();
        }

        static double ReadNumber(string message)
        {
            while (true)
            {
                Console.Write(message);
                string input = Console.ReadLine()?.Replace(',', '.');
                if (double.TryParse(input, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out double value))
                {
                    return value;
                }
                Console.WriteLine("Некоректний формат числа! Спробуйте ще раз.");
            }
        }

        static void WaitKey()
        {
            Console.WriteLine("\nНатисніть будь-яку клавішу для продовження...");
            Console.ReadKey();
        }
    }
}