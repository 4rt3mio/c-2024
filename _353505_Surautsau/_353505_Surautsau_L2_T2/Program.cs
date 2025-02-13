while (true)
{
    bool isRight = true;
    double x = -1.0;
    double y = -1.0;
    try
    {
        Console.Write("Введите число(x): ");
        x = Convert.ToDouble(Console.ReadLine());
        Console.Write("Введите число(y): ");
        y = Convert.ToDouble(Console.ReadLine());
    }
    catch (Exception) {
        Console.WriteLine("Вы ввели не число!!!!");
        isRight = false;
    }
    if (isRight) {
        if (y < 0)
        {
            if (y < -x && y < x && y > -100) Console.WriteLine("Лежит внутри");
            else if (y <= 0 && y >= -100 && (y == x || y == -x || y == -100)) Console.WriteLine("Лежит на границе");
            else Console.WriteLine("Лежит за пределами заштрихованной площади");
        }
        else
        {
            if (x == 0 && y == 0)
            {
                Console.WriteLine("Лежит на границе");
            }
            else
            {
                Console.WriteLine("Лежит за пределами заштрихованной площади");
            }
        }
    }
    Console.WriteLine("Желате ли вы продолжить выполнение программы? Если да введите 'y' или строку, которая начинатеся с 'y'");
    var temp = Console.ReadLine();
    switch (temp)
    {
        case "y": break;
        default: return 0;
    }
}