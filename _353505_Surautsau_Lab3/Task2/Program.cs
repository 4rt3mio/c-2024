using System;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                double varPerformed = Services.InputService.GetNumberFromUser();
                double result;
                if (varPerformed != 1)
                {
                    result = Services.PerformAction.DoAction(varPerformed);
                    Console.WriteLine($"Полученный результат {result}");
                }
                else
                {
                    Console.WriteLine("Вы ввели 1, а это значит что в знаменателе будет 0(((");
                }

                if (!Services.InputService.WantToContinue())
                    return;
            }
        }
    }
}
