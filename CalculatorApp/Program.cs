using System;
using System.Collections.Generic;

namespace CalculatorApp
{
    internal class Program
    {
        // Змінна для збереження значення в пам'яті (MS / MR / MC)
        static double memory = 0;
        static bool hasMemory = false;

        // Список для ведення історії обчислень
        static List<string> history = new List<string>();

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
                Console.WriteLine("5. Піднесення до степеня (x^y)");
                Console.WriteLine("6. Квадратний корінь (√x)");
                Console.WriteLine("7. Робота з пам'яттю (MS, MR, MC)");
                Console.WriteLine("8. Переглянути журнал обчислень");
                Console.WriteLine("0. Вихід з програми");
                Console.WriteLine("----------------------------------------");
                if (hasMemory)
                {
                    Console.WriteLine($"[У пам'яті збережено: {memory}]");
                }
                Console.Write("Оберіть потрібну дію (0-8): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        CalculateBasic("+");
                        break;
                    case "2":
                        CalculateBasic("-");
                        break;
                    case "3":
                        CalculateBasic("*");
                        break;
                    case "4":
                        CalculateBasic("/");
                        break;
                    case "5":
                        CalculatePower();
                        break;
                    case "6":
                        CalculateSqrt();
                        break;
                    case "7":
                        ManageMemory();
                        break;
                    case "8":
                        ShowHistory();
                        break;
                    case "0":
                        isRunning = false;
                        Console.WriteLine("\nДякуємо за використання програми. До побачення!");
                        break;
                    default:
                        Console.WriteLine("\nНевірна команда! Спробуйте ще раз.");
                        WaitKey();
                        break;
                }
            }
        }

        // Базові арифметичні операції
        static void CalculateBasic(string op)
        {
            Console.WriteLine($"\n--- Операція: {op} ---");
            double a = ReadNumber("Введіть перше число: ");
            double b = ReadNumber("Введіть друге число: ");
            double res = 0;

            if (op == "+")
            {
                res = a + b;
            }
            else if (op == "-")
            {
                res = a - b;
            }
            else if (op == "*")
            {
                res = a * b;
            }
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

            string record = $"{a} {op} {b} = {res}";
            history.Add(record);
            Console.WriteLine($"Результат: {res}");

            PromptSaveToMemory(res);
            WaitKey();
        }

        // Піднесення до степеня
        static void CalculatePower()
        {
            Console.WriteLine("\n--- Піднесення до степеня ---");
            double baseNum = ReadNumber("Введіть число (основу): ");
            double exp = ReadNumber("Введіть степінь: ");

            double res = Math.Pow(baseNum, exp);
            string record = $"{baseNum} ^ {exp} = {res}";
            history.Add(record);

            Console.WriteLine($"Результат: {res}");
            PromptSaveToMemory(res);
            WaitKey();
        }

        // Квадратний корінь
        static void CalculateSqrt()
        {
            Console.WriteLine("\n--- Обчислення квадратного кореня ---");
            double num = ReadNumber("Введіть число: ");

            if (num < 0)
            {
                Console.WriteLine("Помилка: корінь з від'ємного числа не існує серед дійсних чисел!");
                WaitKey();
                return;
            }

            double res = Math.Sqrt(num);
            string record = $"√({num}) = {res}";
            history.Add(record);

            Console.WriteLine($"Результат: {res}");
            PromptSaveToMemory(res);
            WaitKey();
        }

        // Меню керування пам'яттю
        static void ManageMemory()
        {
            Console.WriteLine("\n--- Керування пам'яттю ---");
            Console.WriteLine("1. Записати число в пам'ять (MS)");
            Console.WriteLine("2. Показати число з пам'яті (MR)");
            Console.WriteLine("3. Очистити пам'ять (MC)");
            Console.Write("Виберіть дію: ");
            string subChoice = Console.ReadLine();

            if (subChoice == "1")
            {
                memory = ReadNumber("Введіть значення для збереження: ");
                hasMemory = true;
                Console.WriteLine($"Число {memory} збережено в пам'ять.");
            }
            else if (subChoice == "2")
            {
                if (hasMemory)
                    Console.WriteLine($"Значення в пам'яті: {memory}");
                else
                    Console.WriteLine("Пам'ять порожня.");
            }
            else if (subChoice == "3")
            {
                memory = 0;
                hasMemory = false;
                Console.WriteLine("Пам'ять очищено.");
            }
            else
            {
                Console.WriteLine("Невірний вибір.");
            }
            WaitKey();
        }

        // Запит на швидке збереження в пам'ять після розрахунку
        static void PromptSaveToMemory(double value)
        {
            Console.Write("Зберегти цей результат у пам'ять? (т/н): ");
            string ans = Console.ReadLine()?.Trim().ToLower();
            if (ans == "т" || ans == "y" || ans == "так" || ans == "yes")
            {
                memory = value;
                hasMemory = true;
                Console.WriteLine($"Результат {value} збережено в пам'ять.");
            }
        }

        // Перегляд журналу історії
        static void ShowHistory()
        {
            Console.WriteLine("\n=== Журнал останніх обчислень ===");
            if (history.Count == 0)
            {
                Console.WriteLine("Журнал порожній. Ви ще не виконували операцій.");
            }
            else
            {
                for (int i = 0; i < history.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {history[i]}");
                }
            }
            WaitKey();
        }

        // Допоміжна функція безпечного зчитування чисел
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
