using System;
using System.Collections.Generic;

namespace CalculatorApp
{
    internal class Program
    {
        // Р вЂ”Р СРЎвЂ“Р Р…Р Р…Р В° Р Т‘Р В»РЎРЏ Р В·Р В±Р ВµРЎР‚Р ВµР В¶Р ВµР Р…Р Р…РЎРЏ Р В·Р Р…Р В°РЎвЂЎР ВµР Р…Р Р…РЎРЏ Р Р† Р С—Р В°Р С'РЎРЏРЎвЂљРЎвЂ“ (MS / MR / MC)
        static double memory = 0;
        static bool hasMemory = false;

        // Р РЋР С—Р С‘РЎРѓР С•Р С” Р Т‘Р В»РЎРЏ Р Р†Р ВµР Т‘Р ВµР Р…Р Р…РЎРЏ РЎвЂ“РЎРѓРЎвЂљР С•РЎР‚РЎвЂ“РЎвЂ” Р С•Р В±РЎвЂЎР С‘РЎРѓР В»Р ВµР Р…РЎРЉ
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
                Console.WriteLine("        Р СџР В Р С›Р вЂњР В Р С’Р СљР С’ Р’В«Р С™Р С’Р вЂєР В¬Р С™Р Р€Р вЂєР Р‡Р СћР С›Р В Р’В»");
                Console.WriteLine("     Р СџРЎР‚Р В°Р С”РЎвЂљР С‘РЎвЂЎР Р…Р В° РЎР‚Р С•Р В±Р С•РЎвЂљР В° РІвЂћвЂ“52 (Р вЂ™Р В°РЎР‚РЎвЂ“Р В°Р Р…РЎвЂљ 2)");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Р вЂќР С•Р Т‘Р В°Р Р†Р В°Р Р…Р Р…РЎРЏ (+)");
                Console.WriteLine("2. Р вЂ™РЎвЂ“Р Т‘Р Р…РЎвЂ“Р СР В°Р Р…Р Р…РЎРЏ (-)");
                Console.WriteLine("3. Р СљР Р…Р С•Р В¶Р ВµР Р…Р Р…РЎРЏ (*)");
                Console.WriteLine("4. Р вЂќРЎвЂ“Р В»Р ВµР Р…Р Р…РЎРЏ (/)");
                Console.WriteLine("5. Р СџРЎвЂ“Р Т‘Р Р…Р ВµРЎРѓР ВµР Р…Р Р…РЎРЏ Р Т‘Р С• РЎРѓРЎвЂљР ВµР С—Р ВµР Р…РЎРЏ (x^y)");
                Console.WriteLine("6. Р С™Р Р†Р В°Р Т‘РЎР‚Р В°РЎвЂљР Р…Р С‘Р в„– Р С”Р С•РЎР‚РЎвЂ“Р Р…РЎРЉ (РІв‚¬С™x)");
                Console.WriteLine("7. Р В Р С•Р В±Р С•РЎвЂљР В° Р В· Р С—Р В°Р С'РЎРЏРЎвЂљРЎвЂљРЎР‹ (MS, MR, MC)");
                Console.WriteLine("8. Р СџР ВµРЎР‚Р ВµР С–Р В»РЎРЏР Р…РЎС“РЎвЂљР С‘ Р В¶РЎС“РЎР‚Р Р…Р В°Р В» Р С•Р В±РЎвЂЎР С‘РЎРѓР В»Р ВµР Р…РЎРЉ");
                Console.WriteLine("0. Р вЂ™Р С‘РЎвЂ¦РЎвЂ“Р Т‘ Р В· Р С—РЎР‚Р С•Р С–РЎР‚Р В°Р СР С‘");
                Console.WriteLine("----------------------------------------");
                if (hasMemory)
                {
                    Console.WriteLine($"[Р Р€ Р С—Р В°Р С'РЎРЏРЎвЂљРЎвЂ“ Р В·Р В±Р ВµРЎР‚Р ВµР В¶Р ВµР Р…Р С•: {memory}]");
                }
                Console.Write("Р С›Р В±Р ВµРЎР‚РЎвЂ“РЎвЂљРЎРЉ Р С—Р С•РЎвЂљРЎР‚РЎвЂ“Р В±Р Р…РЎС“ Р Т‘РЎвЂ“РЎР‹ (0-8): ");

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
                        Console.WriteLine("\nР вЂќРЎРЏР С”РЎС“РЎвЂќР СР С• Р В·Р В° Р Р†Р С‘Р С”Р С•РЎР‚Р С‘РЎРѓРЎвЂљР В°Р Р…Р Р…РЎРЏ Р С—РЎР‚Р С•Р С–РЎР‚Р В°Р СР С‘. Р вЂќР С• Р С—Р С•Р В±Р В°РЎвЂЎР ВµР Р…Р Р…РЎРЏ!");
                        break;
                    default:
                        Console.WriteLine("\nР СњР ВµР Р†РЎвЂ“РЎР‚Р Р…Р В° Р С”Р С•Р СР В°Р Р…Р Т‘Р В°! Р РЋР С—РЎР‚Р С•Р В±РЎС“Р в„–РЎвЂљР Вµ РЎвЂ°Р Вµ РЎР‚Р В°Р В·.");
                        WaitKey();
                        break;
                }
            }
        }

        // Р вЂР В°Р В·Р С•Р Р†РЎвЂ“ Р В°РЎР‚Р С‘РЎвЂћР СР ВµРЎвЂљР С‘РЎвЂЎР Р…РЎвЂ“ Р С•Р С—Р ВµРЎР‚Р В°РЎвЂ РЎвЂ“РЎвЂ”
        static void CalculateBasic(string op)
        {
            Console.WriteLine($"\n--- Р С›Р С—Р ВµРЎР‚Р В°РЎвЂ РЎвЂ“РЎРЏ: {op} ---");
            double a = ReadNumber("Р вЂ™Р Р†Р ВµР Т‘РЎвЂ“РЎвЂљРЎРЉ Р С—Р ВµРЎР‚РЎв‚¬Р Вµ РЎвЂЎР С‘РЎРѓР В»Р С•: ");
            double b = ReadNumber("Р вЂ™Р Р†Р ВµР Т‘РЎвЂ“РЎвЂљРЎРЉ Р Т‘РЎР‚РЎС“Р С–Р Вµ РЎвЂЎР С‘РЎРѓР В»Р С•: ");
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
                    Console.WriteLine("Р СџР С•Р СР С‘Р В»Р С”Р В°: Р Р…Р В° Р Р…РЎС“Р В»РЎРЉ Р Т‘РЎвЂ“Р В»Р С‘РЎвЂљР С‘ Р Р…Р Вµ Р СР С•Р В¶Р Р…Р В°!");
                    WaitKey();
                    return;
                }
                res = a / b;
            }

            string record = $"{a} {op} {b} = {res}";
            history.Add(record);
            Console.WriteLine($"Р В Р ВµР В·РЎС“Р В»РЎРЉРЎвЂљР В°РЎвЂљ: {res}");

            PromptSaveToMemory(res);
            WaitKey();
        }

        // Р СџРЎвЂ“Р Т‘Р Р…Р ВµРЎРѓР ВµР Р…Р Р…РЎРЏ Р Т‘Р С• РЎРѓРЎвЂљР ВµР С—Р ВµР Р…РЎРЏ
        static void CalculatePower()
        {
            Console.WriteLine("\n--- Р СџРЎвЂ“Р Т‘Р Р…Р ВµРЎРѓР ВµР Р…Р Р…РЎРЏ Р Т‘Р С• РЎРѓРЎвЂљР ВµР С—Р ВµР Р…РЎРЏ ---");
            double baseNum = ReadNumber("Р вЂ™Р Р†Р ВµР Т‘РЎвЂ“РЎвЂљРЎРЉ РЎвЂЎР С‘РЎРѓР В»Р С• (Р С•РЎРѓР Р…Р С•Р Р†РЎС“): ");
            double exp = ReadNumber("Р вЂ™Р Р†Р ВµР Т‘РЎвЂ“РЎвЂљРЎРЉ РЎРѓРЎвЂљР ВµР С—РЎвЂ“Р Р…РЎРЉ: ");

            double res = Math.Pow(baseNum, exp);
            string record = $"{baseNum} ^ {exp} = {res}";
            history.Add(record);

            Console.WriteLine($"Р В Р ВµР В·РЎС“Р В»РЎРЉРЎвЂљР В°РЎвЂљ: {res}");
            PromptSaveToMemory(res);
            WaitKey();
        }

        // Р С™Р Р†Р В°Р Т‘РЎР‚Р В°РЎвЂљР Р…Р С‘Р в„– Р С”Р С•РЎР‚РЎвЂ“Р Р…РЎРЉ
        static void CalculateSqrt()
        {
            Console.WriteLine("\n--- Р С›Р В±РЎвЂЎР С‘РЎРѓР В»Р ВµР Р…Р Р…РЎРЏ Р С”Р Р†Р В°Р Т‘РЎР‚Р В°РЎвЂљР Р…Р С•Р С–Р С• Р С”Р С•РЎР‚Р ВµР Р…РЎРЏ ---");
            double num = ReadNumber("Р вЂ™Р Р†Р ВµР Т‘РЎвЂ“РЎвЂљРЎРЉ РЎвЂЎР С‘РЎРѓР В»Р С•: ");

            if (num < 0)
            {
                Console.WriteLine("Р СџР С•Р СР С‘Р В»Р С”Р В°: Р С”Р С•РЎР‚РЎвЂ“Р Р…РЎРЉ Р В· Р Р†РЎвЂ“Р Т‘'РЎвЂќР СР Р…Р С•Р С–Р С• РЎвЂЎР С‘РЎРѓР В»Р В° Р Р…Р Вµ РЎвЂ“РЎРѓР Р…РЎС“РЎвЂќ РЎРѓР ВµРЎР‚Р ВµР Т‘ Р Т‘РЎвЂ“Р в„–РЎРѓР Р…Р С‘РЎвЂ¦ РЎвЂЎР С‘РЎРѓР ВµР В»!");
                WaitKey();
                return;
            }

            double res = Math.Sqrt(num);
            string record = $"РІв‚¬С™({num}) = {res}";
            history.Add(record);

            Console.WriteLine($"Р В Р ВµР В·РЎС“Р В»РЎРЉРЎвЂљР В°РЎвЂљ: {res}");
            PromptSaveToMemory(res);
            WaitKey();
        }

        // Р СљР ВµР Р…РЎР‹ Р С”Р ВµРЎР‚РЎС“Р Р†Р В°Р Р…Р Р…РЎРЏ Р С—Р В°Р С'РЎРЏРЎвЂљРЎвЂљРЎР‹
        static void ManageMemory()
        {
            Console.WriteLine("\n--- Р С™Р ВµРЎР‚РЎС“Р Р†Р В°Р Р…Р Р…РЎРЏ Р С—Р В°Р С'РЎРЏРЎвЂљРЎвЂљРЎР‹ ---");
            Console.WriteLine("1. Р вЂ”Р В°Р С—Р С‘РЎРѓР В°РЎвЂљР С‘ РЎвЂЎР С‘РЎРѓР В»Р С• Р Р† Р С—Р В°Р С'РЎРЏРЎвЂљРЎРЉ (MS)");
            Console.WriteLine("2. Р СџР С•Р С”Р В°Р В·Р В°РЎвЂљР С‘ РЎвЂЎР С‘РЎРѓР В»Р С• Р В· Р С—Р В°Р С'РЎРЏРЎвЂљРЎвЂ“ (MR)");
            Console.WriteLine("3. Р С›РЎвЂЎР С‘РЎРѓРЎвЂљР С‘РЎвЂљР С‘ Р С—Р В°Р С'РЎРЏРЎвЂљРЎРЉ (MC)");
            Console.Write("Р вЂ™Р С‘Р В±Р ВµРЎР‚РЎвЂ“РЎвЂљРЎРЉ Р Т‘РЎвЂ“РЎР‹: ");
            string subChoice = Console.ReadLine();

            if (subChoice == "1")
            {
                memory = ReadNumber("Р вЂ™Р Р†Р ВµР Т‘РЎвЂ“РЎвЂљРЎРЉ Р В·Р Р…Р В°РЎвЂЎР ВµР Р…Р Р…РЎРЏ Р Т‘Р В»РЎРЏ Р В·Р В±Р ВµРЎР‚Р ВµР В¶Р ВµР Р…Р Р…РЎРЏ: ");
                hasMemory = true;
                Console.WriteLine($"Р В§Р С‘РЎРѓР В»Р С• {memory} Р В·Р В±Р ВµРЎР‚Р ВµР В¶Р ВµР Р…Р С• Р Р† Р С—Р В°Р С'РЎРЏРЎвЂљРЎРЉ.");
            }
            else if (subChoice == "2")
            {
                if (hasMemory)
                    Console.WriteLine($"Р вЂ”Р Р…Р В°РЎвЂЎР ВµР Р…Р Р…РЎРЏ Р Р† Р С—Р В°Р С'РЎРЏРЎвЂљРЎвЂ“: {memory}");
                else
                    Console.WriteLine("Р СџР В°Р С'РЎРЏРЎвЂљРЎРЉ Р С—Р С•РЎР‚Р С•Р В¶Р Р…РЎРЏ.");
            }
            else if (subChoice == "3")
            {
                memory = 0;
                hasMemory = false;
                Console.WriteLine("Р СџР В°Р С'РЎРЏРЎвЂљРЎРЉ Р С•РЎвЂЎР С‘РЎвЂ°Р ВµР Р…Р С•.");
            }
            else
            {
                Console.WriteLine("Р СњР ВµР Р†РЎвЂ“РЎР‚Р Р…Р С‘Р в„– Р Р†Р С‘Р В±РЎвЂ“РЎР‚.");
            }
            WaitKey();
        }

        // Р вЂ”Р В°Р С—Р С‘РЎвЂљ Р Р…Р В° РЎв‚¬Р Р†Р С‘Р Т‘Р С”Р Вµ Р В·Р В±Р ВµРЎР‚Р ВµР В¶Р ВµР Р…Р Р…РЎРЏ Р Р† Р С—Р В°Р С'РЎРЏРЎвЂљРЎРЉ Р С—РЎвЂ“РЎРѓР В»РЎРЏ РЎР‚Р С•Р В·РЎР‚Р В°РЎвЂ¦РЎС“Р Р…Р С”РЎС“
        static void PromptSaveToMemory(double value)
        {
            Console.Write("Р вЂ”Р В±Р ВµРЎР‚Р ВµР С–РЎвЂљР С‘ РЎвЂ Р ВµР в„– РЎР‚Р ВµР В·РЎС“Р В»РЎРЉРЎвЂљР В°РЎвЂљ РЎС“ Р С—Р В°Р С'РЎРЏРЎвЂљРЎРЉ? (РЎвЂљ/Р Р…): ");
            string ans = Console.ReadLine()?.Trim().ToLower();
            if (ans == "РЎвЂљ" || ans == "y" || ans == "РЎвЂљР В°Р С”" || ans == "yes")
            {
                memory = value;
                hasMemory = true;
                Console.WriteLine($"Р В Р ВµР В·РЎС“Р В»РЎРЉРЎвЂљР В°РЎвЂљ {value} Р В·Р В±Р ВµРЎР‚Р ВµР В¶Р ВµР Р…Р С• Р Р† Р С—Р В°Р С'РЎРЏРЎвЂљРЎРЉ.");
            }
        }

        // Р СџР ВµРЎР‚Р ВµР С–Р В»РЎРЏР Т‘ Р В¶РЎС“РЎР‚Р Р…Р В°Р В»РЎС“ РЎвЂ“РЎРѓРЎвЂљР С•РЎР‚РЎвЂ“РЎвЂ”
        static void ShowHistory()
        {
            Console.WriteLine("\n=== Р вЂ“РЎС“РЎР‚Р Р…Р В°Р В» Р С•РЎРѓРЎвЂљР В°Р Р…Р Р…РЎвЂ“РЎвЂ¦ Р С•Р В±РЎвЂЎР С‘РЎРѓР В»Р ВµР Р…РЎРЉ ===");
            if (history.Count == 0)
            {
                Console.WriteLine("Р вЂ“РЎС“РЎР‚Р Р…Р В°Р В» Р С—Р С•РЎР‚Р С•Р В¶Р Р…РЎвЂ“Р в„–. Р вЂ™Р С‘ РЎвЂ°Р Вµ Р Р…Р Вµ Р Р†Р С‘Р С”Р С•Р Р…РЎС“Р Р†Р В°Р В»Р С‘ Р С•Р С—Р ВµРЎР‚Р В°РЎвЂ РЎвЂ“Р в„–.");
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

        // Р вЂќР С•Р С—Р С•Р СРЎвЂ“Р В¶Р Р…Р В° РЎвЂћРЎС“Р Р…Р С”РЎвЂ РЎвЂ“РЎРЏ Р В±Р ВµР В·Р С—Р ВµРЎвЂЎР Р…Р С•Р С–Р С• Р В·РЎвЂЎР С‘РЎвЂљРЎС“Р Р†Р В°Р Р…Р Р…РЎРЏ РЎвЂЎР С‘РЎРѓР ВµР В»
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
                Console.WriteLine("Р СњР ВµР С”Р С•РЎР‚Р ВµР С”РЎвЂљР Р…Р С‘Р в„– РЎвЂћР С•РЎР‚Р СР В°РЎвЂљ РЎвЂЎР С‘РЎРѓР В»Р В°! Р РЋР С—РЎР‚Р С•Р В±РЎС“Р в„–РЎвЂљР Вµ РЎвЂ°Р Вµ РЎР‚Р В°Р В·.");
            }
        }

        static void WaitKey()
        {
            Console.WriteLine("\nР СњР В°РЎвЂљР С‘РЎРѓР Р…РЎвЂ“РЎвЂљРЎРЉ Р В±РЎС“Р Т‘РЎРЉ-РЎРЏР С”РЎС“ Р С”Р В»Р В°Р Р†РЎвЂ“РЎв‚¬РЎС“ Р Т‘Р В»РЎРЏ Р С—РЎР‚Р С•Р Т‘Р С•Р Р†Р В¶Р ВµР Р…Р Р…РЎРЏ...");
            Console.ReadKey();
        }
    }
}
