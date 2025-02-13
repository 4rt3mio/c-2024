while (true)
{
    int number = -1;
    bool isRight = true;
    try
    {
        Console.Write("Введите целое двузначное число: ");
        number = Convert.ToInt32(Console.ReadLine());
    }
    catch(Exception)
    {
        Console.WriteLine("Вы ввели не число!!!!");
        isRight = false;
    }
    if (isRight)
    {
        if (number < 10 || number > 99)
        {
            Console.WriteLine("Неверный ввод, число не двузначное");
        }
        else
        {
            int firstDigit = number % 10;
            int secondDigit = number / 10;
            bool isEven = ((firstDigit + secondDigit) % 2 == 1 ? false : true);
            if (isEven) Console.WriteLine("Сумма цифр этого числа четная");
            else Console.WriteLine("Сумма цифр этого числа нечетная");
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