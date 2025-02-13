using System;

namespace Task2.Services
{
    public static class InputService
    {
        public static double GetNumberFromUser()
        {
            double number;
            bool isParsed;
            do
            {
                Console.Write("Введите число, для которого хотите совершить операцию: ");
                isParsed = double.TryParse(Console.ReadLine(), out number);
                if (!isParsed)
                    Console.WriteLine("Вы ввели не число!!!");
            } while (!isParsed);

            return number;
        }

        public static bool WantToContinue()
        {
            Console.WriteLine("Желате ли вы продолжить выполнение программы? Если да введите 'y' или строку, которая начинатеся с 'y'");
            string input = Console.ReadLine();
            return input.StartsWith("y", StringComparison.OrdinalIgnoreCase);
        }
    }
}
