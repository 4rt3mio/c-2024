using Task3.Classes;

namespace Task3
{
    public static class DateCalculator
    {
        public static void Run()
        {
            bool normParse;
            short whatCase;
            while (true)
            {
                Console.WriteLine("Введите 1, если хотите узнать день недели");
                Console.WriteLine("Введите 2, если хотите узнать сколько дней пройдет(-шло) между текущей датой и вашей датой");
                normParse = short.TryParse(Console.ReadLine(), out whatCase);
                if (normParse && (whatCase == 1 || whatCase == 2))
                {
                    switch (whatCase)
                    {
                        case 1:
                            Console.WriteLine("Введите дату в формате \"dd.MM.yyyy\"");
                            string s = Console.ReadLine();
                            if (s != null)
                            {
                                try
                                {
                                    Console.WriteLine(DateService.GetDay(s));
                                }
                                catch (Exception)
                                {
                                    Console.WriteLine("Вы ввели не валидную дату!!!");
                                }
                            }
                            else Console.WriteLine("Вы ничего не ввели!!!");
                            break;
                        case 2:
                            bool isRight = true;
                            short day = 0, month = 0, year = 0;
                            try
                            {
                                Console.WriteLine("Введите день: ");
                                day = Convert.ToInt16(Console.ReadLine());
                                Console.WriteLine("Введите месяц: ");
                                month = Convert.ToInt16(Console.ReadLine());
                                Console.WriteLine("Введите год: ");
                                year = Convert.ToInt16(Console.ReadLine());
                            }
                            catch (Exception)
                            {
                                Console.WriteLine("В одно из полей вы ввели не число!!!");
                                isRight = false;
                            }
                            if (isRight)
                            {
                                if (IsDateValid(day, month, year))
                                {
                                    Console.WriteLine(DateService.GetDaysSpan(day, month, year));
                                }
                                else
                                {
                                    Console.WriteLine("Вы ввели не валидную дату!!!");
                                }
                            }
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Вы ввели не 1 или 2!!!");
                }
                Console.WriteLine("Желаете ли вы продолжить выполнение программы? Если да введите 'y' или строку, которая начинатеся с 'y'");
                var temp = Console.ReadLine();
                switch (temp)
                {
                    case "y": break;
                    default: return;
                }
            }
        }

        public static bool IsDateValid(int day, int month, int year)
        {
            try
            {
                DateTime date = new DateTime(year, month, day);
                return true;
            }
            catch (ArgumentOutOfRangeException)
            {
                return false;
            }
        }
    }
}
