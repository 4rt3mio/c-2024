namespace Task1
{
    internal class DateProcessor
    {
        public static void ProcessInput()
        {
            double varPerformed;
            bool normParse;
            while (true)
            {
                Console.Write("Введите число, для которого хотите совершить операцию: ");
                normParse = double.TryParse(Console.ReadLine(), out varPerformed);
                if (normParse)
                {
                    int tryToInt = Convert.ToInt32(varPerformed);
                    double result;

                    if (varPerformed == tryToInt)
                    {
                        if (!double.IsInfinity(PerformAction.DoAction(tryToInt)))
                        {
                            result = PerformAction.DoAction(tryToInt);
                        }
                        else
                        {
                            Console.WriteLine("Результат переполнения.");
                            continue;
                        }
                    }
                    else
                    {
                        if (!double.IsInfinity(PerformAction.DoAction(varPerformed)))
                        {
                            result = PerformAction.DoAction(varPerformed);
                        }
                        else
                        {
                            Console.WriteLine("Результат переполнения.");
                            continue;
                        }
                    }
                    Console.WriteLine($"Полученный результат {result}");
                }
                else
                {
                    Console.WriteLine("Вы ввели не число!!!");
                }
                Console.WriteLine("Желаете ли вы продолжить выполнение программы? Если да введите 'y' или строку, которая начинается с 'y'");
                var temp = Console.ReadLine();
                switch (temp)
                {
                    case "y": break;
                    default: return;
                }
            }
        }
    }
}
